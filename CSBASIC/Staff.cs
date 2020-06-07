using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace CSBASIC
{
    class Staff
    {
        private string UserName;
        private string Password;
        private string Address;
        private string Contact;
        private string Email;
        private bool StaffReg;
        private bool StudReg;
        private bool TutorReg;
        private int StudID;
        private bool ChineseEnroll;
        private bool EnglishEnroll;
        private bool BiologyEnroll;
        private bool PhysicEnroll;
        private int balance;
        private int Payment;
       

       
        
        public Staff(string UserName, string Password,string Address,string  Contact,string Email,bool StaffReg, bool StudReg, bool TutorReg)
        {
            this.UserName = UserName;
            this.Password = Password;
            this.Address = Address;
            this.Contact = Contact;
            this.Email = Email;
            this.StaffReg = StaffReg;
            this.StudReg = StudReg;
            this.TutorReg = TutorReg;
        }
        public Staff(int StudID, bool ChineseEnroll, bool EnglishEnroll, bool BiologyEnroll, bool PhysicEnroll)
        {
            this.StudID = StudID;
            this.ChineseEnroll = ChineseEnroll;
            this.EnglishEnroll = EnglishEnroll;
            this.BiologyEnroll = BiologyEnroll;
            this.PhysicEnroll = PhysicEnroll;
        }
        public Staff(int StudID, bool ChineseEnroll, bool EnglishEnroll, bool BiologyEnroll, bool PhysicEnroll, int Payment)
        {
            this.StudID = StudID;
            this.ChineseEnroll = ChineseEnroll;
            this.EnglishEnroll = EnglishEnroll;
            this.BiologyEnroll = BiologyEnroll;
            this.PhysicEnroll = PhysicEnroll;
            this.Payment = Payment;
        }
        public Staff(int StudID,int balance)
        {
            this.StudID = StudID;
            this.balance = balance;


        }


        public void Register()
        {
            
            int flag = 1;
            int i = 0;
            int a = 0;
            while (i < Program.getRegister().textBox6.Text.Length)
            {
                if (Program.getRegister().textBox6.Text[i] == '@')
                {
                    a = 1;
                }
                i++;
            }
            if (a == 1)
            {


                if (StaffReg)
                {
                    try
                    {
                        OleDbCommand cmd = Program.getConnection().CreateCommand();
                        cmd.Connection = Program.getConnection();
                        cmd.CommandText = "select StaffName from Staff where StaffName='" + UserName + "' ;";
                        OleDbDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            if (reader.GetString(0) == UserName)
                            {
                                flag = 0;
                                MessageBox.Show("Username already exist.");
                            }
                        }
                        reader.Close();
                        if (flag == 1)
                        {
                            cmd.CommandText = "insert into Staff (StaffName,StaffPassword,Home_Address,Contact_Number,Email)values ('" + UserName + "' ,'" + Password + "','" + Address + "','" + Contact + "','" + Email + "' );";
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Saved.");
                            MessageBox.Show("Successful.");

                        }
                        reader.Close();


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Exception:" + ex);
                    }
                    Program.getStaff().Show();
                    Program.getRegister().Hide();
                }
                else if (StudReg)
                {

                    int payment = 0;
                    OleDbCommand cmd = Program.getConnection().CreateCommand();
                    cmd.Connection = Program.getConnection();
                    string StudID = "";
                    cmd.CommandText = "select StudName from Student where StudName='" + UserName + "' ;";
                    OleDbDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        if (reader.GetString(0) == UserName)
                        {
                            flag = 0;
                            MessageBox.Show("Username already exist.");
                        }
                    }
                    reader.Close();
                    if (flag == 1)
                    {
                        try
                        {
                            cmd.CommandText = "Insert into Student(StudName,StudPassword,Payment,Date_Registration,Home_Address,Contact_Number,Email)values ('" + UserName + "' ,'" + Password + "' , " + payment + ",'" + DateTime.Now.Date.ToString("dd/MM/yyyy") + "','" + Address + "','" + Contact + "','" + Email + "' );";
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Saved.");
                            MessageBox.Show("Successful.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Exception:" + ex);
                        }
                        cmd.CommandText = "select StudID from Student where StudPassword='" + Password + "';";
                        reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {

                            MessageBox.Show("This is your Student ID , you can update your profile by log in your acc :" + reader.GetInt32(0));
                        }
                        Program.getEnroll().Show();
                        Program.getRegister().Hide();
                        return;
                    }
                    
                }
                else if (TutorReg)
                {
                    OleDbCommand cmd = Program.getConnection().CreateCommand();
                    cmd.CommandText = "select TutorName from Tutor where TutorName='" + UserName + "' ;";
                    OleDbDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        if (reader.GetString(0) == UserName)
                        {
                            flag = 0;
                            MessageBox.Show("Username already exist.");
                        }
                    }
                    reader.Close();
                    if (flag == 1)
                    {
                        try
                        {
                            cmd.CommandText = "insert into Tutor (TutorName,TutorPassword,Home_Address,Contact_Number,Email)values ('" + UserName + "' ,'" + Password + "','" + Address + "','" + Contact + "','" + Email + "' );";
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Saved.");
                            MessageBox.Show("Successful.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Exception:" + ex);
                        }

                    }

                
                }
            Program.getStaff().Show();
            Program.getRegister().Hide();
            }
            else
            {
                MessageBox.Show("Email is not contain '@' ");
                
                
            }
            

        }

        public int Calculate()
        {
            int payment = 0;
            if (ChineseEnroll)
            {
                payment += 100;
            }
            if (EnglishEnroll)
            {
                payment += 100;
            }
            if (BiologyEnroll)
            {
                payment += 100;
            }
            if (PhysicEnroll)
            {
                payment += 100;
            }
            return payment;


        }
        public void Enroll()
        {
            int flag = 0;
            OleDbCommand cmd = Program.getConnection().CreateCommand();
            cmd.CommandText = "select * from Student";
            OleDbDataReader reader = cmd.ExecuteReader();
            reader.Close();
            if (ChineseEnroll)
            {

                cmd.CommandText = "Select count(CourseID) from Enroll where CourseID = 1;";
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader.GetInt32(0) < 25)
                    {
                        reader.Close();
                        cmd.CommandText = "insert into Enroll (StudID,CourseID,EnrollDate) values(" + StudID + ",1,'" + DateTime.Now.Date.ToString() + "');";
                        cmd.ExecuteNonQuery();
                        
                        MessageBox.Show("Hi,You are one of the member in Chinese course.");

                    }
                    else
                    {
                        MessageBox.Show("This chinese course already full,choose others courses .");
                        Payment -= 100;
                        flag = 1;


                    }
                }
                else
                {
                    MessageBox.Show("Course not available.");
                }
            }
            reader.Close();
            if (EnglishEnroll)
            {
                cmd.CommandText = "Select count(CourseID) from Enroll where CourseID = 2;";
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader.GetInt32(0) < 25)
                    {
                        cmd.CommandText = "insert into Enroll(StudID, CourseID, EnrollDate) values(" + StudID + ", 2, '" + DateTime.Now.Date.ToString()  + "'); ";
                        reader.Close();
                        cmd.ExecuteNonQuery();
                        
                        MessageBox.Show("Hi,You are one of the member in English course.");

                    }
                    else
                    {
                        MessageBox.Show("This english course already full,choose others courses .");
                        Payment -= 100;
                        flag = 1;


                    }
                }
                else
                {
                    MessageBox.Show("Course not available.");
                }

            }
            reader.Close();
            if (BiologyEnroll)
            {

                cmd.CommandText = "Select count(CourseID) from Enroll where CourseID = 3;";
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader.GetInt32(0) < 25)
                    {
                        cmd.CommandText = "insert into Enroll (StudID,CourseID,EnrollDate) values(" + StudID + ", 3,'" + DateTime.Now.Date.ToString() + "'); ";
                        reader.Close();
                        reader.Close();
                        cmd.ExecuteNonQuery();
                       
                        MessageBox.Show("Hi,You are one of the member in Biology course.");

                    }
                    else
                    {
                        MessageBox.Show("This biology course already full,choose others courses .");
                        Payment -= 100;
                        flag = 1;


                    }
                }
                else
                {
                    MessageBox.Show("Course not available.");
                }


            }
            reader.Close();
            if (PhysicEnroll)
            {
                cmd.CommandText = "Select count(CourseID) from Enroll where CourseID = 4;";
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader.GetInt32(0) < 25)
                    {
                        cmd.CommandText = "insert into Enroll (StudID,CourseID,EnrollDate) values(" + StudID + ",4,'" + DateTime.Now.Date.ToString() + "'); ";
                        reader.Close();
                        cmd.ExecuteNonQuery();
                        
                        MessageBox.Show("Hi,You are one of the member in Physic course.");
                    }
                    else
                    {
                        MessageBox.Show("This physic course already full,choose others courses .");
                        Payment -= 100;
                        flag = 1;


                    }
                }
                else
                {
                    MessageBox.Show("Course not available.");
                }


            }
            reader.Close();
            if( flag == 1 && ChineseEnroll && !BiologyEnroll && !EnglishEnroll && !PhysicEnroll)           
            {
                return;
            }
            else if (flag == 1 && !ChineseEnroll && BiologyEnroll && !EnglishEnroll && !PhysicEnroll)
            {
                return;
            }
            else if (flag == 1 && !ChineseEnroll && !BiologyEnroll && EnglishEnroll && !PhysicEnroll)
            {
                return;
            }
            else if (flag == 1 && !ChineseEnroll && !BiologyEnroll && !EnglishEnroll && PhysicEnroll)
            {
                return;
            }
            else
            {
                cmd.CommandText = "update Student set payment =" + Payment + " where StudID=" + StudID + ";";
                cmd.ExecuteNonQuery();
                Staff.Receipt(StudID, Payment);
            }
        }
        public static void Receipt(int StudID, int Payment)
        {
            try
            {

                OleDbCommand cmd = Program.getConnection().CreateCommand();
                cmd.Connection = Program.getConnection();
                cmd.CommandText = "insert into Receipt(StudID,ReceiptDate,Payment)values(" + StudID + ",'" + DateTime.Now + "'," + Payment + ");";
                cmd.ExecuteNonQuery();
                Program.getReceipt().Show();
                Program.getPayment().Hide();
                Program.getEnroll().Hide();
                Program.getReceipt().textBox1.Text = StudID.ToString();
                Program.getReceipt().textBox2.Text = DateTime.Now.ToString();
                Program.getReceipt().textBox3.Text = Payment.ToString();
                MessageBox.Show("Here is you receipt.");
                MessageBox.Show("Click exit to close.");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        public int checkbalance()
        {
            
            try
            {
                OleDbCommand cmd = Program.getConnection().CreateCommand();
                cmd.Connection = Program.getConnection();
                cmd.CommandText = "select payment from Student where StudID= " + StudID + ";";
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    balance = reader.GetInt32(0);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return balance;
        }
        public static void payment()
        {
            try
            {
                int textBox1 = int.Parse(Program.getPayment().textBox1.Text);
                int pay = int.Parse(Program.getPayment().textBox2.Text);
                int payment = 0;
                OleDbCommand cmd = Program.getConnection().CreateCommand();
                cmd.Connection = Program.getConnection();
                cmd.CommandText = "select payment from Student where StudID=" + textBox1 + ";";
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    payment = reader.GetInt32(0);
                }
                reader.Close();
                payment = payment - pay;
                cmd.CommandText = "update Student set payment = " + payment + " where StudID=" + textBox1 + " ;";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successful.");
                MessageBox.Show("Your outstanding balance is " + payment);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
       
}
