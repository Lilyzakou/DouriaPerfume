using Douriaperfume.Data.Models;
using DouriaPerfume.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DouriaPerfume.ViewModels
{
    public class PerfumesListViewModel
    {
        public IEnumerable<Perfume> Perfumes { get; set; }
    public string CurrentCategory { get; set; }
    }
    }
