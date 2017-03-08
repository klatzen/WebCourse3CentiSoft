using CentiSoftCore.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentiSoftCore.DAL
{
   public class CustomerRepository : BaseRepository
    {

        public Customer loadCustomer(int id) {
            Customer cust = dbContext.Customers.FirstOrDefault(x => x.Id == id);
            return cust;
        }

        public List<Customer> LoadAllCustomers() {
            List<Customer> custList = dbContext.Customers.ToList();
            return custList;
        }

        public void saveCustomer(Customer customer) {
            if (customer.Id > 0) {
                Customer cust = loadCustomer(customer.Id);
                cust.Name = customer.Name;
                cust.Address = customer.Address;
                cust.Phone = customer.Phone;
                
            }
            else
            {
                dbContext.Customers.Add(customer);
            }
            dbContext.SaveChanges();
        }

        public Customer CustomersOnClient(int id)
        {
            return dbContext.Customers.FirstOrDefault(x => x.ClientId == id);
        }

        public void removeCustomer(Customer customer) {

            dbContext.Customers.Remove(customer);
        }
    }
}
