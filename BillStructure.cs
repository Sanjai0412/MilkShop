using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MILK_SHOP
{
    public class BillStructure
    {

        DateTime billDate;

        public DateTime BillDate
        {
            get { return billDate; }
            set { billDate = value; }
        }

        int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        int billAmount;

        public int BillAmount
        {
            get { return billAmount; }
            set { billAmount = value; }
        }

        private int total;

        public int Total
        {
            get { return total; }
            set { total = value; }
        }

        public override string ToString()
        {
            return billDate.ToString()+"|"+quantity+"|"+BillAmount;
        }


    }
}
