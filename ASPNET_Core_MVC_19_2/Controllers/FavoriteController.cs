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
    public class FavoriteController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly mydbContext _context;

        public FavoriteController(IConfiguration configuration, mydbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        /*[HttpGet]
        public JsonResult GetAllFavorites()
        {
            try
            {
                using (var db = new mydbContext())
                {
                    var favorites = db.Favorites.ToList();

                    return new JsonResult(favorites);
                }
            }
            catch (Exception e)
            {
                return new JsonResult(e);
            }
        }*/

        [HttpGet]
        public JsonResult GetFavoritePhonesByUserId(int userId = 100)
        {
            try
            {
                using (_context)
                {
                    /*List<Favorite> favoritesByUserId = db.Favorites.Where(f => f.IdUser == userId).ToList();

                    List<int> idPhonesFavorite = new List<int>();

                    foreach (Favorite favorite in favoritesByUserId) idPhonesFavorite.Add(favorite.IdPhone);

                    List<Phone> phonesById = db.Phones.Where(p => idPhonesFavorite.Contains(p.Id)).ToList();*/

                    List<FavoritePhoneModel> favoritePhoneList = new List<FavoritePhoneModel>();

                    List<Favorite> favoritesByUserId = _context.Favorites.Where(f => f.IdUser == userId).ToList();

                    List<int> idPhonesFavorite = new List<int>();

                    foreach (Favorite favorite in favoritesByUserId) idPhonesFavorite.Add(favorite.IdPhone);

                    List<Phone> phonesById = _context.Phones.Where(p => idPhonesFavorite.Contains(p.Id)).ToList();

                    foreach (Favorite _favorite in favoritesByUserId)
                    {
                        foreach (Phone _phone in phonesById)
                        {
                            if (_favorite.IdPhone == _phone.Id) favoritePhoneList.Add(new FavoritePhoneModel { Id = _favorite.Id, Favorite = _favorite, Phone = _phone });
                        }
                    }

                    return new JsonResult(favoritePhoneList);
                }
            }
            catch (Exception e)
            {
                return new JsonResult(e);
            }
        }

        [HttpPost]
        public JsonResult CreateFavorite(Favorite favorite)
        {
            try
            {
                using (_context)
                {
                    var _favorite = new Favorite()
                    {
                        IdUser = favorite.IdUser,
                        IdPhone = favorite.IdPhone
                    };
                    _context.Favorites.Add(_favorite);

                    _context.SaveChanges();

                    return new JsonResult("Added Successfully");
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
                    var _favorite = _context.Favorites.Where(f => f.Id == id).Single();
                    _context.Favorites.Remove(_favorite);

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
