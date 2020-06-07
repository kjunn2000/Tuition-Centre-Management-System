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
    public partial class StudentPage : Form
    {
        string username, password;
        public StudentPage()
        {
            InitializeComponent();
        }

        public StudentPage(string u, string p)
        {
            InitializeComponent();
            this.username = u;
            this.password = p;
        }

       


        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Program.getLogin().Show();
            Program.getStudent().Hide();


        }

       

       
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Program.getUpdate().Show();
            Program.getStudent().Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Program.getBalance().Show();
            Program.getStudent().Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Program.getSchedule().Show();
            Program.getStudent().Hide();
        }

        private void StudentPage_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
