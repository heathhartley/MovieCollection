using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieCollection.Models;
using MovieCollection.Models.View_Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IMovieRepository _repository;
        private MoviesDbContext _context;

        public HomeController(ILogger<HomeController> logger, IMovieRepository repository, MoviesDbContext context)
        {
            _logger = logger;
             _repository = repository;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        //this returns the add movie view without passing in the information 
        public IActionResult AddMovies()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddMovies(EnterMovie enterMovie)
        {
            //see if the data is valid
            if (ModelState.IsValid)
            {
                // save movie to database


                _context.Movies.Add(enterMovie);
                _context.SaveChanges();
                MovieList movies = new MovieList { Movies = _context.Movies.Where(m => m.title != "Independence Day") };
                // go to conformation page
                return View("Conformation", enterMovie);
            }
            else
            {
                //if the data isnt valid stay on the same page
                return View("AddMovies");
            }


           
        }

            public IActionResult Conformation()
        {
            return View();
        }
        //on get show the list of movies
        [HttpGet]
        public IActionResult List()
        {
            return View(new MovieEditList { EnterMovies = _context.Movies.Where(m => m.title != "Independence Day") });
        }
        //
        [HttpPost]
        public IActionResult List(int movie_id)
        {
            return View(new MovieEditList { EnterMovies = _context.Movies.Where(m => m.title != "Independence Day") });
        }
       
        //when you get the movie i will pass in the movie Id and show the box for that
        [HttpGet]
        public IActionResult EditMovies()
        {
            return View(new MovieEditList { EnterMovies = _context.Movies.Where(m => m.title != "Independence Day") });
        }
        [HttpPost]
        public IActionResult EditMovies(int movie_id)
        {
            //on post show the move they want to edit using the movie id
            return View(new MovieEditList { EnterMovies = _context.Movies.Where(m => m.MovieId == movie_id) });
        }
        public IActionResult SaveChanges(int movie_id, string title, string rating, int year, bool edited, string director, string note, string category)
        {

            // get edited movies
            EnterMovie movie = _context.Movies.Where(m => m.MovieId == movie_id).FirstOrDefault();
            //update values that the user entered
            movie.title = title;
            movie.rating = rating;
            movie.year = year;
            movie.edited = edited;
            movie.director = director;
            movie.category = category;
         
            movie.note = note;

            _context.SaveChanges();
            //instead of going to a conforamtion page redirect to the list of movies
            return Redirect("/Home/List");
        }
        public IActionResult DeleteMovie(int movie_id)
        {
            //find the movie id where you want to delete it 
            EnterMovie movie = _context.Movies.Where(m => m.MovieId == movie_id).FirstOrDefault();
            //delete the movie and redirect to the list
            _context.Remove(movie);
            _context.SaveChanges();
            return Redirect("/Home/List");
        }

        public IActionResult Podcast()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
