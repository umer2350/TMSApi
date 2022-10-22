using BLL.Dtos;
using BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace TMSApi.Controllers
{
    [Produces("application/json")]
    [Route("short/list")]
    public class CommonController : BaseController
    {
        CommonService commonHandler = null;

        public CommonController()
        {
            commonHandler = new BLL.Services.CommonService();
        }

        [Authorize]
        [HttpGet]
        [Route("customers")]
        public ActionResult Customers()
        {
            var result = commonHandler.Customers();
            return Ok(result);
        }
        [Authorize]
        [HttpGet]
        [Route("workers")]
        public ActionResult Workers()
        {
            var result = commonHandler.Workers();
            return Ok(result);
        }
        [Authorize]
        [HttpGet]
        [Route("countries")]
        public ActionResult Countries()
        {
            var result = commonHandler.Countries();
            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        [Route("cities")]
        public ActionResult Cities(int stateId)
        {
            var result = commonHandler.Cities(stateId);
            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        [Route("states")]
        public ActionResult States(int countryId)
        {
            var result = commonHandler.States(countryId);
            return Ok(result);
        }

    }
}
