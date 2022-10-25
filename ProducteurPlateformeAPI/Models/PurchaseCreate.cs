namespace ProducteurPlateformeAPI.Models
{
    public class PurchaseCreate
    {
        public DateTime Date { get; set; }
        public int ProductId{ get; set; }
        public int CustomerId{ get; set; }
        public double Quantity { get; set; }
    }
}
