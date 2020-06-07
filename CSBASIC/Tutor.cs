using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace CSBASIC
{
    class Tutor
    {
        private int TimetableID;
        private string subject;
        private string Date;
        private string Starttime;
        private string Endtime;
        private int Fee;
        private int CourseID=0;
        private int TutorID;

        public Tutor(int TimetableID,string subject, string Date , string Starttime,string Endtime ,int Fee)
        {
            this.TimetableID = TimetableID;
            this.subject = subject;
            this.Date = Date;
            this.Starttime = Starttime;
            this.Endtime = Endtime;
            this.Fee = Fee;
        }
        public Tutor (int TutorID)
        {
            this.TutorID = TutorID;
        }
        public void upload()
        {
        
            OleDbCommand cmd = Program.getConnection().CreateCommand();
            cmd.CommandText = "update Timetable set SubjectName ='"+subject+ "',TimetableDate ='" + Date + "' ,StartTime ='" + Starttime + "',EndTime ='" + Endtime + "' where TimetableID=" + TimetableID + ";";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "select CourseID from Timetable where TimetableID =" +TimetableID+ ";";
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                CourseID=reader.GetInt32(0);
            }
            reader.Close();
            cmd.CommandText = "update Course set Fee = " + Fee + " where CourseID="+CourseID+"; ";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Updated.");

        
        
        }

        public  void viewprofile()
        {
            string row = "";
            int i = 0;
            int[] StudID = new int[1000];
            OleDbCommand cmd = Program.getConnection().CreateCommand();
            cmd.Connection = Program.getConnection();
            cmd.CommandText = "select CourseID from Course where TutorID=" + TutorID + ";";
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                CourseID = reader.GetInt32(0);
            }
            reader.Close();
            cmd.CommandText = "select StudID from Enroll where CourseID=" + CourseID + ";";
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                StudID[i] = reader.GetInt32(0);
                i++;
            }
            i = 0;
            reader.Close();
            while (i < StudID.GetLength(0)){
                cmd.CommandText = "select StudID ,StudName ,Payment ,Date_Registration from Student where StudID=" + StudID[i] + ";";
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    row = reader.GetValue(0).ToString() + "\t\t" + reader.GetValue(1).ToString() + "\t\t" + reader.GetValue(2).ToString() + "\t\t" + reader.GetDateTime(3).ToString("dd/MM/yyyy");
                    Program.getProfile().listBox1.Items.Add(row);
                    Program.getProfile().listBox1.Items.Add("\n");
                    
                }
                i++;
                reader.Close();
            }
        }
    }
}
