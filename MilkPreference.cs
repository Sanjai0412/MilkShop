using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MILK_SHOP
{
    public class MilkPreference
    {


        private string period;
        // Monthy , weekly

        public string Period
        {
            get { return period; }
            set { period = value; }
        }

        private string milktype;
        // low fat, fat free,high fat
        public string MilkType
        {
            get { return milktype; }
            set { milktype = value; }
        }

        private string brand;
        // Amul, Aawin , MilkyMist
        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }

        private string packtype;
        // packed , loose
        public string Packtype
        {
            get { return packtype; }
            set { packtype = value; }
        }

        private int quantity;
        // quantity of milk per day
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        private int BillAmount;

        public int BillAmount1
        {
            get { return BillAmount; }
            set { BillAmount = value; }
        }

        public DateTime stratDate;

        public DateTime StratDate
        {
            get { return stratDate; }
            set { stratDate = value; }
        }

        public DateTime endDate;

        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        public override string ToString()
        {
            return period+"|"+milktype+"|"+brand+"|"+packtype+"|"+quantity+"|"+BillAmount+"|"+stratDate.ToString()+"|"+endDate.ToString();
        }
    }
}
