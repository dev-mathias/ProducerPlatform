using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Producteur.Entities
{
    public class Purchase
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Product Product{ get; set; }
        public Customer Customer { get; set; }
        public double Quantity { get; set; }
    }
}
