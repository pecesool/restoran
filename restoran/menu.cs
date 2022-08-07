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
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }
        int res;
        private void label12_Click(object sender, EventArgs e)
        {
            main s = new main();
            s.Show();
            this.Hide();//переход на другую форму
        }

        private void button1_Click(object sender, EventArgs e)
        {
            res += 500;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            res += 1000;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            res += 500;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            res += 700;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            res += 150;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            res += 120;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            res += 200;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            res += 200;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            res = 0;
            label10.Text = "Заказ:   Доставка:   Итого: ";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            int a = res + 600;
            label10.Text = "Заказ: " + res.ToString() + "тг Доставка: 600тг Итог: " + a.ToString() + "тг";//расчет заказа покупателя с учетом доставки
        }

        private void menu_Load(object sender, EventArgs e)
        {

        }
    }
}
