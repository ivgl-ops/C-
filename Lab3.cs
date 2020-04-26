using System;
using System.Collections.Generic;


namespace Lab3
{
    public interface IOlimpicConstruction
    { 
        int Cost { get; set; }
    }
    public abstract class OlimpConstruction : IOlimpicConstruction
    { 
        public int Cost { get; set; }
    }
    public class Separator<T> where T : IOlimpicConstruction
    {
        public List<T> LeasedObj = new List<T>();
        public List<T> FreeObj = new List<T>();
        //добовление в арендованные
        public void Add(T item, int cost)
        {
            if (cost > 100)
            {
                LeasedObj.Add(item);
                FreeObj.Remove(item);
                Console.WriteLine("Object lised");
            }
            else
            {
                Console.WriteLine("Object not lised");
            }
        }
        //добовление в свободные
        public void Remove(T item)
        {
            if (LeasedObj.Contains(item) == true)
            {
                FreeObj.Add(item);
                LeasedObj.Remove(item);
                Console.WriteLine("Object removed in FreeObj");
            }
        }

        public void Find(T item)
        {
            if (FreeObj.Contains(item) == true)
            {
                Console.WriteLine($"Найден свободный объект {item} ");
            }
            else
            {
                Console.WriteLine("Объект не найден");
            }
        }


    }
    class MedicalCenter : OlimpConstruction
    {
        public  MedicalCenter(int cost)
        { 

        }
    }
    class Stadium : OlimpConstruction
    {
        public Stadium(int cost)
        { 
            
        }
    }
    abstract class SimpleConstr : IOlimpicConstruction
    { 
     public int Cost { get; set; }
    }
    class Hostel : SimpleConstr
    {
        public Hostel(int cost)
        { 
        
        }
    }
    class Lib : SimpleConstr
    {
        public Lib(int cost)
        { 
        
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var medical = new MedicalCenter(555);
            var stadium = new Stadium(200);
            var lib = new Lib(33);
            var hostel = new Hostel(101);
            var separator = new Separator<IOlimpicConstruction>();
            separator.FreeObj.Add(medical);
            separator.FreeObj.Add(stadium);
            separator.FreeObj.Add(lib);
            separator.FreeObj.Add(hostel);
            //аренда
            separator.Add(medical, 555);
            separator.Add(hostel, 101);
            // удаление из аредованных
            separator.Remove(medical);
            //поиск
            separator.Find(stadium);
        }
    }
}