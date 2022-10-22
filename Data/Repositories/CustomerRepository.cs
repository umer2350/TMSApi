using Data.DataContext;
using Data.Models;
using Data.Utils;
using Utility.Commons;
using Utility.Enumerations;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Data.Repositories
{
    public class CustomerRepository : IDisposable
    {
        public Customer Add(Customer customer)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.Add(customer);
                    _context.SaveChanges();
                }

                return customer;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Customer Update(Customer customer)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.Update(customer);
                    _context.SaveChanges();
                }

                return customer;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    var customer = _context.Customers.Find(id);
                    _context.Customers.Remove(customer);
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Customer Get(int id)
        {
            try
            {
                using (var _context = Db.Create())
                {

                    return _context.Customers.FirstOrDefault(o => o.Id == id);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Customer GetByEmailAddress(string emailAddress)
        {
            try
            {
                using (var _context = Db.Create())
                {

                    return _context.Customers.FirstOrDefault(o => o.Email == emailAddress);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Customer> List()
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                using (var _context = Db.Create())
                {
                    customers = _context.Customers.ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return customers;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }

    }
}
