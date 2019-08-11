using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperMarketRegisterService
{
    public class Receipt
    {
        private List<PurchaseItem> purchaseItems;

        private int taxPercentage;

        public Receipt()
        {
            purchaseItems = new List<PurchaseItem>();
            taxPercentage = 10;
        }

        public void AddItem(int quantity, string name, double price)
        {
            purchaseItems.Add(new PurchaseItem()
            {
                Quantity = quantity,
                Name = name,
                Price = price
            });
        }

        public override string ToString()
        {
            string receiptDescription = string.Empty;
            purchaseItems.ForEach(p =>
            {
                receiptDescription = receiptDescription + p.Description + "\r\n";
            });

            receiptDescription = receiptDescription + "\tSubTotal = $" + string.Format("{0:N2}", getTotalPurchasePrice())  + "\r\n\t";
            receiptDescription = receiptDescription + "Tax (" + taxPercentage + "%) = $" + string.Format("{0:N2}", getTax()) + "\r\n\t";
            receiptDescription = receiptDescription + "Total = $" + string.Format("{0:N2}", (getTotalPurchasePrice() + getTax()));

            return receiptDescription;
        }

        private double getTax()
        {
            return Math.Round(((getTotalPurchasePrice() * taxPercentage) / 100), 2);
        }

        private double getTotalPurchasePrice()
        {
            if (!purchaseItems.Any())
                return 0;

            return purchaseItems.Sum(p => (p.Quantity * p.Price));
        }
    }
}
