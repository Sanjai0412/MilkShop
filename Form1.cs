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
    public partial class Form1 : Form
    {
        public static int price;
        DateTime startDate;
        DateTime endDate;
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void label9_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateDirectory("C:\\MilkPrice");

            // if user did'nt pick the date from datetimepicker , Automatically it take today's date
            if (dateTimePicker1.Checked==true)
            {
                startDate = dateTimePicker1.Value.Date;
            }
            else
            {
                startDate = DateTime.Now;
            }

            UserData user = new UserData();
            user.Name1 = textBox1.Text;
            user.Userid = textBox2.Text;
            user.Email = textBox3.Text;
            user.Address = textBox4.Text;

            if (checkValidUser(user.Userid) == true)
            {
                label3.Text = ("User Id " + user.Userid + " was Already Exists");
            }

            MilkPreference milkPref = new MilkPreference();

            if (radioButton1.Checked == true)
            {
                milkPref.Period = radioButton1.Text;
                endDate = startDate.AddDays(7);

            }
            else if (radioButton2.Checked == true)
            {
                milkPref.Period = radioButton2.Text;
                endDate = startDate.AddDays(30);
            }

            milkPref.StratDate = startDate;
            milkPref.EndDate = endDate;


            if (radioButton3.Checked == true)
            {
                milkPref.Packtype = radioButton3.Text;
                milkPref.BillAmount1 += 20;
            }
            else if (radioButton4.Checked == true)
            {
                milkPref.Packtype = radioButton4.Text;
            }
            
            milkPref.Brand = comboBox1.Text;
            milkPref.BillAmount1 += BrandPrice(milkPref.Brand);

            milkPref.MilkType = comboBox2.Text;
            milkPref.BillAmount1 += MilkTypePrice(milkPref.MilkType);

            milkPref.Quantity = int.Parse(comboBox3.Text);
            milkPref.BillAmount1 += QuanPrice(milkPref.Quantity);

           
            UserDetail userDetail = new UserDetail(); // create an object using Parent Class (userDetails) and Add the child class objects to Parent class object 
            userDetail.UserData = user;
            userDetail.MilkPreference = milkPref;
            

            CreateTextFile(userDetail);
            MessageBox.Show(" Sign in Completed ");

            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }

        public int QuanPrice(int quan) // To set the price for Ml of milk
        {
            int p = quan / 20;
            return p;
        }

        public int MilkTypePrice(string type)  // To set the price for Various types of milk
        {
            if (type == "Low Fat")
            {
                price = 20;
            }
            else if (type == "Fat Free")
            {
                price = 10;
            }
            else if (type == "High Fat")
            {
                price = 20;
            }
            return price;
        }

        public int BrandPrice(string brand) // To set the Price for various Brands 
        {
            if (brand == "Aawin")
            {
                price = 5;
            }
            else if (brand == "Amul")
            {
                price = 5;
            }
            else if (brand == "MilkyMist")
            {
                price = 10;
            }
            return price;
        }

        public void CreateTextFile(UserDetail userDetail) // Create fileName as "userId" and store the userDetails(signIn class) and milkpreference 
        {
            StreamWriter file = new StreamWriter("C:\\MilkPrice\\" + userDetail.UserData.Userid +".txt");
            file.Write(userDetail.ToString());
            file.Close();
        }

        public bool checkValidUser(string userid) //To check the userId on the Directory
        {
            string filePath = "C:\\MilkPrice\\" + userid + ".txt";
            bool IsExist = File.Exists(filePath);  // return a bool 
            return IsExist;
        }

        
        public void CreateDirectory(string path)  // to create folder in the given Path
        {
            Directory.CreateDirectory(path);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
            }
            else
            {
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text != "")
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

    }
}
