using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarketRegisterService
{
    public class PurchaseItem
    {
        public int Quantity { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Description
        {
            get
            {
                return Quantity + " " + Name + " @ $" + string.Format("{0:N2}", Price)  + " = $" +
                    string.Format("{0:N2}", (Quantity * Price));
            }
        }
    }
}
