namespace SuperMarketRegisterService
{
    /// <summary>
    /// A class repesent purchase item model
    /// </summary>
    public class PurchaseItem
    {
        /// <summary>
        /// Gets or sets the value of quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the value of Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the value of price
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Gets the purchased item description with quantity and price
        /// </summary>
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
