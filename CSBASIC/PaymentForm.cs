using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSBASIC
{
    public partial class PaymentForm : Form
    {
        public PaymentForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Staff staff1 = new Staff(int.Parse(this.textBox1.Text), 0);
            int balance = staff1.checkbalance();
            this.label3.Text = balance.ToString();
        }

        
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Staff.payment();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Staff.payment();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Program.getStaff().Show();
            Program.getPayment().Hide();
        }
    }
}
