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
        public CategoryController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult GetAllCategories()
        {
            try
            {
                using (var db = new mydbContext())
                {
                    var categories = db.Categories.ToList();

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
                using (var db = new mydbContext())
                {
                    var _category = new Category()
                    {
                        Title = category.Title
                    };
                    db.Categories.Add(_category);

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
