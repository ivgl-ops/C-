using System;
using System.Collections.Generic;


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
        public string Name { get; set; }
        public string Cost { get; set; }
        public void Rent()
        {
            Random Cost = new Random();
            int money = Cost.Next(100, 500);
            Console.WriteLine("Стоимось аренды общежития составит:" + money + " $");
        }
    }
    public class MedicalCenter : IOlimpicConstruction
    {
        public string Name { get; set; }
        public string Cost { get; set; }
        public void Rent()
        {
            Random Cost = new Random();
            int money = Cost.Next(6000,7000);
            Console.WriteLine("Стоимось аренды больницы соcтавит: " + money + " $");
        }
    }
    public class SportsComplex : IOlimpicConstruction
    {
        public string Name { get; set; }
        public string Cost { get; set; }
        public void Rent()
        {
            Random Cost = new Random();
            int money = Cost.Next(1000, 3000);
            Console.WriteLine("Стоимось аренды СпортКомплекса составит:" + money + " $");
        }
    }
    public class Library : IOlimpicConstruction
    {
        public void Rent()
        {
            Random Cost = new Random();
            int money = Cost.Next(1000, 10000);
            Console.WriteLine("Стоимось аренды Бибилиотеки составит: " + money + " $");
        }
        public string Name { get; set; }
        public string Cost { get; set; }
    }
    public class Separator : IOlimpicConstruction
    {
        MedicalCenter medical = new MedicalCenter();
        Library lib = new Library();
        SportsComplex complex = new SportsComplex();
        Hostel hostel = new Hostel();


        public void Rent()
        {
            Random Cost = new Random();
            int money = Cost.Next(1000, 10000);
            Console.WriteLine("Стоимось аренды " + money + " $");
        }

        public List<string> LeasedOlimpicObjects = new List<string>();
        public List<string> FreeOlimpicObjects = new List<string>();
        public void Money()
        {
            Console.WriteLine("Ваш бюджет: ");
            int budjet = Convert.ToInt32(Console.ReadLine());
            if (budjet >= 7000)
            {
                Console.WriteLine("Вы можете арендовать любой свободный обект");
            }
            if (budjet >= 4000)
            {
                Console.WriteLine("Вы можете арендовать: Библиотеку, Общежитие, СпортКомплекс ");
            }
            if (budjet >= 3000)
            {
                Console.WriteLine("Вы можете арендовать: СпортКомплекс и Общежитие ");
            }
            if (budjet >= 500)
            {
                Console.WriteLine("Вы можете арендовать: Общежитие");
            }
            if (budjet < 500)
            {
                Console.WriteLine("Вы ничего не можете арендовать");
            }

        }

        public void Add()
        {
            FreeOlimpicObjects.Add("Больница");
            FreeOlimpicObjects.Add("СпортКомплекс");
            FreeOlimpicObjects.Add("Общежитие");
            FreeOlimpicObjects.Add("Библиотека");
        }
        //код ниже реализует возврат в свободные объекты
        public void RemoveFree()
        {

            foreach (string i in LeasedOlimpicObjects)
            {
                Console.WriteLine("Объект который  находится в арене и его можно удалить :" + i);
            }
            Console.WriteLine("Введите имя объекта который хотите удалить:");
            string obj = Console.ReadLine();
            if (obj == "Больница")
            {
                LeasedOlimpicObjects.Remove("Больница");
                FreeOlimpicObjects.Insert(0,"Больница");
            }
            if (obj == "СпортКомплекс")
            {
                LeasedOlimpicObjects.Remove("СпортКомплекс");
                FreeOlimpicObjects.Insert(1,"СпортКомплекс");

            }
            if (obj == "Общежитие")
            {
                LeasedOlimpicObjects.Remove("Общежитие");
                FreeOlimpicObjects.Insert(2, "Общежитие");

            }
            if (obj == "Бибилиотека")
            {
                LeasedOlimpicObjects.Remove("Бибилиотека");
                FreeOlimpicObjects.Insert(3, "Бибилиотека");
            }
                foreach (string i in LeasedOlimpicObjects)
            {
                Console.WriteLine();
                Console.WriteLine("Обьект " + i + " находится в Аренде");
            }
            foreach (string i in FreeOlimpicObjects)
            {
                Console.WriteLine(i);
            }
        }


        //код ниже реализует аренду объектов
        public void Remove()
        {
            Console.WriteLine("Выбор объекта: ");

            Console.WriteLine("Cвободные обьекты:");
            foreach (string i in FreeOlimpicObjects)
            { 
                Console.WriteLine(i);
            }

            int obj = Convert.ToInt32(Console.ReadLine());
            switch (obj)
            {
                case 1:
                    {
                        FreeOlimpicObjects.RemoveAt(0);
                        LeasedOlimpicObjects.Add("Больница");
                        medical.Rent();
                        break;
                    }

                case 2:
                    {
                        FreeOlimpicObjects.RemoveAt(1);
                        LeasedOlimpicObjects.Add("СпортКомплекс");
                        complex.Rent();
                        break;
                    }
                case 3:
                    {
                        FreeOlimpicObjects.RemoveAt(2);
                        LeasedOlimpicObjects.Add("Общежитие");
                        hostel.Rent();
                        break;
                    }
                case 4:
                    {
                        FreeOlimpicObjects.RemoveAt(3);
                        LeasedOlimpicObjects.Add("Библиотека");
                        lib.Rent();
                        break;
                    }

            }
            foreach (string i in LeasedOlimpicObjects)
            {
                Console.WriteLine("Обьект " + i + " арендован");
            }
        
        }
        public void CheckFreeObj()
        {
            foreach (string i in FreeOlimpicObjects)
            {
                Console.WriteLine(i);
            }
        }
        public void CheckLeasedObj()
        {
            foreach (string i in LeasedOlimpicObjects)
            {
                Console.WriteLine(i);
            }
        }

       
    }

    class Program
    {
        static void Main(string[] args)
        {
            Separator separator = new Separator();
            separator.Add();
            while (true)
            {
                Console.WriteLine("\n-------------------------------\n*******************************");
                Console.WriteLine("Выбирите нужный вам пункт:");
                Console.WriteLine("1.Арендовать объект");
                Console.WriteLine("2.Удалить объект из аренды");
                Console.WriteLine("3.Посмотерть доступные объекты");
                Console.WriteLine("4.Подобрать объект по бюджету");
                Console.WriteLine("5.Посмотреть арендованные");
                Console.WriteLine("\n*******************************\n-------------------------------");
                int choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        {
                            separator.Remove();
                            break;
                        }
                    case 2:
                        {
                            
                            separator.RemoveFree();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Свободные Объекты:");
                            separator.CheckFreeObj();
                            break;
                        }
                    case 4:
                        {
                            separator.Money();
                            break;
                        }
                    case 5:
                        {
                            separator.CheckLeasedObj();
                            break;
                        }

                }
            }
        }
    }
}


