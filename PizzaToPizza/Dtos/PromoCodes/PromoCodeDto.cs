namespace PizzaToPizza.Dtos
{
    public class PromoCodeDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = "";
        public int DiscountPercent { get; set; }

        public string PizzaName { get; set; } = "";

        public bool IsUsed { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsExpired { get; set; }
    }
}