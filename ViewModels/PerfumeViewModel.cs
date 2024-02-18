using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DouriaPerfume.ViewModels
{
    public class PerfumeViewModel
    {
        public int PerfumeId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public decimal Price { get; set; }
        public string ImageThumbnailUrl { get; set; }
    }
}