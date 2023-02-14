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
    public class CategoryController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly mydbContext _context;

        public CategoryController(IConfiguration configuration, mydbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpGet]
        public JsonResult GetAllCategories()
        {
            try
            {
                using (_context)
                {
                    var categories = _context.Categories.ToList();

                    return new JsonResult(categories);
                }
            }
            catch (Exception e)
            {
                return new JsonResult(e);
            }
        }

        [HttpPost]
        public JsonResult CreateCategory(Category category)
        {
            try
            {
                using (_context)
                {
                    var _category = new Category()
                    {
                        Title = category.Title
                    };
                    _context.Categories.Add(_category);

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
