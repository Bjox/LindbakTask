using Microsoft.VisualStudio.TestTools.UnitTesting;
using LindbakTask.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LindbakTask.Models;

namespace LindbakTask.Business.Tests
{
	[TestClass()]
	public class LocalCustomerStorageTests
	{
		[TestMethod()]
		public void GetAllCustomersTest()
		{
			// arrange
			LocalCustomerStorage Storage = new LocalCustomerStorage();

			Customer Bob = new Customer();
			Bob.FirstName = "Bob";
			Bob.LastName = "Bobsen";
			Bob.Address = "Bobsenstreet 1";
			Bob.PostalCode = "7000";
			Bob.Country = "Norway";

			Customer Alice = new Customer();
			Alice.FirstName = "Alice";
			Alice.LastName = "Allison";
			Alice.Address = "Alicestreet 5";
			Alice.PostalCode = "7450";
			Alice.Country = "Norway";

			Storage.StoreCustomer(Bob);
			Storage.StoreCustomer(Alice);

			// act
			List<Customer> Customers = Storage.GetAllCustomers();

			// assert
			Assert.IsTrue(Customers.Contains(Bob));
			Assert.IsTrue(Customers.Contains(Alice));
			Assert.AreEqual(Customers.Count, 2);
		}

		[TestMethod()]
		public void GetCustomerTest()
		{
			// arrange
			LocalCustomerStorage Storage = new LocalCustomerStorage();

			Customer Bob = new Customer();
			Bob.FirstName = "Bob";
			Bob.LastName = "Bobsen";
			Bob.Address = "Bobsenstreet 1";
			Bob.PostalCode = "7000";
			Bob.Country = "Norway";

			Storage.StoreCustomer(Bob);

			// act
			Customer Someone = Storage.GetCustomer(Bob.Id);

			// assert
			Assert.AreEqual(Bob, Someone);
		}

		[TestMethod()]
		public void StoreCustomerTest()
		{
			// arrange
			LocalCustomerStorage Storage = new LocalCustomerStorage();

			Customer Bob = new Customer();
			Bob.FirstName = "Bob";
			Bob.LastName = "Bobsen";
			Bob.Address = "Bobsenstreet 1";
			Bob.PostalCode = "7000";
			Bob.Country = "Norway";

			Customer Alice = new Customer();
			Alice.FirstName = "Alice";
			Alice.LastName = "Allison";
			Alice.Address = "Alicestreet 5";
			Alice.PostalCode = "7450";
			Alice.Country = "Norway";

			// act
			Storage.StoreCustomer(Bob);
			Storage.StoreCustomer(Alice);

			// assert
			Assert.AreNotEqual(Bob.Id, Alice.Id);
			List<Customer> Customers = Storage.GetAllCustomers();
			Assert.IsTrue(Customers.Contains(Bob));
			Assert.IsTrue(Customers.Contains(Alice));
			Assert.AreEqual(Customers.Count, 2);
		}

		[TestMethod()]
		public void RemoveCustomerTest()
		{
			// arrange
			LocalCustomerStorage Storage = new LocalCustomerStorage();

			Customer Bob = new Customer();
			Bob.FirstName = "Bob";
			Bob.LastName = "Bobsen";
			Bob.Address = "Bobsenstreet 1";
			Bob.PostalCode = "7000";
			Bob.Country = "Norway";

			Customer Alice = new Customer();
			Alice.FirstName = "Alice";
			Alice.LastName = "Allison";
			Alice.Address = "Alicestreet 5";
			Alice.PostalCode = "7450";
			Alice.Country = "Norway";

			Storage.StoreCustomer(Bob);
			Storage.StoreCustomer(Alice);

			// act & assert
			Storage.RemoveCustomer(Bob.Id);
			Assert.IsNull(Storage.GetCustomer(Bob.Id));
			Storage.RemoveCustomer(Alice.Id);
			Assert.IsNull(Storage.GetCustomer(Alice.Id));
		}
	}
}