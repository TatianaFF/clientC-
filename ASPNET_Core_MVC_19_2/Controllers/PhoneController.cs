using ASPNET_Core_MVC_19_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET_Core_MVC_19_2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public PhoneController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult GetAllPhones()
        {
            try
            {
                using (var db = new mydbContext())
                {
                    var phones = db.Phones.ToList();

                    return new JsonResult(phones);
                }
            }
            catch(Exception e)
            {
                return new JsonResult(e);
            }
        }

        [HttpGet("{idPhone}")]
        public JsonResult GetPhoneById(int idPhone)
        {
            try
            {
                using (var db = new mydbContext())
                {
                    var phone = db.Phones.Where(p => p.Id == idPhone).Single();

                    return new JsonResult(phone);
                }
            }
            catch (Exception e)
            {
                return new JsonResult(e);
            }
        }

        [HttpPost]
        public JsonResult CreatePhone(Phone phone)
        {
            try
            {
                using (var db = new mydbContext())
                {
                    var _phone = new Phone() {
                        Title = phone.Title,
                        Price = phone.Price,
                        Rating = phone.Rating,
                        Cpu = phone.Cpu,
                        Camera = phone.Camera,
                        Memory = phone.Memory,
                        Ram = phone.Ram,
                        Images = phone.Images,
                        Brand = phone.Brand,
                        Category = phone.Brand
                    };
                    db.Phones.Add(_phone);

                    db.SaveChanges();

                    return new JsonResult("Added Successfully");
                }
            }
            catch (Exception e)
            {
                return new JsonResult(e);
            }

        }

        [HttpPut]
        public JsonResult UpdatePhone(Phone phone)
        {
            try
            {
                using (var db = new mydbContext())
                {
                    var _phone = db.Phones.Where(p => p.Id == phone.Id).Single();

                    db.Entry(_phone).CurrentValues.SetValues(phone);

                    db.SaveChanges();

                    return new JsonResult("Updated Successfully");
                }
            }
            catch (Exception e)
            {
                return new JsonResult(e);
            }
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                using (var db = new mydbContext())
                {
                    var _phone = db.Phones.Where(p => p.Id == id).Single();
                    db.Phones.Remove(_phone);

                    db.SaveChanges();

                    return new JsonResult("Deleted Successfully");
                }
            }
            catch (Exception e)
            {
                return new JsonResult(e);
            }
        }
    }
}
