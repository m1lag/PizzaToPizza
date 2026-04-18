using System.ComponentModel.DataAnnotations;

namespace PizzaToPizza.Dtos
{
    public class CreateOrderDto
    {
        [MinLength(1)]
        public List<int> PizzaIds { get; set; } = new();
    }
}