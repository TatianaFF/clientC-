using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET_Core_MVC_19_2.Models
{
    public class CartPhoneModel
    {
        public int Id { get; set; }
        public Cart Cart { get; set; }
        public Phone Phone { get; set; }
    }
}
