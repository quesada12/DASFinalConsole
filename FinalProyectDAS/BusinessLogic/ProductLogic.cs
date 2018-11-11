using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class ProductLogic
    {
        private List<Product> Products = new List<Product>();

        public ProductLogic()
        {
            Products.Add(new Product() { ID = 1, Name = "Hamburguesa", Description = "Hamburguesa de la casa", Cost = 2500 });
            Products.Add(new Product() { ID = 2, Name = "Coca Cola", Description = "Refresco Gaseoso", Cost = 800 });
            Products.Add(new Product() { ID = 3, Name = "Ensalada Cesar", Description = "Ensalada Cesar con un toque especial", Cost = 2000 });
            Products.Add(new Product() { ID = 4, Name = "New York Steak", Description = "Nuestro corte de carne magra acompañado de verduras y ensalada", Cost = 5000 });
        }

        public string AddProduct(int id, string name, string description, decimal cost)
        {
            string message = "";
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(description) || cost <= 0)
            {
                message = "Datos inválidos";
            }
            else
            {
                if (SearchByID(id) != null)
                {
                    message = "El ID del producto ya está registrado";
                }
                else
                {
                    Products.Add(new Product() { ID = id, Name = name, Description = description, Cost = cost });
                    message = "Producto agregado exitosamente";
                }
            }
            return message;
        }

        public Product SearchByID(int id)
        {
            foreach (var product in Products)
            {
                if (product.ID == id)
                {
                    return product;
                }
            }
            return null;
        }

        public string DeleteProduct(int id)
        {
            string message = "";
            if (SearchByID(id) == null)
            {
                message = "No existe producto con este ID";
            }
            else
            {
                Product product = SearchByID(id);
                Products.Remove(product);
                message = "El producto fue eliminado exitosamente";
            }
            return message;
        }

        public List<Product> GetProducts()
        {
            return Products;
        }

        public string GetProductsString()
        {
            StringBuilder final = new StringBuilder();
            foreach (var product in Products)
            {
                final.Append(product);
                final.Append("\n");
            }
            return final.ToString();
        }

    }
}
