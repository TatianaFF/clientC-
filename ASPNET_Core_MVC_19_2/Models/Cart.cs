using System;
using System.Collections.Generic;

#nullable disable

namespace ASPNET_Core_MVC_19_2.Models
{
    public partial class Cart
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdPhone { get; set; }
        public int Count { get; set; }
    }
}
