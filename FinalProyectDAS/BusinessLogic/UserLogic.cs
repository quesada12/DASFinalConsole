using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class UserLogic
    {
        public UserLogic()
        {

        }
        List<User> users = new List<User>();
        public string createUser(string username, string password, string name, string lastName, int id, string type)
        {
            User user;
            string mensaje = "";
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(type))
            {
                mensaje = "Por favor verifique que se haya ingresado todos los datos requeridos.";
            }
            else
            {
                if (SearchUserByUsername(username) != null)
                {
                    mensaje = "El nombre de usuario ingresado ya existe dentro del sistema.";
                }
                else
                {
                    user = new User() { Username = username, Password = password, Name = name, LastName = lastName, ID = id, Type = type };
                    users.Add(user);
                    mensaje = "Usuario agregado correctamente. \nNombre: " + name + " " + lastName + "\nRol asignado: " + type;
                }
            }
            return mensaje;
        }

        public User SearchUserByUsername(string username)
        {
            User user = null;
            foreach (User i in users)
            {
                if (i.Username == username)
                {
                    user = i;
                }
            }
            return user;
        }

        public User SearchUserById(int id)
        {
            User user = null;
            foreach (User i in users)
            {
                if (i.ID == id)
                {
                    user = i;
                }
            }
            return user;
        }

        public string DeleteUser(string username, string loggedUsername)
        {
            string mensaje = "";
            User user;
            if (SearchUserByUsername(username).Username == username)
            {
                if (SearchUserByUsername(username).Username != loggedUsername)
                {
                    user = SearchUserByUsername(username);
                    users.Remove(user);
                    mensaje = "Usuario " + user.Username + " eliminado correctamente";
                }
                else
                {
                    mensaje = "No puede eliminar su mismo usuario";
                }
            }
            else
            {
                mensaje = "El usuario que se encuentra eliminar no se encuentra en el sistema";
            }
            return mensaje;
        }

        public List<User> GetUsersList()
        {
            return users;
        }

        public string GetUsersListString()
        {
            StringBuilder final = new StringBuilder();
            foreach (var user in users)
            {
                final.Append(user);
                final.Append("\n");
            }
            return final.ToString();
        }
    }
}
