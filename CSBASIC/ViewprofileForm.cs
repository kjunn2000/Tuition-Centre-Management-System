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
    public partial class ViewprofileForm : Form
    {
        public ViewprofileForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
            this.listBox1.Items.Add("StudID                 StudName               Payment               Date_Registration");
            Tutor tutor1 = new Tutor(int.Parse(this.textBox1.Text));
            tutor1.viewprofile();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Program.getTutor().Show();
            Program.getProfile().Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
