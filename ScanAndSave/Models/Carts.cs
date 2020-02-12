using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScanAndSave.Models
{
    public class Carts
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Items { get; set; }
        public string UserId { get; set; }
    }
}