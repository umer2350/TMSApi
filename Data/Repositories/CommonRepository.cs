﻿using Data.DataContext;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories.Common
{
    public class CommonRepository
    {
        public List<Country> ListCountries()
        {
            try
            {
                using (var _context = Db.Create())
                {
                    return _context.Countries.ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<Worker> ListWorker()
        {
            try
            {
                using (var _context = Db.Create())
                {
                    return _context.Workers.ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<Customer> ListCustomer()
        {
            try
            {
                using (var _context = Db.Create())
                {
                    return _context.Customers.ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<State> ListStates(int countryId)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    return _context.States.Where(o => o.CountryId == countryId).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<City> ListCities(int stateId)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    return _context.Cities.Where(o => o.StateId == stateId).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
