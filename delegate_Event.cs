using System;

namespace ConsoleApp1
{
    class Boozer
    {
        public int BoozerAmount { get; private set; }
        public event EventHandler Olied;
        public Boozer()
        {
            BoozerAmount = 100;
        }
        public void LetsGodrink()
        {
            for (int i = BoozerAmount; i >= 0; i--)
            {
                if (BoozerAmount == 0)
                {
                    if (Olied != null)
                    {
                        Olied(this, new EventArgs());
                    }
                }
                BoozerAmount--;
            }
        }

    }
    class Gopnik
    { 
        public int Semki { get; private set; }
        public event EventHandler OilEnded;
        public Gopnik()
        {
            Semki = 250;
        }
        public void LetsGoShelkat()
        {
            for (int i = Semki; i >= 0; i--)
            {
                if (Semki == 0)
                {
                    if (OilEnded != null)
                    {
                        OilEnded(this, new EventArgs());
                    }
                }
                Semki--;
            }

        }
    }
    class Program
    {
        private static void OnOilEnded(object sender, EventArgs eventArgs)
        {
            if (sender is Gopnik)
            {
                Console.WriteLine("Ctvrb");
            }
            else if (sender is Boozer)
            {
                Console.WriteLine("Пора в магаз");
            }
        }
        static void Main(string[] args)
        {

            var boozer = new Boozer();
            boozer.Olied += OnOilEnded;
            var gopnik = new Gopnik();
            gopnik.OilEnded += OnOilEnded;
            gopnik.LetsGoShelkat();
            boozer.LetsGodrink();

        }
    }
}
