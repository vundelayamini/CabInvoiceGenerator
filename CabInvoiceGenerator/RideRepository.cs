using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    class RideRepository
    {
        //Dictionary to store userid and ride list.
        Dictionary<string, List<Ride>> userRides = null;
        /// <summary>
        /// Initializes a new instance of the <see cref="RideRepository/">class.
        /// </summary>
        public RideRepository()
        {
            this.userRides = new Dictionary<string, List<Ride>>();
        }
        /// <summary>
        /// UC4-Adds the Ride of a customer in list and then to a dictionary with user id as a  
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="rides"></param>
        public void AddRide(string userId, Ride[] rides)
        {
            bool rideList = this.userRides.ContainsKey(userId);
            try
            {
                if (!rideList)
                {
                    List<Ride> list = new List<Ride>();
                    list.AddRange(rides);
                    this.userRides.Add(userId, list);
                }
            }
            catch (InvoiceException)
            {
                throw new InvoiceException(InvoiceException.ExceptionType.NULL_RIDES, "Rides are null");
            }
        }

        public Ride[] getRides(string userId)
        {
            bool rideList = this.userRides.ContainsKey(userId);
            try
            {
                return this.userRides[userId].ToArray();
            }
            catch (Exception)
            {
                throw new InvoiceException(InvoiceException.ExceptionType.INVALID_USER_ID, "Invalid user ID");
            }
        }

    }
}

    