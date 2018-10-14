using CarMastery.Data.Interfaces;
using CarMastery.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Data.SampleData
{
    public class CustomersRepositorySampleData : ICustomersRepository
    {
        public static List<Customers> _Customers = new List<Customers>
        {
            new Customers
            { CustomerId = 1, StateId = "IL", CustomerFirstName = "Jill", CustomerLastName = "Jones", CustomerPhone = "111-111-1111", CustomerEmail = "jilljones@customertest1.com",
               CustomerStreet1 = "Test1 Street1", CustomerStreet2 = "", CustomerCity = "Test1City", CustomerZipCode = "11111" },
            new Customers
            { CustomerId = 2, StateId = "MO", CustomerFirstName = "Joe", CustomerLastName = "Baker", CustomerPhone = "222-222-2222", CustomerEmail = "joebaker@customertest2.com",
               CustomerStreet1 = "Test2 Street1", CustomerStreet2 = "Test2 Street2", CustomerCity = "Test2City", CustomerZipCode = "22222" },
           new Customers
            { CustomerId = 3, StateId = "IA", CustomerFirstName = "Jane", CustomerLastName = "Doe", CustomerPhone = "333-333-3333", CustomerEmail = "janedoe@customertest3.com",
               CustomerStreet1 = "Test3 Street1", CustomerStreet2 = "", CustomerCity = "Test3City", CustomerZipCode = "33333" },
           new Customers
            { CustomerId = 4, StateId = "MO", CustomerFirstName = "John", CustomerLastName = "Smith", CustomerPhone = "444-444-4444", CustomerEmail = "johnsmith@customertest4.com",
               CustomerStreet1 = "Test4 Street1", CustomerStreet2 = "Test4 Street2", CustomerCity = "Test4City", CustomerZipCode = "44444" }
        };

        public void AddCustomer(Customers customer)
        {
            customer.CustomerId = _Customers.Max(c => c.CustomerId) + 1;
            _Customers.Add(customer);
        }

        public List<Customers> GetAllCustomers()
        {
            List<Customers> list = new List<Customers>();

            foreach (var customer in _Customers)
            {
                Customers currentRow = new Customers();

                currentRow.CustomerId = customer.CustomerId;
                currentRow.StateId = customer.StateId;
                currentRow.CustomerFirstName = customer.CustomerFirstName; 
                currentRow.CustomerLastName = customer.CustomerLastName;
                currentRow.CustomerPhone = customer.CustomerPhone; 
                currentRow.CustomerEmail = customer.CustomerEmail; 
                currentRow.CustomerStreet1 = customer.CustomerStreet1;
                currentRow.CustomerStreet2 = customer.CustomerStreet2; 
                currentRow.CustomerCity = customer.CustomerCity; 
                currentRow.CustomerZipCode = customer.CustomerZipCode;

                list.Add(currentRow);
            }
            return list;
        }

        public void DeleteCustomer (int customerId)
        {
            _Customers.RemoveAll(c => c.CustomerId == customerId);
        }
    }
}
