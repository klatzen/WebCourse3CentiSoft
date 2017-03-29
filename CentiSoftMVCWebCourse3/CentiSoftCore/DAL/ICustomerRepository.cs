using System.Collections.Generic;
using CentiSoftCore.MODELS;

namespace CentiSoftCore.DAL
{
    public interface ICustomerRepository
    {
        Customer CustomersOnClient(int id);
        List<Customer> FindCustomersOnClient(int id);
        List<Customer> LoadAllCustomers(int clientId);
        Customer LoadCustomer(int id, int clientId);
        void RemoveCustomer(int id, int clientId);
        void SaveCustomer(Customer customer);
    }
}