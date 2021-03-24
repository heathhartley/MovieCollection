using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Models
{
    public class EnterMovie
    {
        [Key]
        public int  MovieId { get; set; }
        public Boolean edited { get; set; }
        [MaxLength(25, ErrorMessage = "You cannot enter more notes")]
        public string note { get; set; }
        public string rating { get; set; }
        public string category { get; set; }
        [Required]
        public string title { get; set; }
        

        [Required(ErrorMessage = "Year is a required field")]
        public int year { get; set; }
        [Required(ErrorMessage = "Director is a required field")]
        public string director { get; set; }
    }
}
