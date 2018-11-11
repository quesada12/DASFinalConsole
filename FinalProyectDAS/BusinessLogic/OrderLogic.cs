using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class OrderLogic
    {
        public List<Order> Orders = new List<Order>();

        public int AddOrder(int table)
        {
            Order order = new Order(table);
            Orders.Add(order);
            return order.ID;
        }

        public decimal OrderCost(List<Product> products)
        {
            if (products.Count != 0)
            {
                decimal price = 0;
                foreach (var product in products)
                {
                    price += product.Cost;
                }
                return price;
            }
            else
            {
                return 0;
            }
        }

        public Order SearchOrderById(int id)
        {
            foreach (var order in Orders)
            {
                if (order.ID == id)
                {
                    return order;
                }
            }
            return null;
        }

        public string GetProductsString(List<Product> products)
        {
            if (products.Count != 0)
            {
                string print = "";
                foreach (var product in products)
                {
                    print += product + "\n";
                }
                return print;
            }
            else
            {
                return "No hay productos en la orden";
            }
        }

        public string GetOrderString(Order order)
        {
            return "Orden #" + order.ID + "\nProductos: \n" + GetProductsString(order.Products) + "\nMonto Orden: " + OrderCost(order.Products);
        }

        public string GetOrdersSameTableToPayString (int table)
        {
            StringBuilder final = new StringBuilder();
            foreach (var order in Orders)
            {
                if (order.Table == table && !order.Paid && order.Completed)
                {
                    final.Append(GetOrderString(order));
                    final.Append("\n");
                }
            }
            return final.ToString();
        }

        public string GetAllOrdersString()
        {
            StringBuilder final = new StringBuilder();
            foreach (var order in Orders)
            {
                    final.Append(GetOrderString(order));
                    final.Append("\n ---------------------------------------------");
            }
            return final.ToString();
        }

        public Order GetOrder(int id)
        {
            foreach (var order in Orders)
            {
                if (order.ID == id)
                {
                    return order;
                }
            }
            return null;
        }

        public void CloseOrder(Order order)
        {
            order.Cost = OrderCost(order.Products);
            order.Paid = false;
        }
    }
}
