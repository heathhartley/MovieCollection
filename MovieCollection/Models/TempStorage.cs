using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Models
{
    public class TempStorage
    {
        private static List<EnterMovie> movie_entries = new List<EnterMovie>();

        // iteratable list
        public static IEnumerable<EnterMovie> movieEntries => movie_entries;

        public static void addMovie(EnterMovie movie)
        {
            movie_entries.Add(movie);
        }
    }
}
