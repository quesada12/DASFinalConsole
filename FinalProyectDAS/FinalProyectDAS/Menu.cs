using BusinessLogic;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProyectDAS
{
    public class Menu
    {
        UserLogic userLo = new UserLogic();
        ProductLogic productLo = new ProductLogic();
        TableLogic tableLo = new TableLogic();
        OrderLogic orderLo = new OrderLogic();
        BillLogic billLo = new BillLogic();
        WaiterLogic waiterLo;
        ClientLogic clientLo;
        CashierLogic cashierLo;

        public Menu()
        {
            userLo.createUser("cajero", "12345", "Usuario", " Cajero", 1, "cashier");
            userLo.createUser("mesero", "12345", "Usuario", " Mesero",2, "waiter");
            userLo.createUser("admin", "12345", "Usuario", " Administrador", 3, "admin");
            waiterLo = new WaiterLogic(tableLo, orderLo);
            clientLo = new ClientLogic(orderLo, productLo);
            cashierLo = new CashierLogic(orderLo, billLo);
        }


        public void ShowMenu()
        {
            Boolean exit = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Demo Restaurante\n\n1- Cliente\n2- Mesero\n3- Administrador\n4- Salir");
                int tipo = Int16.Parse(Console.ReadLine());
                User user = userLo.SearchUserById(tipo);
                switch (tipo)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Digite el número de orden: ");
                        int id = Int16.Parse(Console.ReadLine());
                        if (orderLo.SearchOrderById(id) != null)
                        {
                            Order order = orderLo.SearchOrderById(id);
                            ClientMenu(order);
                        }
                        else
                        {
                            Console.WriteLine("Orden no existe");
                            Console.ReadKey();
                        }
                        break;
                    case 2:
                        Console.Clear();
                        WaiterMenu(user);
                        break;
                    case 3:
                        Console.Clear();
                        AdminMenu(user);
                        break;
                    case 4:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Opcion incorrecta");
                        Console.ReadKey();
                        break;
                }
            } while (!exit);
        }

        public void ClientMenu(Order order)
        {
            Boolean exit = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Cliente\n\n1- Agregar Producto \n2- Ver orden\n3- Salir");
                int opc = Int16.Parse(Console.ReadLine());
                switch (opc)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine(productLo.GetProductsString());
                        Console.WriteLine("Digite el ID del producto: ");
                        int productId = Int16.Parse(Console.ReadLine());
                        if (productLo.SearchByID(productId) != null)
                        {
                            Product product = productLo.SearchByID(productId);
                            Console.WriteLine(clientLo.AddProductToAnOrder(order.ID, product));
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("ID Producto incorrecto");
                        }
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine(orderLo.GetOrderString(order));
                        Console.ReadKey();
                        break;
                    case 3:
                        exit = true;
                        break;

                }
            } while (!exit);
        }

        public void WaiterMenu (User user)
        {
            Boolean exit = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Mesero\n\n1- Atender Cliente \n2- Ver ordenes\n3- Salir");
                int opc = Int16.Parse(Console.ReadLine());
                switch (opc)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Espacio para cuantas personas: ");
                        int people = Int16.Parse(Console.ReadLine());
                        Console.WriteLine(waiterLo.NewClient(people));
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine(orderLo.GetAllOrdersString());
                        Console.ReadKey();
                        break;
                    case 3:
                        exit = true;
                        break;
                
                }
            } while (!exit);
        }
    
        public void AdminMenu(User user)
        {
            Boolean exit = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Administrador\n\n1- Ver usuarios\n2- Crear Usuario\n3- Eliminar Usuario\n4- Ver Productos\n5- Agregar Producto\n6- Eliminar Producto\n7- Ver todas las mesas\n8- Agregar nueva mesa\n9- Salir");
                int opc = Int16.Parse(Console.ReadLine());
                switch (opc)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine(userLo.GetUsersListString());
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine(userLo.createUser("prueba", "12345", "prueba", "prueba", 100, "client"));
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Digite el nombre de usuario a eliminar: ");
                        string username = Console.ReadLine();
                        Console.WriteLine(userLo.DeleteUser(username, user.Username));
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine(productLo.GetProductsString());
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine(productLo.AddProduct(8,"ProductoPrueba","DescripPrueba",0));
                        Console.ReadKey();
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("Digite el id del producto a eliminar: ");
                        int id = Int16.Parse(Console.ReadLine());
                        Console.WriteLine(productLo.DeleteProduct(id));
                        Console.ReadKey();
                        break;
                    case 7:
                        Console.Clear();
                        Console.WriteLine(tableLo.GetTablesString());
                        Console.ReadKey();
                        break;
                    case 8:
                        Console.Clear();
                        Console.WriteLine(tableLo.AddTable(12,25));
                        Console.ReadKey();
                        break;
                    case 9:
                        exit = true;
                        break;
                }
            } while (!exit);
        }


    }
}
