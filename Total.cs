using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MILK_SHOP
{
    public class Total
    {
        private int total;

        public int Total1
        {
            get { return total; }
            set { total = value; }
        }

        public override string ToString()
        {
            return "Total : "+"|"+total.ToString();
        }
    }
}
