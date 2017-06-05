using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LindbakTask.Models;

namespace LindbakTask.Business
{
	/// <summary>
	/// Implementation of CustomerStorage, using a dictionary to store Customer objects.
	/// </summary>
	public class LocalCustomerStorage : CustomerStorage
	{
		// The dictionary.
		private Dictionary<int, Customer> Customers;
		// The next free id.
		private int NextId = 0;

		/// <summary>
		/// Create a new Local customer storage.
		/// </summary>
		public LocalCustomerStorage()
		{
			this.Customers = new Dictionary<int, Customer>();
		}

		public List<Customer> GetAllCustomers()
		{
			return this.Customers.Values.ToList<Customer>();
		}

		public Customer GetCustomer(int id)
		{
			return this.Customers.ContainsKey(id) ? this.Customers[id] : null;
		}

		public bool StoreCustomer(Customer customer)
		{
			if (customer.Id == -1) customer.Id = NextId++;
			else if (CustomerIdExists(customer.Id))
			{
				return false;
			}
			this.Customers.Add(customer.Id, customer);
			return true;
		}

		public bool RemoveCustomer(int id)
		{
			if (this.Customers.ContainsKey(id))
			{
				this.Customers.Remove(id);
				return true;
			}
			return false;
		}

		private bool CustomerIdExists(int id)
		{
			return this.Customers.ContainsKey(id);
		}

	}
}