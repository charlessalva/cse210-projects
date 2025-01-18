using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        {
            job1._jobTitle = "Software Engineer";
            job1._company = "Microsoft";
            job1._startYear = 1999;
            job1._endYear = 2010;
        }

        Job job2 = new Job();
        {
            job2._jobTitle = "Data Analyst";
            job2._company = "Apple";
            job2._startYear = 2003;
            job2._endYear = 2016;
        }

        Resume resume1 = new Resume();
        {
            resume1._personName = "Charles Salva";
            resume1._jobs.Add(job1);
            resume1._jobs.Add(job2);
        }

        resume1.DisplayResume();
    }
}