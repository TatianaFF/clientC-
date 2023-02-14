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
        private readonly mydbContext _context;

        public BrandController(IConfiguration configuration, mydbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpGet]
        public JsonResult GetAllBrands()
        {
            try
            {
                using (_context)
                {
                    var brands = _context.Brands.ToList();

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
                using (_context)
                {
                    var _brand = new Brand()
                    {
                        Title = brand.Title,
                        Logo = brand.Logo
                    };
                    _context.Brands.Add(_brand);

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
