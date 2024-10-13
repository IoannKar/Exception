using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionC
{
    public class UserManager
    {
        private readonly List<User> users = new();

        public void AddUser(User user)
        {
            if (users.Exists(u => u.Id == user.Id))
                throw new InvalidOperationException("Пользователь с таким же идентификатором уже существует.");

            users.Add(user);
        }

        public void RemoveUser(int id)
        {
            User userToRemove = users.Find(u => u.Id == id);
            if (userToRemove == null)
                throw new KeyNotFoundException("Пользователь не найден.");

            users.Remove(userToRemove);
        }

        public string GetAllUsers()
        {
            return users.Count > 0 ? string.Join(Environment.NewLine, users) : "Нет доступных пользователей.";
        }
    }
}
