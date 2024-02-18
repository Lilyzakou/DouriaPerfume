using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Douriaperfume.Data.Models;
using DouriaPerfume.Data.Models;

namespace DouriaPerfume.Data.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int PerfumeId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public virtual Perfume? Perfume { get; set; }
        public virtual Order? Order { get; }
    }
}