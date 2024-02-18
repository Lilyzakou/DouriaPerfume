using DouriaPerfume.Data.Models;
using DouriaPerfume.ViewModels;
using DouriaPerfume.Data.Interfaces;
using DouriaPerfume.Data.Models;
using DouriaPerfume.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DouriaPerfume.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IPerfumeRepository _PerfumeRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IPerfumeRepository PerfumeRepository, ShoppingCart shoppingCart)
        {
            _PerfumeRepository = PerfumeRepository;
            _shoppingCart = shoppingCart;
        }

        [Authorize]
        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(shoppingCartViewModel);
        }

        [Authorize]
        public RedirectToActionResult AddToShoppingCart(int PerfumeId)
        {
            var selectedPerfume = _PerfumeRepository.Perfumes.FirstOrDefault(p => p.PerfumeId == PerfumeId);
            if (selectedPerfume != null)
            {
                _shoppingCart.AddToCart(selectedPerfume, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int PerfumeId)
        {
            var selectedPerfume = _PerfumeRepository.Perfumes.FirstOrDefault(p => p.PerfumeId == PerfumeId);
            if (selectedPerfume != null)
            {
                _shoppingCart.RemoveFromCart(selectedPerfume);
            }
            return RedirectToAction("Index");
        }

    }
}
