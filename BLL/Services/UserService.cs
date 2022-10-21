

using AHDBLL.Dtos.Request;
using BLL.Dtos;
using BLL.Dtos.Menu;
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
    public class UserService
    {
        public ApiResponseMessage SignUp(UserDto user)
        {
            User newUser = new User();
            var response = new ApiResponseMessage();
            response.Status = HttpStatusCode.OK;

            var encryptedPw = Encryption.Encrypt(user.Password);
            newUser.Password = encryptedPw;
            newUser.Username = user.Username;
            newUser.FirstName = user.FirstName;
            newUser.LastName = user.LastName;
            newUser.Email = user.Email;
            newUser.CreatedOn = DateTime.Now;


            User result = new UserRepository().Add(newUser);
            if (result.Id > 0)
            {
                response.Message = "User added successfully";
                response.Response = result;
            }
            else
            {
                response.Message = "Failed, an error has occured.";
                response.Response = "";
            }
            return response;
        }

        public LoginResponse Login(string username, string password)
        {
            try
            {
                var encryptedPw = Encryption.Encrypt(password);
                using (var userData = new UserRepository())
                {
                    User login = userData.Login(username, encryptedPw);
                    //return login;
                    #region UserRoleImplimentationNotNeeded
                    if (login != null && login.Id > 0)
                    {
                        var loginRes = new LoginResponse();
                        loginRes.User = login;
                        return loginRes;
                    }
                    else
                    {
                        return null;
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<User> List()
        {
            try
            {
                using (var userData = new UserRepository())
                {
                    return userData.List();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<UserDto> List(UserListRequestDto req)
        {
            try
            {
                List<UserDto> users = new List<UserDto>();
                using (var userData = new UserRepository())
                {
                    var usersDataset = userData.List(req.PageNo);
                    users = UsersDStoList(usersDataset);

                }
                return users;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ApiResponseMessage Save(UserDto user, int loggedInUserId)
        {
            var response = new ApiResponseMessage();

            try
            {
                User obj = new User();
                using (var userData = new UserRepository())
                {
                    if (user != null && user.Id > 0)
                    {
                        obj = userData.Get(user.Id);
                    }

                    obj.FirstName = user.FirstName;
                    obj.LastName = user.LastName;
                    obj.DateOfBirth = user.DateOfBirth;
                    obj.Email = user.Email;
                    obj.Phone = user.Phone;
                    obj.CountryId = user.CountryId;
                    obj.State = user.State;
                    obj.City = user.City;
                    obj.Address = user.Address;
                    obj.Zip = user.Zip;

                    if (user.Id > 0)
                    {
                        obj.UpdatedOn = DateTime.Now;
                        obj.UpdatedBy = loggedInUserId;
                        userData.Update(obj);
                    }
                    else
                    {
                        obj.Username = user.Username;
                        obj.Password = user.Password;
                        obj.CreatedBy = loggedInUserId;
                        obj.CreatedOn = DateTime.Now;
                        userData.Add(obj);
                    }

                }
                response.Status = HttpStatusCode.OK;
                response.Message = "User saved successfully!";
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

        public User Get(int Id)
        {
            try
            {
                using (var userData = new UserRepository())
                {
                    return userData.Get(Id);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<User> GetPending()
        {
            try
            {
                using (var userData = new UserRepository())
                {
                    return userData.GetUsersByStatus(Convert.ToInt32(UserStatus.Pending));
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<User> GetApproved()
        {
            try
            {
                using (var userData = new UserRepository())
                {
                    return userData.GetUsersByStatus(Convert.ToInt32(UserStatus.Approved));
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<User> GetRejected()
        {
            try
            {
                using (var userData = new UserRepository())
                {
                    return userData.GetUsersByStatus(Convert.ToInt32(UserStatus.Rejected));
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool UpdateStatus(string Ids, int statusId, int companyId)
        {
            try
            {
                using (var userData = new UserRepository())
                {
                    var ids = Ids.Split(',').Select(Int32.Parse).ToList();
                    foreach (var id in ids)
                    {
                        var user = userData.Get(id);
                        userData.Update(user);
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string ChangePassword(PasswordDto passwordDto, int loggedInUserId)
        {
            User user = new User();
            try
            {
                using (var userData = new UserRepository())
                {
                    user = userData.Get(passwordDto.UserId);

                    if (user != null && user.Id > 0)
                    {
                        var passwordFromDb = Encryption.Decrypt(user.Password);
                        var validationMessage = this.ValidatePassword(passwordFromDb, passwordDto);
                        if (validationMessage != "valid")
                            return validationMessage;
                        else
                        {
                            user.Password = Encryption.Encrypt(passwordDto.Password);
                            user.UpdatedBy = loggedInUserId;
                            user.UpdatedOn = DateTime.Now;
                            userData.Update(user);

                            return "Password changed.";
                        }
                    }
                    else
                    {
                        return "Invalid User.";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Failed to update password. Please try again later.";
            }
        }

        private string ValidatePassword(string passwordDb, PasswordDto password)
        {
            if (passwordDb != password.OldPassword)
                return "The Old Password you entered is invalid.";
            else if (password.Password != password.ConfirmPassword)
                return "Passwords are not matching.";
            else
                return "valid";
        }

        private List<UserDto> UsersDStoList(DataSet ds)
        {
            List<UserDto> users = new List<UserDto>();
            var table = ds.Tables[0];
            if (table != null && table.Rows.Count > 0)
            {
                try
                {
                    foreach (DataRow row in table.Rows)
                    {
                        var obj = new UserDto();
                        obj.Id = int.Parse(row["Id"] + "");
                        obj.Username = row["Username"] + "";
                        obj.FirstName = row["FirstName"] + "";
                        obj.LastName = row["LastName"] + "";

                        if (!string.IsNullOrEmpty(row["DateOfBirth"] + ""))
                        {
                            var dbo = DateTime.Parse(row["DateOfBirth"] + "");
                            obj.DateOfBirthStr = dbo.ToString("dd-MMMM-yyyy hh:mm tt");
                        }

                        obj.Email = row["Email"] + "";
                        obj.Phone = row["Phone"] + "";
                        obj.CountryId = int.Parse(row["CountryId"] + "");
                        obj.CountryTitle = row["CountryTitle"] + "";
                        obj.State = row["State"] + "";
                        obj.City = row["City"] + "";
                        obj.Address = row["Address"] + "";
                        obj.Zip = row["Zip"] + "";
                        obj.CompanyId = int.Parse(row["CompanyId"] + "");
                        obj.CompanyName = row["CompanyName"] + "";
                        obj.Status = int.Parse(row["Status"] + "");
                        obj.StatusTitle = row["StatusTitle"] + "";

                        if (!string.IsNullOrEmpty(row["CreatedOn"] + ""))
                        {
                            var createdDateTime = DateTime.Parse(row["CreatedOn"] + "");
                            obj.CreatedOnStr = createdDateTime.ToString("dd-MMMM-yyyy hh:mm tt");
                        }
                        if (!string.IsNullOrEmpty(row["UpdatedOn"] + ""))
                        {
                            var updatedDateTime = DateTime.Parse(row["UpdatedOn"] + "");
                            obj.UpdatedOnStr = updatedDateTime.ToString("dd-MMMM-yyyy hh:mm tt");
                        }

                        users.Add(obj);
                    }
                }
                catch (Exception ex)
                {
                }
            }
            return users;
        }
        public bool Delete(int ids)
        {
            try
            {
                using (var userRepository = new UserRepository())
                {
                    return userRepository.Delete(ids);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool ValidateUser(string type, string value, int userId)
        {
            bool result = false;
            try
            {
                if (type == "email")
                {
                    using (var empData = new UserRepository())
                    {
                        result = empData.CheckEmailExists(value, userId);
                    }
                }
                else
                {
                    using (var userData = new UserRepository())
                    {
                        result = userData.CheckUsernameExists(value, userId);
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
