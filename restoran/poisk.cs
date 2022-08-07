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
    public partial class poisk : Form
    {
        public poisk()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int k = 0;
            main main = this.Owner as main;
            if (main != null)
            {
                for (int i = 0; i < main.dataGridView1.RowCount; i++)
                {
                    main.dataGridView1.Rows[1].Selected = false;
                    for (int j = 0; j < main.dataGridView1.ColumnCount; j++)
                    {
                        if (main.dataGridView1.Rows[i].Cells[j].Value != null)
                        {
                            if (main.dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox1.Text))
                            {
                                main.dataGridView1.Rows[i].Selected = true;
                                k++;
                                break;//поиск по базе данных
                            }
                        }
                    }
                }
                label1.Text = "Найдено " + k.ToString() + " Совпадений";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void poisk_Load(object sender, EventArgs e)
        {

        }
    }
}
