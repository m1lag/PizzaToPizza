using System.ComponentModel.DataAnnotations;

namespace PizzaToPizza.Dtos
{
    public class RatePizzaDto
    {
        [Range(1, 5)]
        public int Stars { get; set; }
    }
}