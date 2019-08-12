using SuperMarketRegisterService;
using System;
using Xunit;

namespace SuperMarketRegisterTest
{
    /// <summary>
    /// Test class to test business logic in Receipt
    /// </summary>
    public class TestReceipt
    {
        /// <summary>
        /// Verifies reciept description
        /// </summary>
        [Fact]
        public void ReceiptDescriptionTest()
        {
            var receipt = new Receipt();
            receipt.AddItem(1, "Candy Bar", 0.50);
            receipt.AddItem(2, "Soda", 1);
            var expected =
               @"1 Candy Bar @ $0.50 = $0.50
2 Soda @ $1.00 = $2.00
	SubTotal = $2.50
	Tax (10%) = $0.25
	Total = $2.75";
            Assert.Equal(expected, receipt.ToString());

        }
    }
}
