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
    [Route("api/user")]
    public class UserController : BaseController
    {
        private UserService userService;
        private readonly MailSettings _mailSettings;

        public UserController(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
            userService = new UserService();
        }

        [Authorize]
        [HttpGet]
        [Route("list")]
        public IActionResult List()
        {
            ApiResponseMessage response = new ApiResponseMessage();
            var result = userService.List();

            response.Message = result != null && result.Count > 0 ? "Users list found." : "Not Record Found.";
            response.Status = HttpStatusCode.OK;
            response.Response = result;

            return Ok(result);
        }

        [Authorize]
        [HttpPost]
        [Route("save")]
        public ActionResult Save(UserDto data)
        {
            var loggedInUserId = GetUserId();
            var result = userService.Save(data, loggedInUserId);
            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        [Route("get")]
        public ActionResult Get(int Id)
        {

            ApiResponseMessage response = new ApiResponseMessage();
            var result = userService.Get(Id);

            if (result != null && result.Id > 0)
                response.Message = "user Found";
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
            var result = userService.Delete(Ids);

            response.Message = result ? "Deleted" : "Not Deleted";
            response.Status = HttpStatusCode.OK;
            response.Response = result;

            return Ok(response);
        }
    }
}
