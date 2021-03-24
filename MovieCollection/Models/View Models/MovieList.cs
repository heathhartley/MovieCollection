using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Models.View_Models
{
    public class MovieList
    {
        public IEnumerable<EnterMovie> Movies { get; set; }
    }
}
