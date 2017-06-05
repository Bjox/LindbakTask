using LindbakTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LindbakTask.Business;
using System.Web;

namespace LindbakTask.Controllers
{
    public class CustomerRegisterController : ApiController
    {
		private CustomerStorage Storage = (CustomerStorage) HttpContext.Current.Cache["CustomerStorage"];

        public IEnumerable<Customer> GetAllCustomers()
        {
			return Storage.GetAllCustomers();
        }

        public Customer GetCustomer(int id)
        {
			return Storage.GetCustomer(id);
        }

        public int AddCustomer([FromBody]Customer customer)
        {
			if (Storage.StoreCustomer(customer))
			{
				return customer.Id;
			}
			return -1;
        }

        public void RemoveCustomer([FromBody]Customer customer)
        {
			Storage.RemoveCustomer(customer.Id);
        }
    }
}
