using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using LindbakTask.Business;
using LindbakTask.Models;

namespace LindbakTask
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
			CustomerStorage Storage = new LocalCustomerStorage();
			HttpContext.Current.Cache["CustomerStorage"] = Storage;

			// Lets add some dummy-customers
			Customer BobCustomer = new Customer();
			BobCustomer.FirstName = "Bob";
			BobCustomer.LastName = "Bobsen";
			BobCustomer.Address = "Bobsenstreet 1";
			BobCustomer.PostalCode = "7000";
			BobCustomer.Country = "Norway";

			Customer AliceCustomer = new Customer();
			AliceCustomer.FirstName = "Alice";
			AliceCustomer.LastName = "Allison";
			AliceCustomer.Address = "Alicestreet 5";
			AliceCustomer.PostalCode = "7450";
			AliceCustomer.Country = "Norway";

			Storage.StoreCustomer(BobCustomer);
			Storage.StoreCustomer(AliceCustomer);
		}
    }
}
