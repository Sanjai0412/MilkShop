using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MILK_SHOP
{
    public class UserData
    {

        private string name;


        public string Name1
        {
            get { return name; }
            set { name = value; }
        }

        private string userid;

        public string Userid
        {
            get { return userid; }
            set { userid = value; }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }


        public override string ToString()
        {
            return   name + "|" + userid + "|" + email + "|" + address;
        }

    }
}
