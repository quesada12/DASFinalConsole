using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Order
    {

        private static int counter = 0;
        public int ID { set; get; }
        public int Table { set; get; }
        public List<Product> Products = new List<Product>();
        public decimal Cost { set; get; }
        public Boolean Paid { get; set; }
        public Boolean Completed { get; set; }

        public Order(int Table)
        {
            ID = ++counter;
            this.Table = Table;
            Products = new List<Product>();
            Cost = 0;
            Paid = false;
            Completed = false;
        }

        
    }
}
