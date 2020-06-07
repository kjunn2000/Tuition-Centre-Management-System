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
    public partial class UploadForm : Form
    {
        public UploadForm()
        {
            InitializeComponent();
        }

       

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Tutor tutor1 = new Tutor(int.Parse(this.textBox1.Text), this.textBox2.Text, this.textBox3.Text, this.textBox4.Text, this.textBox5.Text, int.Parse(this.textBox6.Text));
            tutor1.upload();
            Program.getUpload().Hide();
            Program.getTutor().Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Program.getTutor().Show();
            Program.getUpload().Hide();
        }
    }
}
