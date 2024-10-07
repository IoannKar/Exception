using System;
using System.Collections.Generic;

namespace UserManagement
{
    class ExceptionCom
    {
        static void Main(string[] args)
        {
            UserManager userManager = new UserManager();
            string command;

            do
            {
                Console.WriteLine("\nДоступные команды:");
                Console.WriteLine("1 - Добавить пользователя");
                Console.WriteLine("2 - Удалить пользователя");
                Console.WriteLine("3 - Вывести всех пользователей");
                Console.WriteLine("exit - Выход");
                Console.Write("Введите команду: ");
                command = Console.ReadLine();

                try
                {
                    switch (command)
                    {
                        case "1":
                            userManager.AddUser();
                            break;
                        case "2":
                            userManager.RemoveUser();
                            break;
                        case "3":
                            userManager.PrintAllUsers();
                            break;
                        case "exit":
                            Console.WriteLine("Выход из программы.");
                            break;
                        default:
                            Console.WriteLine("Неизвестная команда. Попробуйте снова.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка: {ex.Message}");
                }

            } while (command != "exit");
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public User(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    public class UserManager
    {
        private List<User> users = new List<User>();
        private int nextId = 1;

        public void AddUser()
        {
            Console.Write("Введите имя пользователя: ");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Имя пользователя не может быть пустым.");

            User user = new User(nextId++, name);
            users.Add(user);

            Console.WriteLine($"Пользователь '{name}' добавлен с ID: {user.Id}");
        }

        public void RemoveUser()
        {
            Console.Write("Введите ID пользователя для удаления: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
                throw new ArgumentException("Некорректный ID.");

            User user = users.Find(u => u.Id == id);
            if (user != null)
            {
                users.Remove(user);
                Console.WriteLine($"Пользователь с ID {id} удален.");
            }
            else
            {
                throw new KeyNotFoundException($"Пользователь с ID {id} не найден.");
            }
        }

        public void PrintAllUsers()
        {
            if (users.Count == 0)
            {
                Console.WriteLine("Список пользователей пуст.");
                return;
            }

            Console.WriteLine("\nСписок пользователей:");
            foreach (var user in users)
            {
                Console.WriteLine($"ID: {user.Id}, Имя: {user.Name}");
            }
        }
    }
}