using CentiSoftCore.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentiSoftCore.DAL
{
   public class CustomerRepository : BaseRepository, ICustomerRepository
    {

        public Customer LoadCustomer(int id, int clientId) {
            Customer cust = dbContext.Customers.Where(x => x.ClientId == clientId).FirstOrDefault(x => x.Id == id);
            return cust;
        }

        public List<Customer> LoadAllCustomers(int clientId) {
            List<Customer> custList = dbContext.Customers.Where(x => x.ClientId == clientId).ToList();
            return custList;
        }

        public void SaveCustomer(Customer customer) {
            if (customer.Id > 0) {
                Customer cust = LoadCustomer(customer.Id, customer.ClientId);
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

        public void RemoveCustomer(int id, int clientId) {
            Customer customer = LoadCustomer(id, clientId);
            dbContext.Customers.Remove(customer);
        }

        public List<Customer> FindCustomersOnClient(int id)
        {
            return dbContext.Customers.Where(x => x.ClientId == id).ToList();
        }
    }
}
