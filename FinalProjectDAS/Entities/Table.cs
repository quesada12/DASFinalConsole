using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Table
    {
        public int ID { get; set; }
        public int People { get; set; }
        public Boolean Available { get; set; }

        public override string ToString()
        {
            return "ID: "+ID+" Cantidad de personas: "+People+" Disponible: "+Available;
        }
    }
}
