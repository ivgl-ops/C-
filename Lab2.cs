using System;


namespace Cash
{
    public interface IOlimpicConstruction
    {
        public void Rent()
        {
            Random Cost = new Random();
            int money = Cost.Next(1000, 10000);
            Console.WriteLine("Стоимось аренды " + money + " $");
        }
    }
    public class Hostel : IOlimpicConstruction
    {
        string Adress { get; set; }
        int Cost;
        public Hostel(string adress)
        {
            Adress = adress;
        }
        void IOlimpicConstruction.Rent()
        {
            Random Cost = new Random();
            int money = Cost.Next(1000, 10000);
            Console.WriteLine("Стоимось аренды " + money + " $ " + Adress);
        }
    }
    public class MedicalCenter : IOlimpicConstruction
    {
        string Adress { get; set; }
        int Cost;
        public MedicalCenter(string adress)
        {
            Adress = adress;
        }
        void IOlimpicConstruction.Rent()
        {
            Random Cost = new Random();
            int money = Cost.Next(1000, 10000);
            Console.WriteLine("Стоимось аренды " + money + " $ " + Adress);
        }
       
    }
    public class SportsComplex : IOlimpicConstruction
    {
        string Adress { get; set; }
        int Cost { get; set; }
        public SportsComplex(string adress)
        {
            Adress = adress;
        }
        void IOlimpicConstruction.Rent()
        {
            Random Cost = new Random();
            int money = Cost.Next(1000, 10000);
            Console.WriteLine("Стоимось аренды " + money + " $" + Adress);
        }
    }
    class Student
    {
        public string Name { get; set; }
        public int Money { get; set; }
        public int Age { get; set; }
        public Student(string name, int money, int age)
        {
            Name = name;
            Money = money;
            Age = age;
        }
        public void Check(Hostel hostel)
        {
            ((IOlimpicConstruction)hostel).Rent();
        }
        public void Check(SportsComplex complex )
        {
            ((IOlimpicConstruction)complex).Rent();
        }
        public void Check(MedicalCenter medical)
        {
            ((IOlimpicConstruction)medical).Rent();
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student("Иван", 1000000, 18);
            IOlimpicConstruction medical = new MedicalCenter("По адресу пр.Свободный");
            IOlimpicConstruction sport = new SportsComplex(" По адресу ул.Киренского");
            IOlimpicConstruction hostel = new Hostel("По адресу пр.Свободный 76 Н");
            Console.WriteLine("Введите нужный вам пункт:\n 1.Аренда спорт-комплекса \n 2.Аренда медецинского центра \n 3.Аренда общежития");
            int choose = Convert.ToInt32(Console.ReadLine());
            if (choose > 3)
            {
                Console.WriteLine("Введите от 1 до 3");
                choose = Convert.ToInt32(Console.ReadLine());
            }
            if (choose < 0)
            {
                Console.WriteLine("Введите от 1 до 3");
                choose = Convert.ToInt32(Console.ReadLine());
            }

            switch (choose)
            {
                case 1:
                    {
                        sport.Rent();
                        break;
                    }
                case 2:
                    {
                        medical.Rent();
                        break;
                    }
                case 3:
                    {
                        hostel.Rent();
                        break;
                    }
            }
        }
    }
}