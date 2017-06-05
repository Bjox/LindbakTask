using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LindbakTask.Models
{
	/// <summary>
	/// A customer with name, address and storage ID.
	/// </summary>
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
		public int Id { get; set; } = -1;
    }
}