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
        public void Rent()
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
        public void Rent()
        {
            Random Cost = new Random();
            int money = Cost.Next(1000, 10000);
            Console.WriteLine("Стоимось аренды " + money + " $");
        }
    }
    public class SportsComplex : IOlimpicConstruction
    {
        string Adress { get; set; }
        int Cost;
        public void Rent()
        {
            Random Cost = new Random();
            int money = Cost.Next(1000, 10000);
            Console.WriteLine("Стоимось аренды " + money + " $");
        }
    }
    class Student
    {
        string Name { get; set; }
        int Money { get; set; }
        int Age { get; set; }
        public void CheckHostel()
        {
            Hostel hostel = new Hostel();
            hostel.Rent();
        }
        public void CheckSportComplex()
        {
            SportsComplex sportsComplex = new SportsComplex();
            sportsComplex.Rent();
        }
        public void CheckMedicalCenter()
        {
            MedicalCenter medicalCenter = new MedicalCenter();
            medicalCenter.Rent();
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
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

