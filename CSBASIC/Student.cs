using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CSBASIC
{
    class Student
    {

        private string StudName; private string StudPassword; private int payment;private string enroll;
        public Student(string StudName, string StudPassword)
        {
            this.StudName = StudName;
            this.StudPassword = StudPassword;
        }
        

        public string STUDNAME
        {
            get
            {
                return StudName;
            }
            set
            {
                StudName = value;
            }
        }
        public string STUDPASSWORD
        {
            get
            {
                return StudPassword;
            }
            set
            {
                StudPassword = value;
            }
        }
        public int PAYMENT
        {
            get
            {
                return payment;
            }
            set
            {
                payment = value;
            }
        }
        public string ENROLL
        {
            get
            {
                return ENROLL;
            }
            set
            {
                enroll = value;
            }
        }

    }
}
