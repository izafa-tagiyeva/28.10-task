using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.models
{
    public class Room
    {
        private static int _id = 0;
        public int Id { get; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int PersonCapacity { get; set; }
        public bool IsAvailable { get; set; } = true;

        public Room(string name, decimal price, int personCapacity)
        {
            
            Id = ++_id;
            Name = name;
            Price = price;
            PersonCapacity = personCapacity;
        }

        public override string ToString()
        {
            return ShowInfo();
        }

        public string ShowInfo()
        {
            return $"Room ID: {Id}, Name: {Name}, Price: {Price}, Capacity: {PersonCapacity}, Available: {IsAvailable}";
        }
    }
}
/*Room class
===============
- Id - qıraqdan set etmək olmayacaq yalnız get etmək olacaq və hər dəfə yeni bir Room obyekt yaradıldıqda avtomatik bir vahid artacaq.
- Name
- Price
- PersonCapacity - otağın neçə nəfərlik olduğunu bildirir.
- IsAvialable - otağın rezervasiya olunub olunmadığını göstərir, default olaraq true olmalıdır.

ToString methodunu override edirsiz və geriyə ShowInfo methodunu qaytarırsız.

ps: Name, Price, PersonCapacity olmadan Room obyekti yaratmaq olmaz
*/