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

    public partial class Oef
    {
        public static void TestOef1()
        {

        }
    }
    
}
