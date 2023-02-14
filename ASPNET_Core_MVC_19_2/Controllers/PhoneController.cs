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
        private readonly mydbContext _context;

        public PhoneController(IConfiguration configuration, mydbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpGet]
        public JsonResult GetAllPhones()
        {
            try
            {
                using (_context)
                {
                    var phones = _context.Phones.ToList();

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
                using (_context)
                {
                    var phone = _context.Phones.Where(p => p.Id == idPhone).Single();

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
                using (_context)
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
                    _context.Phones.Add(_phone);

                    _context.SaveChanges();

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
                using (_context)
                {
                    var _phone = _context.Phones.Where(p => p.Id == phone.Id).Single();

                    _context.Entry(_phone).CurrentValues.SetValues(phone);

                    _context.SaveChanges();

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
                using (_context)
                {
                    var _phone = _context.Phones.Where(p => p.Id == id).Single();
                    _context.Phones.Remove(_phone);

                    _context.SaveChanges();

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
