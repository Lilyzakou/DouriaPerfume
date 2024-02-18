using Douriaperfume.Data.Models;
using DouriaPerfume.Data.Interfaces;
using DouriaPerfume.Data.Interfaces;
using DouriaPerfume.Data.Models;
using DouriaPerfume.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DouriaPerfume.Controllers
{
    public class PerfumeController : Controller
    {
        private readonly IPerfumeRepository _perfumeRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PerfumeController(IPerfumeRepository PerfumeRepository, ICategoryRepository categoryRepository)
        {
            _perfumeRepository = PerfumeRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Perfume> Perfumes;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                Perfumes = _perfumeRepository.Perfumes.OrderBy(p => p.PerfumeId);
                currentCategory = "All Perfumes";
            }
            else
            {
                if (string.Equals("Men", _category, StringComparison.OrdinalIgnoreCase))
                    Perfumes = _perfumeRepository.Perfumes.Where(p => p.Category.CategoryName.Equals("Men")).OrderBy(p => p.Name);
                else
                    Perfumes = _perfumeRepository.Perfumes.Where(p => p.Category.CategoryName.Equals("Women")).OrderBy(p => p.Name);

                currentCategory = _category;
            }

            return View(new PerfumesListViewModel
            {
                Perfumes = Perfumes,
                CurrentCategory = currentCategory
            });
        }

        public ViewResult Search(string searchString)
        {
            string _searchString = searchString;
            IEnumerable<Perfume> Perfumes;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(_searchString))
            {
                Perfumes = _perfumeRepository.Perfumes.OrderBy(p => p.PerfumeId);
            }
            else
            {
                Perfumes = _perfumeRepository.Perfumes.Where(p => p.Name.ToLower().Contains(_searchString.ToLower()));
            }

            return View("~/Views/Perfume/List.cshtml", new PerfumesListViewModel { Perfumes = Perfumes, CurrentCategory = "All Perfumes" });
        }

        public ViewResult Details(int PerfumeId)
        {
            var Perfume = _perfumeRepository.Perfumes.FirstOrDefault(d => d.PerfumeId == PerfumeId);
            if (Perfume == null)
            {
                return View("~/Views/Error/Error.cshtml");
            }
            return View(Perfume);
        }
    }
}