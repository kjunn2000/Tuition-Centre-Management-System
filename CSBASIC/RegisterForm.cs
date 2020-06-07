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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Staff staff1 = new Staff(this.textBox1.Text, this.textBox2.Text, this.textBox4.Text, this.textBox5.Text, this.textBox6.Text, this.checkBox1.Checked, this.checkBox2.Checked, this.checkBox3.Checked);
            staff1.Register();
            

        }


        private void label5_Click(object sender, EventArgs e)
        {
            Program.getStaff().Show();
            Program.getRegister().Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Program.getRegister().checkBox2.Checked = false;
            Program.getRegister().checkBox3.Checked = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Program.getRegister().checkBox1.Checked = false;
            Program.getRegister().checkBox3.Checked = false;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            Program.getRegister().checkBox1.Checked = false;
            Program.getRegister().checkBox2.Checked = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
