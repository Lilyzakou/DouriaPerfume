﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DouriaPerfume.Data.Models;

namespace Douriaperfume.Data.Models
{
    public class Perfume
    {
        public int PerfumeId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public bool IsPreferredPerfume { get; set; }
        public bool InStock { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}