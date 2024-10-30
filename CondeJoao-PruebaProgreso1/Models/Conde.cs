using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CondeJoao_PruebaProgreso1.Models
{
    public class Conde
    {
        [Key]                                                                             // Anotación 1
        public int Id { get; set; } 

        [Required]                                                                        // Anotación 2
        [MaxLength(100)]                                                                  // Anotación 3
        [Display(Name = "Nombre:")]                                                       // Anotación 4
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Solo letras y espacios")]    // Anotación 5
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Presupuesto:")]
        public double Presupuesto { get; set; }

        [Required]
        [Display(Name = "¿Tiene trabajo?:")]
        public bool TieneTrabajo {  get; set; }

        [Required]
        [Display(Name = "Fecha de nacimiento:")]
        public DateTime FechaNacimiento {  get; set; }

        [Display(Name = "Celular:")]
        public Celular? Celular { get; set; }

        [ForeignKey(nameof(Celular))]
        public int IdCelular { get; set; }
    }
}
