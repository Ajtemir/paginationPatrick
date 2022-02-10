using System.Collections.Generic;
using PagonationPatrick.Models;

namespace PagonationPatrick.Entities
{
    public class ProductResponse
    {
        public List<Product> Products { get; set; } = new List<Product>();
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
    }
    
}