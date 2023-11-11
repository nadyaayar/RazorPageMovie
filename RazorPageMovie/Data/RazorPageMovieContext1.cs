using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPageMovie.Models;

namespace RazorPageMovie.Data
{
    public class RazorPageMovieContext1 : DbContext
    {
        public RazorPageMovieContext1 (DbContextOptions<RazorPageMovieContext1> options)
            : base(options)
        {
        }

        public DbSet<RazorPageMovie.Models.Movie> Movie { get; set; } = default!;
    }
}
