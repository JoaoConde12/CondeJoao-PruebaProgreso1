using System.ComponentModel.DataAnnotations;

namespace CondeJoao_PruebaProgreso1.Models
{
    public class Celular
    {
        [Key]                                                                                    // Anotación 1
        public int Id { get; set; } 
        [Required]                                                                               // Anotación 2
        [MaxLength(50)]                                                                          // Anotación 3
        [Display(Name = "Modelo")]
        public string Modelo { get; set; }
        [Required]
        [Range(2000, 2024, ErrorMessage = "El año del celular debe estar entre 2000 y 2024")]    // Anotación 4
        [Display(Name = "Año")]                                                                 // Anotación 5
        public int Anio { get; set; }
        [Required]
        [Display(Name = "Precio")]
        public double Precio { get; set; }
    }
}
