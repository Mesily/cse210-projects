using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();

        job1._company = "Reinforced Global";
        job1._jobTitle = "Secretary";
        job1._startYear = 2021;
        job1._endYear = 2026;

      

        Job job2 = new Job();
        job2._company = "Devine Impact Profile.";
        job2._jobTitle = "Research Assistant";
        job2._startYear = 2017;
        job2._endYear = 2021;

     

        Resume resume = new Resume();
    resume._name = "Mercy Ani";
    resume._jobs.Add(job1);
    resume._jobs.Add(job2);
    resume.Display();
    }
    

}