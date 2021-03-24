using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Models.View_Models
{
    public class MovieEditList
    {
        public IEnumerable<EnterMovie> EnterMovies { get; set; }
        public int Edit_ID { get; set; }
        public bool Editing { get; set; }
    }
}
