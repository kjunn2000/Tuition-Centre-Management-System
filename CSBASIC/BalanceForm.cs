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
    public partial class BalanceForm : Form
    {
        public BalanceForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stud stud1 = new Stud(int.Parse(this.textBox1.Text));
            stud1.balance();
        }

        

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Program.getStudent().Show();
            Program.getBalance().Hide();
        }
    }
}
