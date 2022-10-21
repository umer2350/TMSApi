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
    public class UserRepository : IDisposable
    {
        public User Add(User user)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.Add(user);
                    _context.SaveChanges();
                }

                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public User Update(User user)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    _context.Update(user);
                    _context.SaveChanges();
                }

                return user;
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
                    var user = _context.Users.Find(id);
                    _context.Users.Remove(user);
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public User Get(int id)
        {
            try
            {
                using (var _context = Db.Create())
                {

                    return _context.Users.FirstOrDefault(o => o.Id == id);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public User GetByEmailAddress(string emailAddress)
        {
            try
            {
                using (var _context = Db.Create())
                {

                    return _context.Users.FirstOrDefault(o => o.Email == emailAddress);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public User Login(string username, string password)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    var user = _context.Users.FirstOrDefault(o => o.Username == username && o.Password == password);
                    return user;
                }
            }
            catch (Exception ex)
            {
                Helper.WriteToFile(ex.Message);
                return null;
            }
        }

        public List<User> List()
        {
            List<User> users = new List<User>();
            try
            {
                using (var _context = Db.Create())
                {
                    users = _context.Users.ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return users;
        }

        public DataSet List(int pageNo)
        {
            DataSet ds = new DataSet("Users");
            try
            {
                using (SqlConnection conn = new SqlConnection(Connection.GetConnectionString()))
                {
                    SqlCommand sqlComm = new SqlCommand("SP_GetUsersList", conn);
                    sqlComm.Parameters.AddWithValue("@PageNumber", pageNo);

                    sqlComm.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;

                    da.Fill(ds);
                }
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<User> GetUsersByStatus(int userStatus)
        {
            List<User> users = new List<User>();
            try
            {
                using (var _context = Db.Create())
                {
                    users = _context.Users.ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return users;

        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
        public bool CheckEmailExists(string email, int userId)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    if (userId > 0)
                        return _context.Users.Any(o => o.Email == email && o.Id != userId);
                    else
                        return _context.Users.Any(o => o.Email == email);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CheckUsernameExists(string username, int userId)
        {
            try
            {
                using (var _context = Db.Create())
                {
                    if (userId > 0)
                        return _context.Users.Any(o => o.Username.ToLower() == username.Trim().ToLower() && o.Id != userId);
                    else
                        return _context.Users.Any(o => o.Username.ToLower() == username.Trim().ToLower());
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
