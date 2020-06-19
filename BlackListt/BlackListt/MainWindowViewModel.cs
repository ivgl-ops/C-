using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;


namespace BlackListt
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel(string password, string login)
        {
            if (password.Equals("111") && login.Equals("111"))
            {
                string[] blackList = File.ReadAllLines(@"BlackList.txt");
                var _MyBlackList = from line in blackList
                                   let teacherData = line.Split(',')

                                   select new Teacher()
                                   {
                                       Name = teacherData[0],
                                       Subject = new Subject()
                                       {
                                           Title = teacherData[1]
                                       },
                                       Mark = new Rating()
                                       { 
                                        Mark =teacherData[2]
                                       }
                                       
                                   };
                Data = new ObservableCollection<Teacher>(_MyBlackList);
            }
            else
            {
                MessageBox.Show("Invalid Access");
            }
        }
        public int SelectedName { get; set; }
        public int SelectedSub { get; set; }
        public int SelectdTeacher { get; set; }
        public int SelectedMark { get; set; }
        public ObservableCollection<Teacher> Data { get; set; }
        public List<Teacher> Teachers { get; set; } = new List<Teacher>()
        {
            new Teacher{ Name = "Белько" },
            new Teacher{ Name = "Вайнштейн"},
            new Teacher{ Name = "Виденин" },
            new Teacher{ Name = "Кушнаренко" },
            new Teacher{ Name = "Не помню"}
        };
        public List<Subject> Subjects { get; set; } = new List<Subject>()
        {
            new Subject{ Title = "Прога"},
            new Subject{ Title = "Мат.анализ"},
            new Subject{Title = "Дискретка"},
            new Subject{ Title = "Не помню"}
        };
        public List<Rating> Marks { get; set; } = new List<Rating>()
        {
            new Rating{ Mark = "1"},
            new Rating{ Mark = "2"},
            new Rating{ Mark = "3"},
            new Rating{ Mark = "4"},
            new Rating{ Mark = "5"}
        };

        private RelayCommand _add;
        public RelayCommand Add
        {
            get
            {
                return _add ?? (_add = new RelayCommand(AddTeacher));
            }
        }
        private void AddTeacher()
        {
            string name = Teachers[SelectedName].Name;
            Subject subject = Subjects[SelectedSub];
            Rating mark = Marks[SelectedMark];

            if (!Data.ToList().Exists(i => i.Name == name))
                Data.Add(
                    new Teacher()
                    {
                        Name = name,
                        Subject = subject,
                        Mark = mark
                    }
                    );
            else
                MessageBox.Show("Этот пользователь уже добавлен");
        }
        private RelayCommand _delete;
        public RelayCommand Delete
        { 
            get
            {
                return _delete ?? (_delete = new RelayCommand(RemoveTeacher));

            }
        }
        public void RemoveTeacher()
        {
            Data.RemoveAt(SelectdTeacher);
            MessageBox.Show("Учитель был удален");
        }
        private RelayCommand _save;
        public RelayCommand Save
        {
            get
            {
                return _save ?? (_save = new RelayCommand(SaveTeacher));

            }
        }
        private void SaveTeacher()
        {
            string s = "";
            Data.ToList().ForEach(i => s += i.ToString() + "\n");
            s = s.Replace(" ", "").Replace('-', ',');
            File.WriteAllText(@"BlackList.txt", s);
            MessageBox.Show("Файл успешно сохранен");
        }
        private RelayCommand _reload;
        public RelayCommand Reload
        {
            get
            {
                return _reload ?? (_reload = new RelayCommand(ReloadTeacher));

            }
        }
        private void ReloadTeacher()
        {
            string[] blackList = File.ReadAllLines(@"BlackList.txt");
            var _MyBlackList = from line in blackList
                               let teacherData = line.Split(',')

                               select new Teacher()
                               {
                                   Name = teacherData[0],
                                   Subject = new Subject()
                                   {
                                       Title = teacherData[1]

                                   },
                                   Mark = new Rating()
                                   { 
                                        Mark = teacherData[2]
                                   }
                               };
            Data = new ObservableCollection<Teacher>(_MyBlackList);
            MessageBox.Show("Выполненно");
        }

    }
}
