using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScanAndSave.Models
{
    public class Product
    {
        public string Barcode { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
    }
}