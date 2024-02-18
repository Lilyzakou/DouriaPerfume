using DouriaPerfume.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DouriaPerfume.Data.Models;
using Microsoft.EntityFrameworkCore;
using DouriaPerfume.Data;
using Douriaperfume.Data.Models;

namespace Douriaperfume.Data.Repositories
{
    public class PerfumeRepository : IPerfumeRepository
    {
        private readonly AppDbContext _appDbContext;
        public PerfumeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Perfume> Perfumes => throw new NotImplementedException();

        public IEnumerable<Perfume> PreferredPerfumes => throw new NotImplementedException();

        public Perfume GetPerfumeById(int PerfumeId)
        {
            throw new NotImplementedException();
        }
    }
}