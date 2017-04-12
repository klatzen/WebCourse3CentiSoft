using CentiSoftCore.BLL;
using CentiSoftCore.MODELS;
using CentiSoftMVCWebCourse3.Controllers;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace CentiSoftMVCWebCourse3.API
{
    public class CustomerController: ApiController
    {
        [HttpGet]
        [Security]
        public List<Customer> GetAllCustomers()
        {
            object id;
            Request.Properties.TryGetValue("id", out id);
            List<Customer> customers = null;
            if(id != null)
            {
                ICustomerFacade cusFacade = new CustomerFacade((int)id);
                customers = cusFacade.LoadAllCustomers();
            }
            return customers;
        }
        [HttpGet]
        [Security]
        public Customer GetCustomer(int id)
        {
            object ClientId;
            Request.Properties.TryGetValue("id", out ClientId);
            Customer customer = null;
            if(ClientId != null)
            {
                ICustomerFacade cusFacade = new CustomerFacade((int)ClientId);
                customer = cusFacade.LoadCustomer(id);
            }
            return customer;
        }

        [HttpPost,HttpPut]
        [Security]
        public void PostCustomer([FromBody] Customer customer)
        {
            object ClientId;
            Request.Properties.TryGetValue("id", out ClientId);
            if(ClientId != null)
            {
                ICustomerFacade cusFacade = new CustomerFacade((int)ClientId);
                cusFacade.SaveCustomer(customer);
            }
            
        }
        [HttpDelete]
        [Security]
        public void GetAllCustomers(int id)
        {
            object ClientId;
            Request.Properties.TryGetValue("id", out ClientId);
            if(ClientId != null)
            {
                ICustomerFacade cusFacade = new CustomerFacade((int)ClientId);
                cusFacade.DeleteCustomer(id);
            }
            
        }

    }
}
