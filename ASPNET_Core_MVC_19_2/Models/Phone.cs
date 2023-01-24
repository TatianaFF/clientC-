using System;
using System.Collections.Generic;

#nullable disable

namespace ASPNET_Core_MVC_19_2.Models
{
    public partial class Phone
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public double Rating { get; set; }
        public string Cpu { get; set; }
        public string Camera { get; set; }
        public string Memory { get; set; }
        public string Ram { get; set; }
        public string Images { get; set; }
        public int Brand { get; set; }
        public int Category { get; set; }
    }
}
