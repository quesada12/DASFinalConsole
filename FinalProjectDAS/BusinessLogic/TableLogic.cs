using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class TableLogic
    {
        List<Table> Tables = new List<Table>();

        public TableLogic()
        {
            Tables.Add(new Table() { ID = 1, People = 4, Available = true });
            Tables.Add(new Table() { ID = 2, People = 2, Available = true });
            Tables.Add(new Table() { ID = 3, People = 10, Available = true });
            Tables.Add(new Table() { ID = 4, People = 4, Available = true });
            Tables.Add(new Table() { ID = 5, People = 3, Available = true });
        }

        public string AddTable(int id, int people)
        {
            string message = "";
            if (people <= 0)
            {
                message = "Datos inválidos";
            }
            else
            {
                if (SearchById(id) != null)
                {
                    message = "Ya existe una mesa con este ID";
                }
                else
                {
                    Tables.Add(new Table() { ID = id, People = people, Available = true });
                    message = "Mesa agregada correctamente";
                }
            }
            return message;
        }

        public Table SearchById(int id)
        {
            foreach (var table in Tables)
            {
                if (table.ID == id)
                {
                    return table;
                }
            }
            return null;
        }

        public Table SearchByPeople(int people)
        {
            foreach (var table in Tables)
            {
                if (table.People == people && table.Available)
                {
                    return table;
                }
            }
            return null;
        }

        public string ChangeStatus(int id)
        {
            foreach (var table in Tables)
            {
                if (table.ID == id)
                {
                    if (table.Available)
                    {
                        table.Available =false;
                        return "La mesa " + id + " ha cambiado su estado a ocupada";
                    }
                    else
                    {
                        return "Error \n La mesa " + id + " se encuentra ocupada";
                    }
                }
            }

            return "No existe mesa con este id";
        }

        public List<Table> GetAvailableTables()
        {
            List<Table> TablesA = new List<Table>();
            foreach (var table in Tables)
            {
                if (table.Available)
                {
                    TablesA.Add(table);
                }
            }
            return TablesA;
        }

        public List<Table> GetTables()
        {
            return Tables;
        }

        public string GetTablesString()
        {
            StringBuilder final = new StringBuilder();
            foreach (var table in Tables)
            {
                final.Append(table);
                final.Append("\n");
            }
            return final.ToString();
        }

    }
}
