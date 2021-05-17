namespace CabInvoiceGenerator
{

    /// <summary>
    /// Invoice summary generates number of rides, total fare
    /// also generates average for summary
    /// </summary>
    public class InvoiceSummary
    {
        private int numberOfRides;
        private double totalFare;
        private double averageFare;
        /// <summary>
        ///UC 3 Initializes a new instance of the <see cref="InvoiceSummary"/>class
        ///Initializes number of rides, total fare and generates average fare for rides
        /// </summary>
        /// <param name="numberOfRides"></param>
        /// <param name="totalFare"></param>
        public InvoiceSummary(int numberOfRides, double totalFare)
        {
            this.numberOfRides = numberOfRides;
            this.totalFare = totalFare;
            this.averageFare = this.totalFare / this.numberOfRides;
        }
        /// <summary>
        ///Equalses the specified invoice summary
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is InvoiceSummary))
            {
                return false;
            }
        
            InvoiceSummary inputObject = (InvoiceSummary)obj;
            return this.numberOfRides == inputObject.numberOfRides && this.totalFare == inputObject.totalFare && this.averageFare == inputObject.averageFare;
        }
        
    }
}
    