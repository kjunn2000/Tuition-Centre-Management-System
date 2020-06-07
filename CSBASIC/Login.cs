using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace CSBASIC
{
    public partial class Login : Form
    {
        private OleDbConnection con;


        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            method method1 = new method(this.textBox1.Text, int.Parse(this.textBox2.Text), this.textBox2.PasswordChar);
            method1.login();

        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        

        

        

        public static implicit operator Login(StaffPage v)
        {
            throw new NotImplementedException();
        }

        public static implicit operator Login(StudentPage v)
        {
            throw new NotImplementedException();
        }

        public static implicit operator Login(TutorPage v)
        {
            throw new NotImplementedException();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Program.getLogin().Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            method method1 = new method(this.textBox1.Text, int.Parse(this.textBox2.Text),this.textBox2.PasswordChar);
            char PasswordChar = method1.showPassword();
            this.textBox2.PasswordChar = PasswordChar;

        }
    }
}
