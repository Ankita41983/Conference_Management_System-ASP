using BLL.DTOs;
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
                var db = new ConferenceContext();
                var staff = (from s in db.Staffs
                             where s.Email == fp.Email
                             select s).SingleOrDefault();

                if (staff != null)
                {
                    System.Random random = new System.Random();
                    int OTP = random.Next(10000, 99999);

                    string fromMail = "ankita.saha41983@gmail.com";
                    string fromPassword = "vtxeuorovryfepqg";

                    MailMessage message = new MailMessage();
                    message.From = new MailAddress(fromMail);
                    message.Subject = "Forget Password for CMS";
                    message.To.Add(new MailAddress(staff.Email));
                    message.Body = "<html><body> Your OTP for reser password is <br><h2>" + OTP + "</h2> <br><br>Copyright 2023, Conference Management System </body></html>";
                    message.IsBodyHtml = true;

                    var smtpClient = new SmtpClient("smtp.gmail.com")
                    {
                        Port = 587,
                        Credentials = new NetworkCredential(fromMail, fromPassword),
                        EnableSsl = true,
                    };

                    smtpClient.Send(message);

                    var pass = new PassOTP();
                    pass.Email = fp.Email;
                    pass.OTP = OTP;
                    StaffService.ForgetPass(pass);
                    return Request.CreateResponse(new { message = "Sent..." });
                }
                return Request.CreateResponse(new { message = "not sent..." });
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
        [Route("dashboard")] // featured api - 1
        public HttpResponseMessage Dashboard()
        {
            try
            {
                var db = new ConferenceContext();
                var venues = (from venue in db.Venues
                              select venue).Count();

                var auditoriums = (from auditorium in db.Auditoriums
                                  select auditorium).Count();

                var bookedSeats = (from seat in db.Seats
                             select seat).Count();

                var auditoriumSeats = (from auditorium in db.Auditoriums
                                       select new
                                       {
                                           auditorium.Id,
                                           auditorium.A_Name,
                                           auditorium.A_Capacity,
                                           bookedseats = (from seat in db.Seats
                                                          where seat.Auditorium_id == auditorium.Id
                                                          select seat).Count()
                                       });

                var venueList = (from ven in db.Venues
                                  select new
                                  {
                                      ven.Id,
                                      ven.Name,
                                      ven.Capacity,
                                      auditoriums = (from aud in db.Auditoriums
                                                     where aud.Venue_id == ven.Id
                                                     select new { aud.Id, aud.A_Capacity }).ToList()
                                  });
                return Request.CreateResponse(new { venues, auditoriums, bookedSeats, auditoriumSeats, venueList });
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
