using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        public string Username { set; get; }
        public string Password { set; get; }
        public string Name { set; get; }
        public string LastName { set; get; }
        public int ID { set; get; }
        public string Type { set; get; }

        public override string ToString()
        {
            return "ID: "+ ID+" Username: "+Username+" Name: "+Name+" "+LastName+" Type: "+Type;
        }
    }
}
