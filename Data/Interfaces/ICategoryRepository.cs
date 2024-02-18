using System;
using DouriaPerfume.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DouriaPerfume.Data.Interfaces
{
    public interface ICategoryRepository
    {
        object Categories { get; }
    }

    IEnumerable<Category>? Categories { get; }
}

