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
    public partial class StaffPage : Form
    {
        string username, password; 
        public StaffPage()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        

        

       

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Program.getLogin().Show();
            Program.getStaff().Hide();
        }

        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Program.getRegister().Show();
            Program.getStaff().Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Program.getEnroll().Show();
            Program.getStaff().Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Program.getPayment().Show();
            Program.getStaff().Hide();
        }

        public StaffPage(string u ,string p)
        {
            InitializeComponent();
            this.username = u;
            this.password = p;
        }
    }
}
