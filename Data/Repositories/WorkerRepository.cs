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
    public class WorkerRepository : IDisposable
    {
        public Worker Add(Worker worker)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.Add(worker);
                    _context.SaveChanges();
                }

                return worker;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Worker Update(Worker worker)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.Update(worker);
                    _context.SaveChanges();
                }

                return worker;
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
                    var worker = _context.Workers.Find(id);
                    _context.Workers.Remove(worker);
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Worker Get(int id)
        {
            try
            {
                using (var _context = Db.Create())
                {

                    return _context.Workers.FirstOrDefault(o => o.Id == id);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Worker GetByEmailAddress(string emailAddress)
        {
            try
            {
                using (var _context = Db.Create())
                {

                    return _context.Workers.FirstOrDefault(o => o.Email == emailAddress);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Worker> List()
        {
            List<Worker> workers = new List<Worker>();
            try
            {
                using (var _context = Db.Create())
                {
                    workers = _context.Workers.ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return workers;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }

    }
}
