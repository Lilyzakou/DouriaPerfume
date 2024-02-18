using Douriaperfume.Data.Models;
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
    [Route("api/[controller]")]
    public class PerfumeDataController : Controller
    {
        private readonly IPerfumeRepository _PerfumeRepository;

        public PerfumeDataController(IPerfumeRepository PerfumeRepository)
        {
            _PerfumeRepository = PerfumeRepository;
        }

        [HttpGet]
        public IEnumerable<PerfumeViewModel> LoadMoreDrinks()
        {
            IEnumerable<Perfume> dbPerfumes = null;

            dbPerfumes = _PerfumeRepository.Perfumes.OrderBy(p => p.PerfumeId).Take(10);

            List<PerfumeViewModel> Perfumes = new List<PerfumeViewModel>();

            foreach (var dbPerfume in dbPerfumes)
            {
                Perfumes.Add(MapDbDrinkToDrinkViewModel(dbPerfume));
            }
            return Perfumes;
        }

        private PerfumeViewModel MapDbDrinkToDrinkViewModel(Perfume dbPerfume) => new PerfumeViewModel()
        {
            PerfumeId = dbPerfume.PerfumeId,
            Name = dbPerfume.Name,
            Price = dbPerfume.Price,
            ShortDescription = dbPerfume.ShortDescription,
            ImageThumbnailUrl = dbPerfume.ImageThumbnailUrl
        };

    }
}
