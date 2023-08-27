using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppLayer.Controllers
{
    public class LoginController : ApiController
    {
        [HttpPost]
        [Route("login")]
        public HttpResponseMessage Login(LoginDTO login)
        {
            try
            {
                var user = LoginService.Authenticate(login);
                return Request.CreateResponse(new { user });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
    }
}
