using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First
{
    // Deze enum wordt in de oefening gebruikt om een richting van beweging aan te geven
    enum Direction { Left, Right, Up, Down};

    // Deze class wordt in de oefening gebruikt om een positie op te slaan
    class Vec2
    {
        public float x, y;
        public float Distance(Vec2 other)
        {
            return (float)Math.Sqrt(Math.Pow(other.x - x, 2) + Math.Pow(other.y - y, 2));
        }
    }

    /*
     * 1. Maak een interface ICreature. Deze interface voorziet:
     * - een property Health (readonly), met een float waarde.
     * - een property Pos (readonly), van het type Vec2.
     * - een functie Hit(float strength), die later de health property zal verlagen.
     * - een functie Move, met als argumenten een richting (Direction) en een integer voor de snelheid.
     */

    /* 
     * 2. Maak een class Critter, met de interface ICreature. Zorg voor een logische uitwerking
     * van de functies.
     */

    /*
     * 3. Maak een class Player, ook met de interface ICreature.
     */
     
    /*
     * 4. Werk de class Game verder uit, volgens de instructies in de class
     */ 
    public class Game
    {
        // maak hier een list met voor Critters

        // voeg een player toe

        public Game()
        {
            // voeg 4 Critters toe aan de lijst
        }

        public void MoveCritters()
        {
            // beweeg alle critters in een willekeurige richting
        }

        public void MovePlayer()
        {
            // beweeg de player in een willekeurige richting
        }

        public void HitNearbyCritters()
        {
            // Sla alle critters die minder dan 2 meter van de player
            // verwijderd zijn, met kracht 1.
        }

        public void BitePlayer()
        {
            // Alle critters die minder dan 1 meter van de player
            // verwijderd zijn, bijten de player met kracht 0.25.
        }

        public void PrintStatus()
        {
            // toon de health van de player en van alle critters op het scherm
        }

        public void Play()
        {
            var menu = new Utils.Menu();
            menu.AddOption('1', "Another Turn", () =>
            {
                MoveCritters();
                MovePlayer();
                HitNearbyCritters();
                BitePlayer();
                PrintStatus();
            });

            menu.Start();
        }
    }
    
}
