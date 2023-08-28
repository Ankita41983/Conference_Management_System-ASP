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
   

        [RoutePrefix("api/seat")]
        public class SeatController : ApiController
        {
            [HttpGet]
            [Route("{id}")]
            public HttpResponseMessage GetSeat(int id)
            {
                try
                {
                    var data = SeatService.Get(id);
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
                }
            }

            [HttpGet]
            [Route("all")]
            public HttpResponseMessage GetSeats()
            {
                try
                {
                    var data = SeatService.Get();
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
                }
            }

            [HttpPost]
            [Route("create")]
            public HttpResponseMessage CreateSeat(SeatDTO seat)
            {
                try
                {
                    var data = SeatService.Add(seat);
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
                }
            }

            [HttpPut]
            [Route("update")]
            public HttpResponseMessage UpdateSeat(SeatDTO seat)
            {
                try
                {
                    var data = SeatService.Update(seat);
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
                }
            }

            [HttpDelete]
            [Route("delete/{id}")]
            public HttpResponseMessage DeleteSeat(int id)
            {
                try
                {
                    var data = SeatService.Delete(id);
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
                }
            }
        }
    }