using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LindbakTask.Models;

namespace LindbakTask.Business
{
	/// <summary>
	/// Interface describing a customer storage.
	/// </summary>
	interface CustomerStorage
	{
		/// <summary>
		/// Gets a single customer from the storage.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Customer GetCustomer(int id);

		/// <summary>
		/// Store a customer. Also sets the Id field of the customer.
		/// </summary>
		/// <param name="customer"></param>
		/// <returns></returns>
		bool StoreCustomer(Customer customer);

		/// <summary>
		/// Returns a List containing all customers in the storage.
		/// </summary>
		/// <returns></returns>
		List<Customer> GetAllCustomers();

		/// <summary>
		/// Remove a customer from the storage.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		bool RemoveCustomer(int id);
	}
}
