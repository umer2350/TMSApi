using BLL.Dtos;
using BLL.Services;
using Utility.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net;

namespace TMSApi.Controllers
{
    [Produces("application/json")]
    [Route("api/task")]
    public class TaskController : BaseController
    {
        private TaskService taskService;

        public TaskController()
        {
            taskService = new TaskService();
        }

        [Authorize]
        [HttpGet]
        [Route("list")]
        public IActionResult List()
        {
            ApiResponseMessage response = new ApiResponseMessage();
            var result = taskService.List();

            response.Message = result != null && result.Count > 0 ? "Tasks list found." : "Not Record Found.";
            response.Status = HttpStatusCode.OK;
            response.Response = result;

            return Ok(result);
        }

        [Authorize]
        [HttpPost]
        [Route("save")]
        public ActionResult Save(TaskDto data)
        {
            var loggedInTaskId = GetUserId();
            var result = taskService.Save(data, loggedInTaskId);
            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        [Route("get")]
        public ActionResult Get(int Id)
        {

            ApiResponseMessage response = new ApiResponseMessage();
            var result = taskService.Get(Id);

            if (result != null && result.Id > 0)
                response.Message = "task Found";
            else
                response.Message = "Not Found";
            response.Status = HttpStatusCode.OK;
            response.Response = result;

            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        [Route("taskFiles")]
        public ActionResult TaskFilesList(int Id)
        {

            ApiResponseMessage response = new ApiResponseMessage();
            var result = taskService.TaskFilesList(Id);

            if (result.Count > 0)
                response.Message = "task Found";
            else
                response.Message = "Not Found";
            response.Status = HttpStatusCode.OK;
            response.Response = result;

            return Ok(response);
        }
        [Authorize]
        [HttpDelete]
        [Route("delete")]
        public ActionResult Delete(int Ids)
        {
            ApiResponseMessage response = new ApiResponseMessage();
            var result = taskService.Delete(Ids);

            response.Message = result ? "Deleted" : "Not Deleted";
            response.Status = HttpStatusCode.OK;
            response.Response = result;

            return Ok(response);
        }
    }
}
