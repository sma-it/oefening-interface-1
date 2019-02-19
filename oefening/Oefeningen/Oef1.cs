using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First
{
    interface IPerson
    {
        string Name { get; set; }
        DateTime DateOfBirth { get; }
        int Age();
    }

    /* a: 
     * Maak een class Student. Deze class implementeert IPerson. Voeg ook
     * een constructor toe die je toelaat dadelijk Name en DateOfBirth in
     * te stellen.
     * 
     * b:
     * Voorzie ook een property Grade. Dit is een integer die minimum nul en 
     * maximum 10 kan zijn. Via de setter beperk je de waarde tot deze range.
     * 
     * c:
     * Maak in de functie TestOef1 (hieronder) een object van de class Student.
     * Test alle waarden door ze op het scherm te tonen. Je kan ook de functie
     * ToString() overschrijven om dit te doen.
     * 
     * d: 
     * Maak een class Teacher. Ook deze class implementeert IPerson. Voorzie ook
     * een property Salary om het loon te onthouden.
     * 
     * e: 
     * In de functie TestOef1 maak je ook een object van de class Teacher. Test
     * ook dit object door alle properties op het scherm te tonen.
     */

    class Student : IPerson
    {
        public string Name { get; set; }

        public DateTime DateOfBirth { get; }

        private int grade;
        public int Grade {
            get => grade;
            set {
                if (value < 0) grade = 0;
                else if (value > 10) grade = 10;
                else grade = value;
            }
        }

        public Student(string Name, DateTime DateOfBirth)
        {
            this.Name = Name;
            this.DateOfBirth = DateOfBirth;
        }

        public int Age()
        {
            int age = DateTime.Now.Year - DateOfBirth.Year;

            if (DateTime.Now.Month < DateOfBirth.Month || (DateTime.Now.Month == DateOfBirth.Month && DateTime.Now.Day < DateOfBirth.Day))
                age--;

            return age;
        }

        public override string ToString()
        {
            return Name + " is " + Age() + " years old and got a grade: " + Grade;
        }
    }

    class Teacher : IPerson
    {
        public string Name { get; set; }

        public DateTime DateOfBirth { get; }

        public int Salary { get; set; }

        public Teacher(string Name, DateTime DateOfBirth)
        {
            this.Name = Name;
            this.DateOfBirth = DateOfBirth;
        }

        public int Age()
        {
            int age = DateTime.Now.Year - DateOfBirth.Year;

            if (DateTime.Now.Month < DateOfBirth.Month || (DateTime.Now.Month == DateOfBirth.Month && DateTime.Now.Day < DateOfBirth.Day))
                age--;

            return age;
        }

        public override string ToString()
        {
            return Name + " is " + Age() + " years old and earns: " + Salary;
        }
    }

    public partial class Oef
    {
        public static void TestOef1()
        {
            Student student = new Student("Rudolf", new DateTime(2000, 12, 25));
            student.Grade = 12;
            Console.WriteLine(student);

            Teacher teacher = new Teacher("Claus", new DateTime(1950, 12, 24));
            teacher.Salary = 4200;
            Console.WriteLine(teacher);
        }
    }
    
}
