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
    public partial class UpdateForm : Form
    {
        public UpdateForm()
        {
            InitializeComponent();
        }
      
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Stud stud1 = new Stud(int.Parse(this.textBox1.Text), this.textBox2.Text, this.textBox3.Text, this.textBox4.Text);
            stud1.update();
            
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Program.getStudent().Show();
            Program.getUpdate().Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
