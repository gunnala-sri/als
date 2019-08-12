using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperMarketRegisterService
{
    /// <summary>
    /// Represents the reciept of purchased items
    /// </summary>
    public class Receipt
    {
        /// <summary>
        /// List of purchased items
        /// </summary>
        private List<PurchaseItem> _purchaseItems;

        /// <summary>
        /// Tax percentage
        /// </summary>
        private int _taxPercentage;

        /// <summary>
        /// Instantiates the new object of type Receipt
        /// </summary>
        public Receipt()
        {
            _purchaseItems = new List<PurchaseItem>();
            _taxPercentage = 10;
        }

        /// <summary>
        /// Add purchase item
        /// </summary>
        /// <param name="quantity">Quantity of item</param>
        /// <param name="name">name of item</param>
        /// <param name="price">price of item</param>
        public void AddItem(int quantity, string name, double price)
        {
            _purchaseItems.Add(new PurchaseItem()
            {
                Quantity = quantity,
                Name = name,
                Price = price
            });
        }

        /// <summary>
        /// Provides detailed description of purchased items
        /// </summary>
        /// <returns>receipt description</returns>
        public override string ToString()
        {
            string receiptDescription = string.Empty;
            _purchaseItems.ForEach(p =>
            {
                receiptDescription = receiptDescription + p.Description + "\r\n";
            });

            receiptDescription = receiptDescription + "\tSubTotal = $" + string.Format("{0:N2}", getTotalPurchasePrice())  + "\r\n\t";
            receiptDescription = receiptDescription + "Tax (" + _taxPercentage + "%) = $" + string.Format("{0:N2}", getTax()) + "\r\n\t";
            receiptDescription = receiptDescription + "Total = $" + string.Format("{0:N2}", (getTotalPurchasePrice() + getTax()));

            return receiptDescription;
        }

        /// <summary>
        /// Gets tax amount on total purchase
        /// </summary>
        /// <returns></returns>
        private double getTax()
        {
            return Math.Round(((getTotalPurchasePrice() * _taxPercentage) / 100), 2);
        }

        /// <summary>
        /// Gets the total purchase
        /// </summary>
        /// <returns></returns>
        private double getTotalPurchasePrice()
        {
            if (!_purchaseItems.Any())
                return 0;

            return _purchaseItems.Sum(p => (p.Quantity * p.Price));
        }
    }
}
