using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Reflectiom
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser2C = new Parser2C();
            var bank = new Bank();
            Client c1 = new Client { Name = "Зевс", Id = 1, passport = 4584923 };
            Client c2 = new Client { Name = "Алина", Id = 2, passport = 4584334 };
            Client c3 = new Client { Name = "Ваня", Id = 3, passport = 45849134 };
            bank.Clients.Add(c1);
            bank.Clients.Add(c2);
            bank.Clients.Add(c3);
            parser2C.Parse(bank.Clients);
            Console.ReadKey();
        }
    }
    class NotPrintableAttribute : Attribute { }
    public class Parser2C
    {
        public void Parse(List<Client> clients)
        {
            Type type = clients[0].GetType();
            PropertyInfo[] prop = type.GetProperties();

            List<PropertyInfo> props = new List<PropertyInfo>();

            foreach (var propertyInfo in prop)
            {
                props.Add(propertyInfo);

                var attributes = propertyInfo.GetCustomAttributes(true);
                foreach (NotPrintableAttribute at in attributes)
                {
                    props.Remove(propertyInfo);

                }
            }
            Console.Write("Номер");
            foreach (var p in props)
            {
                Console.Write("\t{0}", p.Name);
            }
            Console.WriteLine();

            int i = 0;
            foreach (Client C in clients)
            {
                i++;
                Console.Write(i);
                props.Clear();
                type = C.GetType();
                prop = type.GetProperties();
                foreach (PropertyInfo propertyInfo in prop)
                {
                    props.Add(propertyInfo);

                    var attributes = propertyInfo.GetCustomAttributes(true);
                    foreach (NotPrintableAttribute at in attributes)
                    {
                        props.Remove(propertyInfo);

                    }

                }

                foreach (var p in props)
                {
                    Console.Write("\t{0}", p.GetValue(C));
                }
                Console.WriteLine();
            }

        }
    }
    public class Client
    {
        [NotPrintable]
        public string Name { get; set; }
        public int Id { get; set; }
        public int passport { get; set; }
    }
    public class Bank
    {
        public List<Client> Clients { get; set; } = new List<Client>();
    }

}
