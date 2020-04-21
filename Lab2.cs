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
        void IOlimpicConstruction.Rent()
        {
            Random Cost = new Random();
            int money = Cost.Next(1000, 10000);
            Console.WriteLine("Стоимось аренды " + money + " $");
        }
    }
    public class MedicalCenter : IOlimpicConstruction
    {
        string Adress { get; set; }
        int Cost;
        void IOlimpicConstruction.Rent()
        {
            Random Cost = new Random();
            int money = Cost.Next(1000, 10000);
            Console.WriteLine("Стоимось аренды " + money + " $");
        }
    }
    public class SportsComplex : IOlimpicConstruction
    {
        string Adress { get; set; }
        int Cost { get; set; }
        void IOlimpicConstruction.Rent()
        {
            Random Cost = new Random();
            int money = Cost.Next(1000, 10000);
            Console.WriteLine("Стоимось аренды " + money + " $");
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
        public void CheckHostel()
        {
            Hostel hostel = new Hostel();
            ((IOlimpicConstruction)hostel).Rent();
        }
        public void CheckSportComplex()
        {
            SportsComplex sportsComplex = new SportsComplex();
            ((IOlimpicConstruction)sportsComplex).Rent();
        }
        public void CheckMedicalCenter()
        {
            MedicalCenter medicalCenter = new MedicalCenter();
            ((IOlimpicConstruction)medicalCenter).Rent();
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student("Иван", 1000000, 18);
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
                        student.CheckSportComplex();
                        break;
                    }
                case 2:
                    {
                        student.CheckMedicalCenter();
                        break;
                    }
                case 3:
                    {
                        student.CheckHostel();
                        break;
                    }
            }
        }
    }
}