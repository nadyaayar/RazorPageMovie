using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore; //using para agregar la librería a importar
using RazorPageMovie.Data;

namespace RazorPageMovie.Models
{
    public static class SeedData //static porque siempre van a ser esos datos
    {
        public static void Initialize(IServiceProvider serviceProvider) //agregado a partir de está línea
        {
            using (var context = new RazorPageMovieContext1(
                serviceProvider.GetRequiredService<  //trae la parte de servicios para nuestra base de datos
                    DbContextOptions<RazorPageMovieContext1>>()))
            { 
                if (context == null || context.Movie == null) 
                {
                    throw new ArgumentNullException("Null RazorPageMovieContext"); //en caso de que el contexto de la película esté nulo, envía mensaje               
                }
                if (context.Movie.Any())
                {
                    //base de datos muestra todo lo que contiene esta clase
                    return;
                }
                context.Movie.AddRange(  //es donde vamos a poner toda la información de los datos de las películas, pasándolo del modelo a la base de datos
                    new Movie
                    {
                        Title = "When Harry Met Sally",
                        RealeseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Romantic Comedy",
                        Price = 7.99M,
                        Rating = "R"
                    },

                    new Movie
                    {
                        Title = "Ghostbusters",
                        RealeseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Comedy",
                        Price = 8.99M,
                        Rating = "G"
                    },

                    new Movie
                    {
                        Title = "Ghostbusters2",
                        RealeseDate = DateTime.Parse("1989-2-23"),
                        Genre = "Comedy",
                        Price = 9.99M,
                        Rating = "G"
                    },

                    new Movie
                    {
                        Title = "Rio Bravo",
                        RealeseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Western",
                        Price = 3.99M,
                        Rating = "NA"
                    }
                  );
                context.SaveChanges();
            }
        }
    }
}
