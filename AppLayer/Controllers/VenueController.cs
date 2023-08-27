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
    [RoutePrefix("api/venue")]
    public class VenueController : ApiController
    {
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = VenueService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        [HttpGet]
        [Route("get/{id}")]
        public HttpResponseMessage GetVenue(int Id)
        {
            try
            {
                var data = VenueService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        [HttpGet]
        [Route("Create")]
        public HttpResponseMessage CreateVenue(int id)
        {
            try
            {
                var data = StaffService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }

        }

        [HttpPost]
        [Route("update/{id}")]
        public HttpResponseMessage UpdateVenue(int id, VenueDTO obj)
        {
            try
            {
                var data = VenueService.Add( obj);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage DeleteVenue(int id)
        {
            try
            {
                var data = VenueService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        
    }
}
