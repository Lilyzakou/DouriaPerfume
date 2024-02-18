using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Douriaperfume.Data.Models;

namespace DouriaPerfume.Data.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public List<Perfume> Perfume { get; set; }
    }
}