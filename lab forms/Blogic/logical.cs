using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using System.Collections.ObjectModel;

namespace Blogic
{
    public class logical
    {
        public People SelectedPeople { get; set; }
        public People SelectedPeople2 { get; set; }

        public List<People> HealthPeople { get; set; } = new List<People>
        {
            new People{Name = "Генри", Surname = "Форд ", Age = 84},
            new People{Name = "Генри", Surname = "Форд ", Age = 3},
            new People{Name = "Генри", Surname = "Форд ", Age = 19},
            new People{Name = "Генри", Surname = "Форд ", Age = 31},
            new People{Name = "Генри", Surname = "Форд ", Age = 75},
            new People{Name = "Генри", Surname = "Форд ", Age = 3},
            new People{Name = "Генри", Surname = "Форд ", Age = 51},
            new People{Name = "Генри", Surname = "Форд ", Age = 74},
            new People{Name = "Генри", Surname = "Форд ", Age = 36}
        };
        public List<People> IllPeople { get; set; } = new List<People>
        {
            new People{Name = "Винстон", Surname = "Черчиль", Age = 91 }
        };

        public void RemovePeoples()
        {
            foreach (People people in HealthPeople)
            {
                IllPeople.Add(people);
            }
            HealthPeople.RemoveIll(IllPeople);
        }
        public void RemovePeople()
        {
            if (SelectedPeople != null)
            {
                IllPeople.Add(SelectedPeople);
                HealthPeople.RemoveIll(IllPeople);
            }
        }
        public void RemoveIlPeoples()
        {
            if (SelectedPeople2 != null)
            {
                HealthPeople.Add(SelectedPeople2);
                IllPeople.RemoveIll(HealthPeople);
            }
        }
        public void RemoveAll()
        {
            foreach (People people in IllPeople)
            {
                HealthPeople.Add(people);
            }
            IllPeople.RemoveIll(HealthPeople);
        }
        public void Remove60()
        {
            foreach (People people in HealthPeople)
            {
                if (people.Age > 60)
                {
                    IllPeople.Add(people);
                }
            }
            HealthPeople.RemoveIll(IllPeople);
        }

    }
    public static class MovePeople
    {
        public static void RemoveIll(this List<People> peoples, List<People> Illpeoples)
        {
            foreach (People Illpeople in Illpeoples)
            {
                peoples.Remove(Illpeople);
            }
        }
        public static void RemoveHealth(this List<People> peoples, List<People> HealthPeoples)
        { 
            foreach(People Health in HealthPeoples)
            {
                peoples.Remove(Health);
            }
        }
    }
}
