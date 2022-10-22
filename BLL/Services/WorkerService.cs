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
    public class WorkerService
    {

        public List<Worker> List()
        {
            try
            {
                using (var workerData = new WorkerRepository())
                {
                    return workerData.List();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ApiResponseMessage Save(WorkerDto worker, int loggedInWorkerId)
        {
            var response = new ApiResponseMessage();

            try
            {
                Worker obj = new Worker();
                using (var workerData = new WorkerRepository())
                {
                    if (worker != null && worker.Id > 0)
                    {
                        obj = workerData.Get(worker.Id);
                    }

                    obj.FirstName = worker.FirstName;
                    obj.LastName = worker.LastName;
                    obj.Email = worker.Email;
                    obj.Phone = worker.Phone;
                    obj.City = worker.City;
                    obj.Address = worker.Address;
                    obj.ProfilePic = worker.ProfilePic;
                    obj.RoleId = worker.RoleId;

                    if (worker.Id > 0)
                    {
                        obj.UpdatedOn = DateTime.Now;
                        obj.UpdatedBy = loggedInWorkerId;
                        workerData.Update(obj);
                    }
                    else
                    {
                        obj.CreatedBy = loggedInWorkerId;
                        obj.CreatedOn = DateTime.Now;
                        workerData.Add(obj);
                    }

                }
                response.Status = HttpStatusCode.OK;
                response.Message = "Worker saved successfully!";
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

        public Worker Get(int Id)
        {
            try
            {
                using (var workerData = new WorkerRepository())
                {
                    return workerData.Get(Id);
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
                using (var workerRepository = new WorkerRepository())
                {
                    return workerRepository.Delete(ids);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
