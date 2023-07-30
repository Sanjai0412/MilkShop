using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace MILK_SHOP
{
    public partial class LoginForm : Form
    {
       
        public DateTime nxtdate;
        public int Logtotal = 0;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userId = textBox1.Text;
            

            // Read the UserDetails from File and Store to the Object 
            string[] ar = File.ReadAllLines("C:\\MilkPrice\\" + userId +".txt");
            string[] Check = ar[0].ToString().Split('|');
            UserData user= new UserData();
            user.Name1 = Check[0];
            user.Userid = Check[1];
            user.Email = Check[2];
            user.Address = Check[3];

            MilkPreference milkPref = new MilkPreference();
            milkPref.Period = Check[4];
            milkPref.MilkType = Check[5];
            milkPref.Brand = Check[6];
            milkPref.Packtype = Check[7];
            milkPref.Quantity = int.Parse(Check[8]);
            milkPref.BillAmount1 = int.Parse(Check[9]);
            milkPref.StratDate =DateTime.Parse( Check[10]);
            milkPref.EndDate =DateTime.Parse( Check[11]);

           

            UserDetail userDetail = new UserDetail();
            userDetail.UserData=user;
            userDetail.MilkPreference = milkPref;
          

            // Read All The Bill and update userdetail billList<>
            for (int i = 2; i < ar.Length; i++) 
            {
                string[] Bill = ar[i].ToString().Split('|');
                BillStructure MyBill = new BillStructure();
                MyBill.BillDate = DateTime.Parse(Bill[0]);
                MyBill.Quantity = int.Parse(Bill[1]);
                MyBill.BillAmount = int.Parse(Bill[2]);

                userDetail.BillList.Add(MyBill);

                nxtdate = DateTime.Parse(Bill[0]);
               
            }

            Logtotal = 0;
            string[] ar1 = File.ReadAllLines("C:\\MilkPrice\\" + userDetail.UserData.Userid + ".txt");
            for (int i = 2; i < ar.Length; i++)
            {
                string[] Bill = ar[i].ToString().Split('|');

                Logtotal += int.Parse(Bill[2]);
            }
            Total t = new Total();
            t.Total1 = Logtotal;
            userDetail.Total = t;

            DateTime LoginDate=DateTime.Now; 
            DateTime start = userDetail.MilkPreference.stratDate; 
            DateTime end = userDetail.MilkPreference.endDate;  


                  
            DateTime LoopDate = new DateTime();

            // if user logged before end date, logged date will be end date.
            if (LoginDate <= end)
            {
                LoopDate = LoginDate;
            }

            // if user logged on end date or after end date, end date will be end date.
            if (LoginDate >= end)
            {
                LoopDate = end;
            }
            if (start < nxtdate) 
            {
                start = nxtdate.AddDays(1);
            }
          
        // Find the difference between the two dates
        TimeSpan difference = LoopDate.Date - start.Date;
        int days = difference.Days;

        int add = 0;
        for (int i = 0; i < days; i++)
        {
            BillStructure Mybill = new BillStructure();

            Mybill.BillDate = start.AddDays(add++);
            Mybill.Quantity = userDetail.MilkPreference.Quantity;
            Mybill.BillAmount = userDetail.MilkPreference.BillAmount1;

            userDetail.BillList.Add(Mybill);
        }

        UpdateTextFile(userDetail);

        if (end.AddDays(1) < DateTime.Now)  // if user login after an end date
        {
            MessageBox.Show("You are Too Late...    " + "\n \n \n" + userDetail.ToString());
            this.Hide();
        }
        else
        { 
            SkipForm s = new SkipForm(userDetail);
            s.ShowDialog();
        }

            
        }

        public bool checkValidUser(string userid) //To check the userId on the Directory
        {
            string filePath = "C:\\MilkPrice\\" + userid + ".txt";
            bool IsExist = File.Exists(filePath);  // return a bool 
            return IsExist;
        }

        public void UpdateTextFile(UserDetail userDetail) // Create fileName as "userId" and store the userDetails(signIn class) and milkpreference 
        {
            StreamWriter file = new StreamWriter("C:\\MilkPrice\\" + userDetail.UserData.Userid + ".txt");
            file.Write(userDetail.ToString());
            file.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (checkValidUser(textBox1.Text) == true)
            {
                label2.Text=("Welcome " + textBox1.Text);
                label2.ForeColor = Color.Green;
                button1.Enabled = true;
            }
            else
            {
                label2.ForeColor = Color.Red;
                label2.Text = "User id " + textBox1.Text + " Not Found";
                button1.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

       

       
            
        
    }
}
