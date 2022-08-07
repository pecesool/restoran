using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace restoran
{
    public partial class zakaz : Form
    {
        public zakaz()
        {
            InitializeComponent();
        }

        private void menu_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bd1DataSet.заказ". При необходимости она может быть перемещена или удалена.
            this.заказTableAdapter.Fill(this.bd1DataSet.заказ);

            MessageBox.Show("В данном окне вы можете добавлять новые заказы и реадактировать базу данных" );
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
            }//загрузка изображение из файлов
        }

        private void label12_Click(object sender, EventArgs e)
        {
            main s = new main();
            s.Show();
            this.Hide();//переход на другую форму
        }
        bool res;
        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "да") { res = true; } else { res = false; }
            try
            {
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                byte[] img = ms.ToArray();
                DataRow nRow = bd1DataSet.Tables[0].NewRow();
                int rc = dataGridView1.RowCount + 1;
                nRow[0] = rc;
                nRow[1] = textBox1.Text;
                nRow[2] = textBox2.Text;
                nRow[3] = dateTimePicker1.Value;
                nRow[4] = res;
                nRow[5] = img;
                nRow[6] = Convert.ToInt32(textBox3.Text);
                bd1DataSet.Tables[0].Rows.Add(nRow);

                заказTableAdapter.Adapter.Update(bd1DataSet.заказ);
                bd1DataSet.Tables[0].AcceptChanges();
                dataGridView1.Refresh();//сохранение записи
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            заказTableAdapter.Adapter.Update(bd1DataSet.заказ);
            bd1DataSet.Tables[0].AcceptChanges();
            dataGridView1.Refresh();
            main s = new main();
            s.Show();
            this.Hide();//сохранение и переход на другую форму
        }
    }
}
