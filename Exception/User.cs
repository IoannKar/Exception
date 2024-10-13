using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionC
{
    public class User
    {
        public int Id { get; }
        public string Name { get; }

       
        public User(int id, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Имя не может быть пустым!", nameof(name));

            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Имя: {Name}";
        }
    }
}
