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
    [Route("api/customer")]
    public class CustomerController : BaseController
    {
        private CustomerService customerService;

        public CustomerController()
        {
            customerService = new CustomerService();
        }

        [Authorize]
        [HttpGet]
        [Route("list")]
        public IActionResult List()
        {
            ApiResponseMessage response = new ApiResponseMessage();
            var result = customerService.List();

            response.Message = result != null && result.Count > 0 ? "Customers list found." : "Not Record Found.";
            response.Status = HttpStatusCode.OK;
            response.Response = result;

            return Ok(result);
        }

        [Authorize]
        [HttpPost]
        [Route("save")]
        public ActionResult Save(CustomerDto data)
        {
            var loggedInCustomerId = GetUserId();
            var result = customerService.Save(data, loggedInCustomerId);
            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        [Route("get")]
        public ActionResult Get(int Id)
        {

            ApiResponseMessage response = new ApiResponseMessage();
            var result = customerService.Get(Id);

            if (result != null && result.Id > 0)
                response.Message = "customer Found";
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
            var result = customerService.Delete(Ids);

            response.Message = result ? "Deleted" : "Not Deleted";
            response.Status = HttpStatusCode.OK;
            response.Response = result;

            return Ok(response);
        }
    }
}
