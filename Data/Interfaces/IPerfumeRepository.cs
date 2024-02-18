using System;
using DouriaPerfume.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Douriaperfume.Data.Models;

namespace DouriaPerfume.Data.Interfaces
{
    public interface IPerfumeRepository
    {
        IEnumerable<Perfume> Perfumes { get; }
        IEnumerable<Perfume> PreferredPerfumes { get; }
        Perfume GetPerfumeById(int PerfumeId);
    }
}

