using SuperHeroApi.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperHeroApi.Models
{
    [Table("hero_table")]
    public class Heroi
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name required...")]
        [StringLength(50)]
        [PrimeiraLetra]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Power required...")]
        [StringLength(30)]
        public string? Power {  get; set; }
        [Required(ErrorMessage = "Status required...")]
        public bool StatusAtivo {  get; set; }
        
    }
}
