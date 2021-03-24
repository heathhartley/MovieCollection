using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Models
{
    public class EFMovieRepository : IMovieRepository
    {
        private MoviesDbContext _context;
        //constructor
        public EFMovieRepository (MoviesDbContext context)
        {
            _context = context;
        }

        public IQueryable<EnterMovie> Movies => _context.Movies;
    }
}
