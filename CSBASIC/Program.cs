using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSBASIC
{
    static class Program
    {                                                       
        private static OleDbConnection con;
        private static Login loginPage;
        private static StaffPage staffPage;
        private static StudentPage studentPage;
        private static TutorPage tutorPage;
        private static RegisterForm registerPage;
        private static EnrollForm enrollPage;
        private static UpdateForm updatePage;
        private static BalanceForm balancePage;
        private static PaymentForm paymentPage;
        private static ScheduleForm schedulePage;
        private static UploadForm uploadPage;
        private static ViewprofileForm viewprofilePage;
        private static ReceiptForm receiptPage;



        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            loginPage = new Login();
            staffPage = new StaffPage();
            studentPage = new StudentPage();
            tutorPage = new TutorPage();
            registerPage = new RegisterForm();
            enrollPage = new EnrollForm();
            updatePage = new UpdateForm();
            balancePage = new BalanceForm();
            paymentPage = new PaymentForm();
            schedulePage = new ScheduleForm();
            uploadPage = new UploadForm();
            viewprofilePage = new ViewprofileForm();
            receiptPage = new ReceiptForm();


            con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=IOOP.accdb");
            con.Open();
            Application.Run(loginPage);
        }

        public static Login getLogin()
        {
            return loginPage;
        }
        public static StaffPage getStaff()
        {
            return staffPage;
        }
        public static StudentPage getStudent()
        {
            return studentPage;
        }
        public static TutorPage getTutor()
        {
            return tutorPage;
        }
        public static RegisterForm getRegister()
        {
            return registerPage;
        }
        public static EnrollForm getEnroll()
        {
            return enrollPage;
        }
        public static UpdateForm getUpdate()
        {
            return updatePage;
        }
        public static BalanceForm getBalance()
        {
            return balancePage;
        }
        public static PaymentForm getPayment()
        {
            return paymentPage;
        }
        public static ScheduleForm getSchedule()
        {
            return schedulePage;
        }
        public static UploadForm getUpload()
        {
            return uploadPage;
        }
        public static ViewprofileForm getProfile()
        {
            return viewprofilePage;
        }
        public static ReceiptForm getReceipt()
        {
            return receiptPage;
        }
        public static OleDbConnection getConnection()
        {
            return con;
        }
        
       
    }
}
