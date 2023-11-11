using System.ComponentModel.DataAnnotations; //agregando librería que vamos a usar
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPageMovie.Models
{
    public class Movie
    {
        public int Id { get; set; } //int = entero, get y set significa que queremos que tome los datos y los muestre
        [StringLength(60, MinimumLength =3)]
        [Required]
        public string? Title { get; set; } //el signo porque puede o no estar dentro de nuestro sistema o el dato puede ser nulo
        [Display(Name = "Realese Date")]
        [DataType(DataType.Date)] //etiqueta se pone con corchetes y especifica el formato
        public DateTime RealeseDate { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(30)]
        public string? Genre { get; set; } //string alfanumérico
        [Range(1,100)]
        [DataType(DataType.Currency)]
        [Column (TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [StringLength(5)]
        [Required]
        public string? Rating { get; set; }
    }
}
