using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace MILK_SHOP
{
   public  class UserDetail
    {


        UserData userData;

        public UserData UserData
        {
            get { return userData; }
            set { userData = value; }
        }

        MilkPreference milkPreference;

        public MilkPreference MilkPreference
        {
            get { return milkPreference; }
            set { milkPreference = value; }
        }

        Total total;

        public Total Total
        {
            get { return total; }
            set { total = value; }
        }

        List<BillStructure> billList;

        public List<BillStructure> BillList
        {
            get { return billList; }
            set { billList = value; }
        }
     
        public UserDetail()
        {
            UserData = new UserData();
            milkPreference = new MilkPreference();
            total = new Total();
            billList = new List<BillStructure>();
        }

        
        

        public override string ToString()
        {
            string firstLine= userData.ToString() + "|" + milkPreference.ToString() ;
            string secondLine = total.ToString();
            string thirdLine = "";
            for (int i = 0; i < billList.Count; i++)
            {
                thirdLine += billList[i].ToString() + "\n";
            }

            string bill = firstLine + "\n"+secondLine+"\n"+thirdLine;
            return bill;
        }
        

    }
}
