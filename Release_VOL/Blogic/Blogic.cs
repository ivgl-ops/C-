using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using Domain;

namespace Blogic
{
    public class Blogical : INotifyPropertyChanged
    {
        public ObservableCollection<Teacher> Teachers { set; get; }
        public ObservableCollection<Institute> Institutes { get; set; }
        public ObservableCollection<Service> Services { get; set; }
        public int TeacherInstitute { get; set; }
        public int LearningServ { set; get; }
        public string TeacherName { get; set; }
        public string TeacherSurname { get; set; }
        public string TeacherMidname { get; set; }
        private Teacher newTeacher;
        public Teacher NewTeacher
        {
            get
            {
                return newTeacher;
            }
            set
            {
                newTeacher = value;
                OnPropertyChanged("NewTeacher");
            }
        }
        //вывод топа
        private string top;
        public string Top
        {
            get 
            {
                return top;
            }
            set
            {
                top = value;
                OnPropertyChanged("Top");
            }
        }
        //негативный топ
        private string low;
        public string Low
        {
            get
            {
                return low;
            }
            set
            {
                low = value;
                OnPropertyChanged("Low");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public Blogical()
        {
            Teachers = new ObservableCollection<Teacher>
            {

            };

            Institutes = new ObservableCollection<Institute>
            {
                new Institute{ Name = "ИКИТ"},
                new Institute{ Name = "ИСИ"},
                new Institute{ Name = "ПИ"},
                new Institute{ Name = "ВиИ"},
                new Institute{ Name = "ИФИЯК"}
            };
            Services = new ObservableCollection<Service>
            {
                new Service{Name = "Skype" },
                new Service{Name = "Discord" },
                new Service{Name = "Zoom" },
                new Service{Name = "Webinar" }
            };
        }
        private ICommand addCommand;
        public ICommand AddCommand => addCommand ?? (addCommand = new RelayCommand(AddTeacher));
        // Добавить extension methots//
        //--------------------------//
        //-------------------------//
        // Добавить methods-------//    
        public void AddTeacher()
        {
            Teacher teacher = new Teacher() { Name = TeacherName, Surname = TeacherSurname.ChangeName()
                ,Midname = TeacherMidname.ChangeName(), Univer = Institutes[TeacherInstitute], 
                Serv = Services[LearningServ] };
            Teachers.Insert(0, teacher);
            NewTeacher = teacher;
        }
        private ICommand removeCommand;
        public ICommand RemoveCommand => removeCommand ?? (removeCommand = new RelayCommand(RemoveTeacher));
        public void RemoveTeacher()
        {
            Teachers.RemoveAt(0);
        }
        private ICommand exitCommand;
        public ICommand ExitCommand=> exitCommand ?? (exitCommand = new RelayCommand(Exit));
        public void Exit()
        {
            Environment.Exit(0);
        }
        //TODO: Top 3
        private ICommand give;
        public ICommand Give => give ?? (give = new RelayCommand(DropTop));
        public void DropTop()
        {

            List<TopServices> topServices = Teachers.GroupBy(i => i.Serv.Name).Select(j => new TopServices() { Title = j.Key, Digit = j.Count() }).OrderByDescending(k => k.Digit).Take(3).ToList();
            Top = "";
            topServices.ForEach(i => Top += $"{i.Title} - {i.Digit}\n");
        }

        private ICommand giveLowTop;
        public ICommand GiveLowTop => giveLowTop ?? (giveLowTop = new RelayCommand(FarTop));
        public void FarTop()
        {
            List<UselessАpp> uselesses = Teachers.GroupBy(i => i.Serv.Name).Select(j => new UselessАpp() { Title = j.Key, Digit = j.Count() }).OrderBy(k => k.Digit).Take(1).ToList();
            Low = "";
            uselesses.ForEach(i => Low += $"{i.Title} - {i.Digit}\n");
        }
    }
    public static class MethodName
    {
        public static string ChangeName(this string TeacherSurname)
        {
            return TeacherSurname[0].ToString();
        }
    }
}
