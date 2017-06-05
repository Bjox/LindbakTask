function Customer(firstName, lastName, address, postalCode, country, id) {
	var self = this;
	self.firstName = ko.observable(firstName);
	self.lastName = ko.observable(lastName);
	self.address = ko.observable(address);
	self.postalCode = ko.observable(postalCode);
	self.country = ko.observable(country);
	self.id = id;
}

function AppViewModel() {
	var self = this;

	self.customers = ko.observableArray();

	self.removeCustomer = function (customer) {
		$.post("/api/CustomerRegister/RemoveCustomer", customer, function (result) {
			self.customers.remove(customer);
		})
	}

	self.newFirstName = ko.observable();
	self.newLastName = ko.observable();
	self.newAddress = ko.observable();
	self.newPostalCode = ko.observable();
	self.newCountry = ko.observable();

	self.addCustomer = function () {
		var newCustomer = new Customer(this.newFirstName(), this.newLastName(), this.newAddress(), this.newPostalCode(), this.newCountry(), -1);

		self.newFirstName("");
		self.newLastName("");
		self.newAddress("");
		self.newPostalCode("");
		self.newCountry("");

		$.post("/api/CustomerRegister/AddCustomer", newCustomer, function (returnedId) {
			newCustomer.id = returnedId;
			self.customers.push(newCustomer);
		})
	}

	fetchCustomers(this);
}

function fetchCustomers(viewModel) {
	$.getJSON("/api/CustomerRegister/GetAllCustomers", function (data, status) {
		var list = [];
		for (i in data) {
			var customer = data[i];
			list.push(new Customer(
				customer.FirstName,
				customer.LastName,
				customer.Address,
				customer.PostalCode,
				customer.Country,
				customer.Id
			));
		}
		viewModel.customers(list);
	});
}

ko.applyBindings(new AppViewModel());
