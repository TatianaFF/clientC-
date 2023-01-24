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
    public class BrandController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public BrandController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult GetAllBrands()
        {
            try
            {
                using (var db = new mydbContext())
                {
                    var brands = db.Brands.ToList();

                    return new JsonResult(brands);
                }
            }
            catch (Exception e)
            {
                return new JsonResult(e);
            }
        }

        [HttpPost]
        public JsonResult CreateBrand(Brand brand)
        {
            try
            {
                using (var db = new mydbContext())
                {
                    var _brand = new Brand()
                    {
                        Title = brand.Title,
                        Logo = brand.Logo
                    };
                    db.Brands.Add(_brand);

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
