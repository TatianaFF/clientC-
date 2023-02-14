using Microsoft.AspNetCore.Mvc;
using ASPNET_Core_MVC_19_2.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET_Core_MVC_19_2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly mydbContext _context;

        public UserController(IConfiguration configuration, mydbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpGet]
        public JsonResult GetAllUsers()
        {
            try
            {
                using (_context)
                {
                    var users = _context.UserMs.ToList();

                    return new JsonResult(users);
                }
            }
            catch (Exception e)
            {
                return new JsonResult(e);
            }
        }

        [HttpPost]
        public JsonResult CreateUser(UserM user)
        {
            try
            {
                using (_context)
                {
                    var _user = new UserM()
                    {
                        Name = user.Name,
                        Login = user.Login,
                        Password = user.Password
                    };
                    _context.UserMs.Add(_user);

                    _context.SaveChanges();

                    return new JsonResult("Added Successfully");
                }
            }
            catch (Exception e)
            {
                return new JsonResult(e);
            }

        }
    }
}
