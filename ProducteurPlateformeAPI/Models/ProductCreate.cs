namespace ProducteurPlateformeAPI.Models
{
    public class ProductCreate
    {
        public string Name { get; set; }
        public string Description  {get; set;}
        public double Quantity { get; set; }
        public double Price { get; set; }
        public int ProducerId { get; set; } 
    }
}
