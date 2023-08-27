using BLL.DTOs;
using BLL.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppLayer.Controllers
{
    [RoutePrefix("api/auditorium")]
    public class AuditoriumController : ApiController
    {
        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage GetAuditorium(int id)
        {
            try
            {
                var data = AuditoriumService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        [HttpGet]
        [Route("venue/{venueId}")]
        public HttpResponseMessage GetAuditoriumsByVenue(int venueId)
        {
            try
            {
                var data = AuditoriumService.Get(venueId);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        [HttpPost]
        [Route("create")]
        public HttpResponseMessage CreateAuditorium(AuditoriumDTO auditorium)
        {
            try
            {
                var data = AuditoriumService.Add(auditorium);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        [HttpPut]
        [Route("update/{id}")]
        public HttpResponseMessage UpdateAuditorium(AuditoriumDTO auditorium)
        {
            try
            {
                var data = AuditoriumService.Update(auditorium);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage DeleteAuditorium(int id)
        {
            try
            {
                var data = AuditoriumService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
    }
}
