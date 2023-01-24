using System;
using System.Collections.Generic;

#nullable disable

namespace ASPNET_Core_MVC_19_2.Models
{
    public partial class UserM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
