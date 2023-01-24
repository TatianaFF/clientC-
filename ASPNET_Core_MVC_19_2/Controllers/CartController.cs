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
    public class CartController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public CartController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult GetPhonesCartByUserId(int userId = 100)
        {
            try
            {
                using (var db = new mydbContext())
                {
                    List<CartPhoneModel> cartPhoneList = new List<CartPhoneModel>();

                    List<Cart> cartsByUserId = db.Carts.Where(c => c.IdUser == userId).ToList();

                    List<int> idPhonesCart = new List<int>();

                    foreach (Cart cart in cartsByUserId) idPhonesCart.Add(cart.IdPhone);

                    List<Phone> phonesById = db.Phones.Where(p => idPhonesCart.Contains(p.Id)).ToList();

                    foreach (Cart _cart in cartsByUserId)
                    {
                        foreach (Phone _phone in phonesById)
                        {
                            if (_cart.IdPhone == _phone.Id) cartPhoneList.Add(new CartPhoneModel { Id = _cart.Id, Cart = _cart, Phone = _phone });
                        }
                    }


                    return new JsonResult(cartPhoneList);
                }
            }
            catch (Exception e)
            {
                return new JsonResult(e);
            }
        }

        [HttpGet("{phoneId}")]
        public JsonResult GetCartsByPhoneId(int phoneId)
        {
            try
            {
                using (var db = new mydbContext())
                {
                    List<Cart> cartsByPhoneId = db.Carts.Where(c => c.IdPhone == phoneId).ToList();


                    return new JsonResult(cartsByPhoneId);
                }
            }
            catch (Exception e)
            {
                return new JsonResult(e);
            }
        }

        [HttpPut]
        public JsonResult UpdateCart(Cart cart)
        {
            try
            {
                using (var db = new mydbContext())
                {
                    var _cart = db. Carts.Where(с => с.Id == cart.Id).Single();

                    db.Entry(_cart).CurrentValues.SetValues(cart);

                    db.SaveChanges();

                    return new JsonResult("Updated Successfully");
                }
            }
            catch (Exception e)
            {
                return new JsonResult(e);
            }
        }

        [HttpPost]
        public JsonResult CreateCart(Cart cart)
        {
            try
            {
                using (var db = new mydbContext())
                {
                    var _cart = new Cart()
                    {
                        IdUser = 100,
                        IdPhone = cart.IdPhone,
                        Count = 1
                    };
                    db.Carts.Add(_cart);

                    db.SaveChanges();

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
                using (var db = new mydbContext())
                {
                    var _cart = db.Carts.Where(c => c.Id == id).Single();
                    db.Carts.Remove(_cart);

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
