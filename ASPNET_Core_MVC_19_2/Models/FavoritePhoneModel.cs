using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET_Core_MVC_19_2.Models
{
    public class FavoritePhoneModel
    {
        public int Id { get; set; }
        public Favorite Favorite { get; set; }
        public Phone Phone { get; set; }
    }
}
