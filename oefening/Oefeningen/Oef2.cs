using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First
{
    // Deze enum wordt in de oefening gebruikt om een richting van beweging aan te geven
    enum Direction { Left, Right, Up, Down, MAX};

    // Deze class wordt in de oefening gebruikt om een positie op te slaan
    class Vec2
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Vec2(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public float Distance(Vec2 other)
        {
            return (float)Math.Sqrt(Math.Pow(other.X - X, 2) + Math.Pow(other.Y - Y, 2));
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
     * van de functies. Voeg ook een constuctor toe om de properties in te stellen.
     */
    

    /* 
    * 3. Maak een class Monster, met de interface ICreature. Een monster
    *    werkt net zoals een Critter, maar regenereert 0.1 health bij elke
    *    beweging.
    */
    

    /*
     * 4. Maak een class Player, ook met de interface ICreature. De player heeft ook een
     *    property Name, die je instelt via de constructor.
     */
    

    /*
     * 5. Werk de class Game verder uit, volgens de instructies in de class.
     *    Ben je klaar? Kijk daar de uitbreidingen onder de oefening.
     */
    public class Game
    {
        // maak hier een list met voor Creatures
        

        // voeg een player toe


        // een nieuw Random object om in de volgende functies te gebruiken
        Random random = new Random();

        public Game()
        {
            
            // voeg 4 Critters en 2 Monsters toe aan de lijst
            
        }

        public void MoveCreatures()
        {
            // beweeg alle creatures in een willekeurige richting, monsters bewegen aan dubbele
            // snelheid.
            
        }

        public void MovePlayer()
        {
            // verplaats de player in een willekeurige richting
        }

        public void HitNearbyCritters()
        {
            // Sla alle creatures die minder dan 2 meter ver zijn.
            
        }

        public void BitePlayer()
        {
            // Alle critters die minder dan 2 meter van de player
            // verwijderd zijn, bijten de player met kracht 0.25.
            // Monsters slaan je met een kracht 0.5.
            
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
                MoveCreatures();
                MovePlayer();
                HitNearbyCritters();
                BitePlayer();
                PrintStatus();
            });

            menu.Start();
        }
    }
    
    /*
     * Je kan dit spel op veel manieren uitbreiden. Hier zijn enkele mogelijkheden:
     * - een creature dat dood is kan je niet aanvallen, hij kan de speler ook niet bijten.
     * - In het menu kan je eerst controleren of de speler wel leeft. Als hij niet meer leeft print je 'Game Over' en
     *   voer je de acties niet uit.
     * - Een extra menu optie 'Reset' kan de game resetten. Hierbij zal je een nieuwe speler moeten maken, en de lijst
     *   met creatures moeten leegmaken en opnieuw vullen.
     * - Een extra menu optie 'Use Health Potion' kan je health verhogen. Maar dan zal je wel de player class moeten aanpassen, 
     *   zodat dat mogelijk is.
     * - Je kan ook andere potions toevoegen, en een lijst bijhouden van de voorraad.
     * - Een creature dat bijna dood is, kan tijdelijk vluchten.
     * - Een monster dat bijna dood is, kan 'Frantic' zijn, dwz dat het harder bijt.
     * - Een creature hoeft niet altijd even hard te bijten.
     * - Je kan ook zelf iets verzinnen!
     */ 
}
