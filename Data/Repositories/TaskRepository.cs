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
    public class TaskRepository : IDisposable
    {
        public Task Add(Task task)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.Add(task);
                    _context.SaveChanges();
                }

                return task;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task Update(Task task)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.Update(task);
                    _context.SaveChanges();
                }

                return task;
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
                    var task = _context.Tasks.Find(id);
                    _context.Tasks.Remove(task);
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Task Get(int id)
        {
            try
            {
                using (var _context = Db.Create())
                {

                    return _context.Tasks.FirstOrDefault(o => o.Id == id);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<Task> List()
        {
            List<Task> tasks = new List<Task>();
            try
            {
                using (var _context = Db.Create())
                {
                    tasks = _context.Tasks.ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return tasks;
        }
        public List<TaskFile> TaskFilesList(int taskId)
        {
            List<TaskFile> tasks = new List<TaskFile>();
            try
            {
                using (var _context = Db.Create())
                {
                    tasks = _context.TaskFiles.Where(o => o.TaskId == taskId).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return tasks;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }

    }
}
