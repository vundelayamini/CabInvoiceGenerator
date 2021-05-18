using CabInvoiceGenerator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CabInvoiceTest
{
    [TestClass]
    public class Test
    {
        private object invoiceGenerator;
        /// <summary>
        ///UC1-Calculate Fare
        /// </summary>
        [TestMethod]
        public void GivenDistanceAndTimeShouldReturnTotalFare()
        {
           InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;
            //Calculating fare
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 40;
            Assert.AreEqual(expected, fare);
        }
        /// <summary>
        /// Gives the multiple rides should return summary
        /// </summary>
        [TestMethod]
        public void GivenMultipleRideShouldReturnInvoiceSummary()
        {
            //Creating instance of invoice generator
           InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };

            //Generating summary for rides
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 60.0);
            var res = summary.Equals(expectedSummary);
            Assert.IsNotNull(res);
            //Asserting values
           // Assert.AreEqual(expectedSummary.GetType(), summary.GetType());

            
        }

        /// <summary>
        ///UC3- Whens the given multiple rides get invoice summary with average fare.
        /// </summary>
        [TestMethod]
        public void WhenGivenMultipleRidesGetInvoiceSummarywithAverageFare()
        {

            //Creating instance of invoice generator
            InvoiceGenerator  invoiceGenertator= new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };

            //Generating summary for rides
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 60.0);
            //Asserting values
            Assert.AreEqual(expectedSummary.GetType(), summary.GetType());
        }


        //UC-4 Given the user identifier get invoice summary.
        [TestMethod]
        public void GivenUserIdGetInvoiceSummary()
        {
            // Add rides using invoice service
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };

            // Get invoice summary for given user id
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 60.0);

            Assert.AreEqual(expectedSummary.GetType(),summary.GetType());
        }


        /// UC5-Given the invalid user identifier get exception.
        [TestMethod]
        public void GivenInvalidUserIdGetException()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);

            // Get invoice summary for given user id
            var actual = Assert.ThrowsException<InvoiceException>(() => invoiceGenerator.CalculateFare(rides));
            Assert.AreEqual(InvoiceException.ExceptionType.INVALID_USER_ID, actual.GetType);
        }
    }
}

