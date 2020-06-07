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
    public partial class EnrollForm : Form
    {
        

        public EnrollForm()
        {
            InitializeComponent();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Staff staff1 = new Staff(int.Parse(this.textBox1.Text), this.checkBox1.Checked, this.checkBox2.Checked, this.checkBox3.Checked, this.checkBox4.Checked);
            int Payment = staff1.Calculate();
            this.label1.Text = Payment.ToString();
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Staff staff1 = new Staff(int.Parse(this.textBox1.Text),this.checkBox1.Checked, this.checkBox2.Checked, this.checkBox3.Checked,this.checkBox4.Checked,int.Parse(this.label1.Text));
            staff1.Enroll();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Program.getStaff().Show();
            Program.getEnroll().Hide();

        }
        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
