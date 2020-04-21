using System;

namespace fire_department
{
    interface IInflammable
    {
        public string Region { get; set; }
        public int Degree { get; set; }

    }
    public class House : IInflammable
    {
        Random rnd = new Random();
        public string Region { get; set; }
        public int Degree { get; set; }
        public event EventHandler FireDegree;
        //FEMA = МЧС
        public event EventHandler FireDegreeFEMA;
        public string[] shore = { "левом берегу", "правом берегу" };
        public int[] random_dig = { 1, 2, 3 };


        public void change_shore()
        {
            int digit = rnd.Next(shore.Length);
            Region = shore[digit];
            Console.WriteLine("Пожар произошел в доме на {0}", shore[digit], Region);
            int dig = rnd.Next(random_dig.Length);
            Degree = random_dig[dig];
            Console.WriteLine("Степень пожара равна: {0}", random_dig[dig]);
            if (Degree == 1)
            {
                if (FireDegree != null)
                {
                    FireDegree(this, new EventArgs());
                }
            }
            else if (Degree == 2)
            {
                if (FireDegree != null)
                {
                    FireDegree(this, new EventArgs());
                }
            }
            else
            {
                if (FireDegreeFEMA != null)
                {
                    FireDegreeFEMA(this, new EventArgs());
                }
            }

        }

    }
    public class Garage : IInflammable
    {
        Random rnd = new Random();
        public string Region { get; set; }
        public int Degree { get; set; }
        public event EventHandler FireDegree;
        //FEMA = МЧС
        public event EventHandler FireDegreeFEMA;
        public string[] shore = { "левом берегу", "правом берегу" };
        public int[] random_dig = { 1, 2, 3 };
        public void change_shore()
        {
            int digit = rnd.Next(shore.Length);
            Region = shore[digit];
            Console.WriteLine("Пожар произошел в подсобке на {0}", shore[digit], Region);
            int dig = rnd.Next(random_dig.Length);
            Degree = random_dig[dig];
            Console.WriteLine("Степень пожара равна: {0}", random_dig[dig]);
            if (Degree == 1 || Degree == 2)
            {
                if (FireDegree != null)
                {
                    FireDegree(this, new EventArgs());
                }
            }
            else
            {
                if (FireDegreeFEMA != null)
                {
                    FireDegreeFEMA(this, new EventArgs());
                }
            }
        }

    }
    public class Forest : IInflammable
    {
        Random rnd = new Random();
        public string Region { get; set; }
        public int Degree { get; set; }
        public event EventHandler FireDegree;
        //FEMA = МЧС
        public event EventHandler FireDegreeFEMA;
        public string[] shore = { "левом берегу", "правом берегу" };
        public int[] random_dig = { 1, 2, 3 };
        public void change_shore()
        {
            int digit = rnd.Next(shore.Length);
            Region = shore[digit];
            Console.WriteLine("Пожар произошел в лесу на {0}", shore[digit], Region);
            int dig = rnd.Next(random_dig.Length);
            Degree = random_dig[dig];
            Console.WriteLine("Степень пожара равна: {0}", random_dig[dig]);
            if (Degree == 1 || Degree == 2)
            {
                if (FireDegree != null)
                {
                    FireDegree(this, new EventArgs());
                }
            }
            else
            {
                if (FireDegreeFEMA != null)
                {
                    FireDegreeFEMA(this, new EventArgs());
                }
            }
        }

    }
    public class FireStation : IInflammable
    {
        Random rnd = new Random();
        public string Region { get; set; }
        public int Degree { get; set; }
        public event EventHandler FireDegree;
        //FEMA = МЧС
        public event EventHandler FireDegreeFEMA;
        public string[] shore = { "левом берегу", "правом берегу" };
        public int[] random_dig = { 1, 2, 3 };
        public void change_shore()
        {
            int digit = rnd.Next(shore.Length);
            Region = shore[digit];
            Console.WriteLine("Пожар произошел на пожарной станции на {0}", shore[digit], Region);
            int dig = rnd.Next(random_dig.Length);
            Degree = random_dig[dig];
            Console.WriteLine("Степень пожара равна: {0}", random_dig[dig]);
            if (Degree == 1 || Degree == 2)
            {
                if (FireDegree != null)
                {
                    FireDegree(this, new EventArgs());
                }
            }
            else
            {
                if (FireDegreeFEMA != null)
                {
                    FireDegreeFEMA(this, new EventArgs());
                }
            }
        }
    }

    
    class Program
    {
        private static void OnFireDegree(object sender, EventArgs eventArgs)
        {
            if (sender is House || sender is Garage || sender is Forest || sender is FireStation)
            {
                Console.WriteLine("Пожарная машина выехала");
            }
        }
        private static void FireDegreeFEMA(object sender, EventArgs eventArgs)
        {
            if (sender is House || sender is Garage || sender is Forest || sender is FireStation)
            {
                Console.WriteLine("МЧС подключило свои силы");
            }
        }
        static void Main(string[] args)
        {
            var rnd = new Random();
            var house = new House();
            house.FireDegree += OnFireDegree;
            house.FireDegreeFEMA += FireDegreeFEMA;
            var garage = new Garage();
            garage.FireDegree += OnFireDegree;
            garage.FireDegreeFEMA += FireDegreeFEMA;
            var forest = new Forest();
            forest.FireDegree += OnFireDegree;
            forest.FireDegreeFEMA += FireDegreeFEMA;
            var fireStation = new FireStation();
            fireStation.FireDegree += OnFireDegree;
            fireStation.FireDegreeFEMA += FireDegreeFEMA;
            int fireBall = rnd.Next(1, 4);

            switch (fireBall)
            {
                case 1:
                    {
                        house.change_shore();
                        break;
                    }
                case 2:
                    {
                        garage.change_shore();
                        break;
                    }
                case 3:
                    {
                        forest.change_shore();
                        break;
                    }
                case 4:
                    {
                        fireStation.change_shore();
                        break;
                    }
            }

        }
    }
}
