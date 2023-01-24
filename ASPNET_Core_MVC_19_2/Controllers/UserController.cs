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
        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult GetAllUsers()
        {
            try
            {
                using (var db = new mydbContext())
                {
                    var users = db.UserMs.ToList();

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
                using (var db = new mydbContext())
                {
                    var _user = new UserM()
                    {
                        Name = user.Name,
                        Login = user.Login,
                        Password = user.Password
                    };
                    db.UserMs.Add(_user);

                    db.SaveChanges();

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
