using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSBASIC
{
    class method
    {
        private string UserName;
        private int Password;
        private char PasswordChar;

        public method(string UserName,int Password,char PasswordChar)
        {
            this.UserName = UserName;
            this.Password = Password;
            this.PasswordChar= PasswordChar;
        }
        public string USERNAME
        {
            set
            {
                UserName = value;
            }
            get
            {
                return UserName;
            }
        }

        public int PASSWORD
        {
            set
            {
                Password = value;
            }
            get
            {
                return Password;
            }
        }
        public char PASSWORDCHAR
        {
            set
            {
                PasswordChar = value;
            }
            get
            {
                return PasswordChar;
            }
        }
        public void login()
        {
                    
            try
            {
                OleDbCommand cmd = Program.getConnection().CreateCommand();
                cmd.Connection = Program.getConnection();
                cmd.CommandText = "Select * from Staff where StaffName='" + UserName + "' and StaffPassword='" + Password + "';";
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Program.getStaff().Show();
                    Program.getLogin().Hide();
                    return;
                }
                
                 
                reader.Close();
                cmd = Program.getConnection().CreateCommand();
                cmd.Connection = Program.getConnection();
                cmd.CommandText = "Select * from Student where StudName='" + UserName  + "' and StudPassword='" + Password + "';";
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Program.getStudent().Show();
                    Program.getLogin().Hide();
                    return;

                }
                
                
                reader.Close();
                cmd.Connection = Program.getConnection();
                cmd.CommandText = "Select * from Tutor where TutorName='" + UserName + "' and TutorPassword='" + Password + "';";
                OleDbDataReader reader2 = cmd.ExecuteReader();
                if (reader2.Read())
                {
                    Program.getTutor().Show();
                    Program.getLogin().Hide();
                    return;
                }
                
                
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error:" + ex);
            }
           
            MessageBox.Show("Invalid username or password.");
            
        }

      
        public  char showPassword()
        {

            if ( PasswordChar == '*')
            {
               PasswordChar = '\0';
            }
            else
            {
                PasswordChar = '*';
            }
            return PasswordChar;

        }
    }
}
