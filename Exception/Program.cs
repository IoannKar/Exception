using ExceptionC;
using System;

class Program
{
    private static UserManager userManager = new();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("1. Добавить пользователя");
            Console.WriteLine("2. Удалить пользователя");
            Console.WriteLine("3. Список пользователей");
            Console.WriteLine("4. Выход");
            Console.Write("Выберите нужный вариант: ");

            string? input = Console.ReadLine();

            try
            {
                switch (input)
                {
                    case "1":
                        AddUser();
                        break;
                    case "2":
                        RemoveUser();
                        break;
                    case "3":
                        ListUsers();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Недопустимый параметр. Пожалуйста, попробуйте снова.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }

    private static void AddUser()
    {
        Console.Write("Введите идентификатор пользователя: ");
        int id = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException("Идентификатор не может быть нулевым!"));

        Console.Write("Введите имя пользователя: ");
        string? name = Console.ReadLine();

        User user = new(id, name);
        userManager.AddUser(user);
        Console.WriteLine("Пользователь успешно добавлен.");
    }

    private static void RemoveUser()
    {
        Console.Write("Введите идентификатор пользователя для удаления: ");
        int id = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException("Идентификатор не может быть нулевым!"));

        userManager.RemoveUser(id);
        Console.WriteLine("Пользователь успешно удален.");
    }

    private static void ListUsers()
    {
        Console.WriteLine("Пользователи:");
        Console.WriteLine(userManager.GetAllUsers());
    }
}