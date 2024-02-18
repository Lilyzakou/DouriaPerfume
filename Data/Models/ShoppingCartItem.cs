using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Douriaperfume.Data.Models;

namespace DouriaPerfume.Data.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public Perfume Perfume { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}