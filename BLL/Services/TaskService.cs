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
    public class TaskService
    {

        public List<Task> List()
        {
            try
            {
                using (var taskData = new TaskRepository())
                {
                    return taskData.List();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<TaskFile> TaskFilesList(int taskId)
        {
            try
            {
                using (var taskData = new TaskRepository())
                {
                    return taskData.TaskFilesList(taskId);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ApiResponseMessage Save(TaskDto task, int loggedInTaskId)
        {
            var response = new ApiResponseMessage();

            try
            {
                Task obj = new Task();
                using (var taskData = new TaskRepository())
                {
                    if (task != null && task.Id > 0)
                    {
                        obj = taskData.Get(task.Id);
                    }

                    obj.CustomerId = task.CustomerId;
                    obj.WorkerId = task.WorkerId;
                    obj.ToDate = task.ToDate;
                    obj.FromDate = task.FromDate;
                    obj.StatusId = task.StatusId;
                    obj.Notes = task.Notes;
                    obj.Amount = task.Amount;
                    obj.Description = task.Description;

                    if (task.Id > 0)
                    {
                        obj.UpdatedOn = DateTime.Now;
                        obj.UpdatedBy = loggedInTaskId;
                        taskData.Update(obj);
                    }
                    else
                    {
                        obj.CreatedBy = loggedInTaskId;
                        obj.CreatedOn = DateTime.Now;
                        taskData.Add(obj);
                    }

                }
                response.Status = HttpStatusCode.OK;
                response.Message = "Task saved successfully!";
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

        public Task Get(int Id)
        {
            try
            {
                using (var taskData = new TaskRepository())
                {
                    return taskData.Get(Id);
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
                using (var taskRepository = new TaskRepository())
                {
                    return taskRepository.Delete(ids);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
