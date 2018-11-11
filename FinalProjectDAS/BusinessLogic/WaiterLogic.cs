using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class WaiterLogic
    {
        TableLogic tableLo;
        OrderLogic orderLo;

        public WaiterLogic(TableLogic tableLo, OrderLogic orderLo)
        {
            this.orderLo = orderLo;
            this.tableLo = tableLo;
        }

        public string NewClient(int people)
        {
            StringBuilder message = new StringBuilder();
            if (tableLo.SearchByPeople(people) != null) //si hay mesas disponibles
            {
                Table table = tableLo.SearchByPeople(people);
                message.Append(tableLo.ChangeStatus(table.ID));
                int orderId = orderLo.AddOrder(table.ID);
                message.Append("\nSu número de orden es: "+orderId+" pase adelante");
            }
            else
            {
                message.Append("Lo sentimos no hay mesas disponibles");
            }
            return message.ToString();
        }

      

    }
}
