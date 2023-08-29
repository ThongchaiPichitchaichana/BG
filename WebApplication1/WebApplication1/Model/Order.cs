namespace WebApplication1.Model
{
    public class Order
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int  Quantity { get; set; }
        public DateTime? OrderDate { get; set; }
        public int RegionId { get; set; }
        public int CityId { get; set; }
    }
}
