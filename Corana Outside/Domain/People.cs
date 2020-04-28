using System;

namespace Domain
{
    public enum Surname
    {
        Бонд,
        Кардашьян,
        Рокет,
        Фреско,
        Маск
    }
    public class People
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Surname surname { get; set; }
        string statusAge = "лет";
        public override string ToString()
        {
            return Name + surname +  " " + Age + " " + statusAge;
        }
        
    }
}
