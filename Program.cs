using System;
using System.Collections.Generic;

namespace Ambulance
{
    public interface ISickness
    {

    }
    public class PigV : ISickness
    {

    }
    public class BirdV : ISickness
    {

    }
    public class Cov19 : ISickness
    {

    }
    interface IWard
    {
        int Maxpatient { set; get; }
    }
    public class PigW : IWard
    {
        public int Maxpatient { get; set; }
        public List<Patient> patientsPigV = new List<Patient>();
    }

    public class BirdW : IWard
    {
        public int Maxpatient { get; set; }
        public List<Patient> patientsBirdV = new List<Patient>();
    }
    public class CoronaVirusW : IWard
    {
        public int Maxpatient { set; get; }
        public List<Patient> patientsCOV19 = new List<Patient>();
    }

    public class Patient
    {
        public ISickness Sickness { get; set; }
    }
    class Hospital
    {
        PigW pigW = new PigW { Maxpatient = 3 };
        CoronaVirusW coronaVirusW = new CoronaVirusW { Maxpatient = 3 };
        BirdW birdW = new BirdW { Maxpatient = 3 };
        public List<Patient> Patients { get; set; } = new List<Patient>();
        public void Check()
        {
            foreach (Patient P in Patients)
            {
                if (P.Sickness == new Cov19())
                {
                    if (coronaVirusW.Maxpatient > 0)
                    {
                        coronaVirusW.patientsCOV19.Add(P);
                        coronaVirusW.Maxpatient--;
                    }
                    else
                    {
                        Console.WriteLine("Палата переполнена");
                    }
                }
                if (P.Sickness == new BirdV())
                {
                    if (birdW.Maxpatient > 0)
                    {
                        birdW.patientsBirdV.Add(P);
                        birdW.Maxpatient--;
                    }
                    else
                    {
                        Console.WriteLine("Палата переполнена");
                    }
                }
                if (P.Sickness == new PigV())
                {
                    if (pigW.Maxpatient > 0)
                    {
                        pigW.patientsPigV.Add(P);
                        pigW.Maxpatient--;
                    }
                    else
                    {
                        Console.WriteLine("Палата переполнена");
                    }
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Hospital hospital = new Hospital();
            Patient P1 = new Patient { Sickness = new Cov19() };
            Patient P2 = new Patient { Sickness = new PigV() };
            Patient P3 = new Patient { Sickness = new BirdV() };
            Patient P4 = new Patient { Sickness = new BirdV() };
            Patient P5 = new Patient { Sickness = new BirdV() };
            Patient P6 = new Patient { Sickness = new BirdV() };
            Patient P7 = new Patient { Sickness = new BirdV() };
            Patient P8 = new Patient { Sickness = new BirdV() };
            Patient P9 = new Patient { Sickness = new BirdV() };
            hospital.Patients.Add(P1);
            hospital.Patients.Add(P2);
            hospital.Patients.Add(P3);
            hospital.Patients.Add(P4);
            hospital.Patients.Add(P5);
            hospital.Patients.Add(P6);
            hospital.Patients.Add(P7);
            hospital.Patients.Add(P8);
            hospital.Patients.Add(P9);
            hospital.Check();
            Console.ReadKey();
        }
    }
}



