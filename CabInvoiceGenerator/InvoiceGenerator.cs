using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    /// <summary>
    /// Invoice generator class to calculate total fare of a trip
    /// </summary>
    public class InvoiceGenerator
    {
        //variables
        RideType rideType;
        private RideRepository rideRepository;
        //Constants
        private readonly double MINIMUM_COST_PER_KM;
        private readonly int COST_PER_TIME;
        private readonly double MINIMUM_FARE;
        /// <summary>
        /// Initializes a new instance of a the <see cref="InvoiceGenerator"/>class.
        /// </summary>
        /// <param name="rideType"></param>
        public InvoiceGenerator(RideType rideType)
        {
            this.rideType = rideType;
            this.rideRepository = new RideRepository();
            try
            {
                if (rideType.Equals(RideType.PREMIUM))
                {
                    this.MINIMUM_COST_PER_KM = 15;
                    this.COST_PER_TIME = 2;
                    this.MINIMUM_FARE = 20;
                }
                else if (rideType.Equals(RideType.NORMAL))
                {
                    this.MINIMUM_COST_PER_KM = 10;
                    this.COST_PER_TIME = 1;
                    this.MINIMUM_FARE = 5;
                }

            }
            catch (InvoiceException)
            {
                throw new InvoiceException(InvoiceException.ExceptionType.INVALID_RIDE_TYPE, "Invalid ride type");
            }
        }
        /// <summary>
        /// calculate the fare
        /// Invalid distance
        /// or
        /// Invalid time
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public double CalculateFare(double distance, int time)
        {
            double totalFare = 0;
            try
            {
                totalFare = distance * MINIMUM_COST_PER_KM + time * COST_PER_TIME;
            }
            catch (InvoiceException)
            {
                if (rideType.Equals(null))
                {
                    throw new InvoiceException(InvoiceException.ExceptionType.INVALID_RIDE_TYPE, "Invalid ride type");
                }
                if (distance <= 0)
                {
                    throw new InvoiceException(InvoiceException.ExceptionType.INVALID_DISTANCE, "Invalid distance");
                }
                if (time < 0)
                {
                    throw new InvoiceException(InvoiceException.ExceptionType.INVALID_TIME, "Invalid time");
                }
            }
            return Math.Max(totalFare, MINIMUM_FARE);
        }

        /// <summary>
        /// Calculate the fare for array of rides
        /// </summary>
        /// <param name="rides"></param>
        /// <returns></returns>
        public InvoiceSummary CalculateFare(Ride[] rides)
        {
            double totalFare = 0;
            //Checks for rides available and passes time to calculate fare method to calculate fare for each method
            try
            {
                //Calculating total fare for all rides
                foreach (Ride ride in rides)
                {
                    totalFare += this.CalculateFare(ride.distance, ride.time);

                }
            }
            //catches exception
            catch (InvoiceException)
            {
                if (rides == null)
                {
                    throw new InvoiceException(InvoiceException.ExceptionType.NULL_RIDES, "rides are null");
                }

            }
            //returns invoice summary object
            return new InvoiceSummary(rides.Length, totalFare);
        }
        /// <summary>
        /// Adds the rides in dictionary with key as a user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public void AddRides(String userId,Ride[] rides)
        {
            try
            {
              rideRepository.AddRide(userId,rides);
            }
            catch (InvoiceException)
            {
                throw new InvoiceException(InvoiceException.ExceptionType.INVALID_USER_ID, "Invalid user id");
            }
        }
    }
}


