using System.ComponentModel.DataAnnotations;

namespace PizzaToPizza.Dtos
{
    public class CreatePizzaDto
    {
        [Required]
        public string Name { get; set; } = "";

        [Required]
        public string Description { get; set; } = "";

        [Range(0.01, 9999)]
        public decimal Price { get; set; }

        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }
    }
}