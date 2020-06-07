using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace CSBASIC
{
    public class Stud
    {
        private int StudID;
        private string Address;
        private string Contact;
        private string Email;
        private int i = 0;
        int[] CourseID = new int[4];
        string[] Schedule = new string[10];
        int a = 0;
        int count = 0;
        string row = "";

        public Stud(int StudID, string Address, string Contact, string Email)
        {
            this.StudID = StudID;
            this.Address = Address;
            this.Contact = Contact;
            this.Email = Email;
        }

        public Stud(int StudID)
        {
            this.StudID = StudID;
        }
        public  void update()
        {
            int i = 0;
            int flag = 0;
            while (i < Email.Length)
            {
                if ( Email[i]=='@')
                {
                    flag = 1;
                }
                i++;
            }
            if (flag == 1) {
                try
                {

                    OleDbCommand cmd = Program.getConnection().CreateCommand();
                    cmd.Connection = Program.getConnection();
                    cmd.CommandText = "UPDATE Student SET Home_Address='" +Address+ "' ,Contact_Number='" +Contact + "',Email='" + Email + "' where StudID=" + StudID + " ;";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Update Successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                Program.getStudent().Show();
                Program.getUpdate().Hide();
            }
            else
            {
                MessageBox.Show("Email is not contain '@' ");
                Program.getUpdate().Show();
                
            }
        }

        public  void balance()
        {
            int payment = 0;
            try
            {
                OleDbCommand cmd = Program.getConnection().CreateCommand();
                cmd.Connection = Program.getConnection();
                cmd.CommandText = "select payment from Student where StudID= " + StudID + ";";
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    payment = reader.GetInt32(0);
                }
                reader.Close();
                Program.getBalance().label3.Text = payment.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void schedule()
        {
          
            try
            {
                OleDbCommand cmd = Program.getConnection().CreateCommand();
                cmd.Connection = Program.getConnection();
                cmd.CommandText = "select CourseID from Enroll where StudID= "+ StudID +";";
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read()){
                    CourseID[i]=reader.GetInt32(0);
                    i++;
                }
                reader.Close();
                cmd.CommandText = "select SubjectName, TimetableDate, StartTime,EndTime from Timetable  where CourseID in (" + CourseID[0] + "," + CourseID[1] + "," + CourseID[2] + "," + CourseID[3] + ");";
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    row = reader.GetValue(0).ToString() + "\t\t" + reader.GetDateTime(1).ToString("dd/MM/yyyy") + "\t"+ "         " + reader.GetDateTime(2).ToString("hh:mm tt") + "       "+ "\t" + reader.GetDateTime(3).ToString("hh:mm tt");
                    Program.getSchedule().listBox1.Items.Add(row);
                    Program.getSchedule().listBox1.Items.Add("\n");
                }              
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}