using BLL.Dtos;
using Data.Models;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using Utility.Commons;
using Utility.Enumerations;

namespace BLL.Services
{
    public class CustomerService
    {

        public List<Customer> List()
        {
            try
            {
                using (var customerData = new CustomerRepository())
                {
                    return customerData.List();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ApiResponseMessage Save(CustomerDto customer, int loggedInCustomerId)
        {
            var response = new ApiResponseMessage();

            try
            {
                Customer obj = new Customer();
                using (var customerData = new CustomerRepository())
                {
                    if (customer != null && customer.Id > 0)
                    {
                        obj = customerData.Get(customer.Id);
                    }

                    obj.FirstName = customer.FirstName;
                    obj.LastName = customer.LastName;
                    obj.Email = customer.Email;
                    obj.Phone = customer.Phone;
                    obj.City = customer.City;
                    obj.Address = customer.Address;
                    obj.ProfilePic = customer.ProfilePic;

                    if (customer.Id > 0)
                    {
                        obj.UpdatedOn = DateTime.Now;
                        obj.UpdatedBy = loggedInCustomerId;
                        customerData.Update(obj);
                    }
                    else
                    {
                        obj.CreatedBy = loggedInCustomerId;
                        obj.CreatedOn = DateTime.Now;
                        customerData.Add(obj);
                    }

                }
                response.Status = HttpStatusCode.OK;
                response.Message = "Customer saved successfully!";
                response.Response = obj;

            }
            catch (Exception ex)
            {
                response.Status = HttpStatusCode.InternalServerError;
                response.Message = "An Error has occured!";
                response.Response = false;
            }
            return response;
        }

        public Customer Get(int Id)
        {
            try
            {
                using (var customerData = new CustomerRepository())
                {
                    return customerData.Get(Id);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Delete(int ids)
        {
            try
            {
                using (var customerRepository = new CustomerRepository())
                {
                    return customerRepository.Delete(ids);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
