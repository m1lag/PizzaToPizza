namespace PizzaToPizza.Dtos
{
    public class UpdatePromoCodeDto
    {
        public string Code { get; set; } = "";
        public decimal DiscountPercent { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}