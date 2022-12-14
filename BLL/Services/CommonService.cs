using BLL.Dtos;
using Data.Repositories.Common;
using System;
using System.Linq;

namespace BLL.Services
{
    public class CommonService
    {
        public object Countries()
        {
            var countries = new CommonRepository().ListCountries();
            var result  = countries.Select(x => new SelectListDto()
            {
                Value = x.Id,
                Text = x.Name,
            }).ToList();
            return result;
        }
        public object Workers()
        {
            var countries = new CommonRepository().ListWorker();
            var result  = countries.Select(x => new SelectListDto()
            {
                Value = x.Id,
                Text = x.FirstName + x.LastName,
            }).ToList();
            return result;
        }
        public object Customers()
        {
            var countries = new CommonRepository().ListCustomer();
            var result  = countries.Select(x => new SelectListDto()
            {
                Value = x.Id,
                Text = x.FirstName + x.LastName,
            }).ToList();
            return result;
        }

        public object States(int countryid)
        {
            var states = new CommonRepository().ListStates(countryid);
            var result = states.Select(x => new SelectListDto()
            {
                Value = x.Id,
                Text = x.Name
            }).ToList();
            return result;
        }

        public object Cities(int stateId)
        {
            var cities = new CommonRepository().ListCities(stateId);
            var result = cities.Select(x => new SelectListDto()
            {
                Value = x.Id,
                Text = x.Name
            }).ToList();
            return result;
        }

    }
}
