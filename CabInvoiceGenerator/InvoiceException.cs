using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    /// <summary>
    /// Custom Exception for cab invoice program
    /// </summary>
    class InvoiceException:Exception
    {
        /// <summary>
        /// Enum for defining different type of custom exception
        /// </summary>
       public ExceptionType type;
        public enum ExceptionType
        {
            INVALID_RIDE_TYPE,
            INVALID_DISTANCE,
            INVALID_TIME,
            NULL_RIDES,
            INVALID_USER_ID
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceExceptipon"/>class.
        /// </summary>
        public InvoiceException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}

