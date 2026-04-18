namespace PizzaToPizza.Dtos
{
    public class PromoCodeDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = "";
        public decimal DiscountPercent { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsExpired { get; set; }
    }
}