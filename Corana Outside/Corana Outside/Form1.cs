using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;
using System.IO;

namespace Corana_Outside
{
    public partial class Form1 : Form
    {
        public List<People> peoples { get; set; } = new List<People>
        {
        new People{Name = "Андрей ", surname = Surname.Бонд, Age = 8 },
        new People{Name = "Ким ", surname = Surname.Кардашьян, Age = 24 },
        new People{ Name = "Иван ", surname = Surname.Рокет, Age = 71},
        new People{ Name = "Жак ", surname = Surname.Фреско, Age = 80}
        };
        List<People> Illpeople = new List<People>();
        List<People> Age = new List<People>();
        List<People> Agenot60 = new List<People>();

        public Form1()
        {
            InitializeComponent();
            listBox1.DataSource = peoples;
            foreach (People people in peoples)
            {
                if (people.Age > 60)
                {
                    Age.Add(people);
                }
                else
                {
                    Agenot60.Add(people);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Illpeople.AddRange(peoples);
            peoples.Clear();
            listBox2.DataSource = Illpeople;
            listBox1.DataSource = null;
            listBox1.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            peoples.AddRange(Illpeople);
            Illpeople.Clear();
            listBox1.DataSource = peoples;
            listBox2.DataSource = null;
            listBox2.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox2.DataSource = Age;
            listBox1.DataSource = Agenot60;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, FormClosingEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
