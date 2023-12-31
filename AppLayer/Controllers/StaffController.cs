﻿using BLL.DTOs;
using BLL.Services;
using DAL.EF;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;

namespace AppLayer.Controllers
{
    [RoutePrefix("api/staff")]
    public class StaffController : ApiController
    {
        [HttpPost]
        [Route("forgetPassword")] // featured api - 2
        public HttpResponseMessage ForgetPassword(ForgetPassDTO fp)
        {
            try
            {
                var data = StaffService.ForgetPass(fp);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        [HttpPost]
        [Route("forgetPassword/verify")] // featured api - 2
        public HttpResponseMessage VarifyOTP(ForgetPassDTO obj)
        {
            try
            {
                var data = StaffService.Verify(obj);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        [HttpGet]
        [Route("all")]
        public HttpResponseMessage AllStaff()
        {
            try
            {
                var data = StaffService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        [HttpGet]
        [Route("get/{id}")]
        public HttpResponseMessage GetOne(int id)
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
        [Route("registration")]
        public HttpResponseMessage Registration(StaffDTO obj)
        {
            try
            { 
                var data = StaffService.Add(obj);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        [HttpPut]
        [Route("updateProfile")]
        public HttpResponseMessage UpdateProfile(StaffDTO obj)
        {
            try
            {
                var data = StaffService.Update(obj);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        [HttpDelete]
        [Route("deleteProfile/{id}")]
        public HttpResponseMessage DeleteProfile(int id)
        {
            try
            {
                var data = StaffService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
    }
}
