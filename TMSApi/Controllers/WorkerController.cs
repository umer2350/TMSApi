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
    [Route("api/worker")]
    public class WorkerController : BaseController
    {
        private WorkerService workerService;

        public WorkerController()
        {
            workerService = new WorkerService();
        }

        [Authorize]
        [HttpGet]
        [Route("list")]
        public IActionResult List()
        {
            ApiResponseMessage response = new ApiResponseMessage();
            var result = workerService.List();

            response.Message = result != null && result.Count > 0 ? "Workers list found." : "Not Record Found.";
            response.Status = HttpStatusCode.OK;
            response.Response = result;

            return Ok(result);
        }

        [Authorize]
        [HttpPost]
        [Route("save")]
        public ActionResult Save(WorkerDto data)
        {
            var loggedInWorkerId = GetUserId();
            var result = workerService.Save(data, loggedInWorkerId);
            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        [Route("get")]
        public ActionResult Get(int Id)
        {

            ApiResponseMessage response = new ApiResponseMessage();
            var result = workerService.Get(Id);

            if (result != null && result.Id > 0)
                response.Message = "worker Found";
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
            var result = workerService.Delete(Ids);

            response.Message = result ? "Deleted" : "Not Deleted";
            response.Status = HttpStatusCode.OK;
            response.Response = result;

            return Ok(response);
        }
    }
}
