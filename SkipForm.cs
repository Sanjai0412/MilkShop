using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MILK_SHOP
{
    public partial class SkipForm : Form
    {
        UserDetail userDetail;
        public int Total;
        
        public SkipForm(UserDetail user)
        {
            userDetail = user;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {  
        }

        public int QuanPrice(int quan) // To set the price for Ml of milk
        {
            int p = quan / 20;
            return p;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if (radioButton1.Checked)
            {
                BillStructure skip = new BillStructure();
                skip.BillDate = DateTime.Now;
                skip.Quantity =0;
                skip.BillAmount = 0;

                userDetail.BillList.Add(skip);

                MessageBox.Show(" Day " + skip.BillDate + " was Skipped ");

            }

            if (radioButton2.Checked)
            {
                BillStructure extra = new BillStructure();
                extra.BillDate = DateTime.Now;
                extra.Quantity += int.Parse(comboBox1.Text);
                extra.BillAmount += QuanPrice(extra.Quantity);

                userDetail.BillList.Add(extra);

                MessageBox.Show("Extra Milk " + comboBox1.Text + " ml Added");
            }

            UpdateTextFile(userDetail);

            this.Close();
        }

        public void UpdateTextFile(UserDetail userDetail)  // Create fileName as "userId" and store the userDetails(signIn class) and milkpreference 
        {
            StreamWriter file = new StreamWriter("C:\\MilkPrice\\" + userDetail.UserData.Userid + ".txt");
            file.Write(userDetail.ToString());
            file.Close();
        }

        public void SkipDay(DateTime start, DateTime end)
        {
            int add = 0;
            for (int i = start.Day; i < end.Day; i++)
            {
                BillStructure Mybill = new BillStructure();

                Mybill.BillDate = userDetail.MilkPreference.stratDate.AddDays(add++);
                Mybill.Quantity = userDetail.MilkPreference.Quantity;
                Mybill.BillAmount = userDetail.MilkPreference.BillAmount1;

                userDetail.BillList.Add(Mybill);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                button3.Enabled = true;
                comboBox1.Enabled = true;
            }
            else
            {
                button3.Enabled = false;
                comboBox1.Enabled = false;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Total will add if user logged in after the end date 
            Total = 0;
            string[] ar = File.ReadAllLines("C:\\MilkPrice\\" + userDetail.UserData.Userid + ".txt");
            for (int i = 2; i < ar.Length; i++)
            {
                string[] Bill = ar[i].ToString().Split('|');

                Total += int.Parse(Bill[2]);
            }
            Total t = new Total();
            t.Total1 = Total;

            // assigning t to Userdetail 

            userDetail.Total = t;

            MessageBox.Show(userDetail.ToString());
            this.Hide();
        }

        private void SkipForm_Load(object sender, EventArgs e)
        {
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                button3.Enabled = true;
            }
            else
            {
                button3.Enabled = false;
            }
        }
    }
}
