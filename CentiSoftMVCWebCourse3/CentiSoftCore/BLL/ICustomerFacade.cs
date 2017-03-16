using System.Collections.Generic;
using CentiSoftCore.MODELS;

namespace CentiSoftCore.BLL
{
    public interface ICustomerFacade
    {
        void DeleteCustomer(int id);
        List<Project> FindProjectsOnCusID(int cusId);
        List<Task> FindTasksOnProject(int id);
        List<Customer> LoadAllCustomers();
        Customer LoadCustomer(int id);
        void SaveCustomer(Customer customer);
    }
}