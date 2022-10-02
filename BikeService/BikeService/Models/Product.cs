namespace BikeService.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
            Categories = new HashSet<Category>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public float Price { get; set; }
        public int? Quantity { get; set; }
        public int ManufacturerId { get; set; }
        public int CategoryId { get; set; }
        public string StoreId { get; set; } = null!;

        public virtual Category Category { get; set; } = null!;
        public virtual Manufacturer Manufacturer { get; set; } = null!;
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
