using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Bill
    {
        private static int Counter = 0;
        public int ID { set; get; }
        public string Name { set; get; }
        public List<Order> Orders = new List<Order>();
        public decimal Tax { get; set; }
        public decimal Cost { get; set; }
        public decimal FinalCost { get; set; }

        public Bill(string Client)
        {
            ID = Counter++;
            this.Name = Client;
            Orders = new List<Order>();
            Tax = 0;
            Cost = 0;
            FinalCost = 0;
        }
    }
}
