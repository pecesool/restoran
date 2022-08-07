using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace restoran
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Application.Exit();//выход
        }

        private void button1_Click(object sender, EventArgs e)
        {
            menu s = new menu();
            s.Show();
            this.Hide();//переход на форму
        }

        private void button2_Click(object sender, EventArgs e)
        {
            zakaz s = new zakaz();
            s.Show();
            this.Hide();//переход на форму
        }

        private void button3_Click(object sender, EventArgs e)
        {
            poisk sf = new poisk();
            sf.Owner = this;
            sf.Show();//переход на другую форму
        }

        private void main_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bd1DataSet.заказ". При необходимости она может быть перемещена или удалена.
            this.заказTableAdapter.Fill(this.bd1DataSet.заказ);
           

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = true;
        }
        int x;
        private void button6_Click(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true) { x = 0; }
            if (radioButton3.Checked == true) { x = 1; }
            if (checkBox6.Checked == true) { if (x == 0) { заказBindingSource.Sort = "Имя ASC"; } else { заказBindingSource.Sort = "Имя DESC"; } }
            if (checkBox5.Checked == true) { if (x == 0) { заказBindingSource.Sort = "Дата записи ASC"; } else { заказBindingSource.Sort = "Дата записи DESC"; } }
            if (checkBox4.Checked == true) { if (x == 0) { заказBindingSource.Sort = "Постоянный клиент ASC"; } else { заказBindingSource.Sort = "Постоянный клиент DESC"; } }
            if (checkBox2.Checked == true) { if (x == 0) { заказBindingSource.Sort = "Фамилия ASC"; } else { заказBindingSource.Sort = "Фамилия DESC"; } }
            if (checkBox1.Checked == true) { if (x == 0) { заказBindingSource.Sort = "Время записи ASC"; } else { заказBindingSource.Sort = "время записи DESC"; } }//сортировка по нескольким полям
        }

        private void button5_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;//сброс сортировки
        }
        bool res;
        private void button7_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "да") { res = true; } else { res = false; }
            int k = 0;
            string poisk = "";
            if (textBox1.Text != "")
            {
                k++;
                if (k > 1)
                {
                    poisk += " AND ";
                }
                poisk += "[Имя] LIKE'%" + textBox1.Text + "%'";
            }
            if (textBox2.Text != "")
            {
                k++;
                if (k > 1)
                {
                    poisk += " AND ";
                }
                poisk += "[Фамилия] LIKE'%" + textBox2.Text + "%'";
            }
            if (textBox3.Text != "")
            {
                k++;
                if (k > 1)
                {
                    poisk += " AND ";
                }
                poisk += "[Цена]=" + Convert.ToInt32(textBox3.Text);
            }

            if (comboBox1.Text != "")
            {
                k++;
                if (k > 1)
                {
                    poisk += " AND ";
                }
                if (res == true)
                {
                    poisk += заказBindingSource.Filter = "[Постоянный клиент] = 1";
                }
                else { poisk += заказBindingSource.Filter = "[Постоянный клиент] = 0"; }
            }
            if (k >= 1)
            {
                заказBindingSource.Filter = poisk;//фильрация по нескольким полям

            }
            else
            {
                if (k == 0)
                {
                    заказBindingSource.Filter = "";//сброс фильтрации
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            заказBindingSource.Filter = null;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";//сброс фильра
        }
    }
}
