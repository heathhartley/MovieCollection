﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Models
{
    public interface IMovieRepository
    {
        IQueryable<EnterMovie> Movies { get; }
    }
}
