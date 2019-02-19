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
    interface ICreature
    {
        float Health { get; }
        Vec2 Pos { get; }
        void Hit(float strength);
        void Move(Direction direction, int speed);
    }

    /* 
     * 2. Maak een class Critter, met de interface ICreature. Zorg voor een logische uitwerking
     * van de functies. Voeg ook een constuctor toe om de properties in te stellen.
     */
    class Critter : ICreature
    {
        private float health;
        public float Health { get => health; }

        private Vec2 pos;
        public Vec2 Pos { get => pos; }

        public Critter(float health, Vec2 pos)
        {
            this.health = health;
            this.pos = pos;
        }

        public void Hit(float strength)
        {
            health -= strength;
        }

        public void Move(Direction direction, int speed)
        {
            switch(direction)
            {
                case Direction.Down: pos.Y -= speed; break;
                case Direction.Left: pos.X -= speed; break;
                case Direction.Right: pos.X += speed; break;
                case Direction.Up: pos.Y += speed; break;
            }
        }
    }

    /* 
    * 3. Maak een class Monster, met de interface ICreature. Een monster
    *    werkt net zoals een Critter, maar regenereert 0.1 health bij elke
    *    beweging.
    */
    class Monster : ICreature
    {
        private float health;
        public float Health { get => health; }

        private Vec2 pos;
        public Vec2 Pos { get => pos; }

        public Monster(float health, Vec2 pos)
        {
            this.health = health;
            this.pos = pos;
        }

        public void Hit(float strength)
        {
            health -= strength;
        }

        public void Move(Direction direction, int speed)
        {
            switch (direction)
            {
                case Direction.Down: pos.Y -= speed; break;
                case Direction.Left: pos.X -= speed; break;
                case Direction.Right: pos.X += speed; break;
                case Direction.Up: pos.Y += speed; break;
            }
            health += 0.1f;
        }
    }

    /*
     * 4. Maak een class Player, ook met de interface ICreature. De player heeft ook een
     *    property Name, die je instelt via de constructor.
     */
    class Player : ICreature
    {
        private float health;
        public float Health { get => health; }

        private Vec2 pos;
        public Vec2 Pos { get => pos; }

        private string name;
        public String Name { get => name; }

        public Player(string name, float Health, Vec2 pos)
        {
            this.name = name;
            this.health = Health;
            this.pos = pos;
        }

        public void Hit(float strength)
        {
            health -= strength;
        }

        public void Move(Direction direction, int speed)
        {
            switch (direction)
            {
                case Direction.Down: pos.Y -= speed; break;
                case Direction.Left: pos.X -= speed; break;
                case Direction.Right: pos.X += speed; break;
                case Direction.Up: pos.Y += speed; break;
            }
        }
    }

    /*
     * 5. Werk de class Game verder uit, volgens de instructies in de class.
     *    Ben je klaar? Kijk daar de uitbreidingen onder de oefening.
     */
    public class Game
    {
        // maak hier een list met voor Creatures
        private List<ICreature> creatures = new List<ICreature>();

        // voeg een player toe
        private Player Player = new Player("Hero", 20, new Vec2(0, 0));

        // maak een nieuw Random object om in de volgende functies te gebruiken
        Random random = new Random();

        public Game()
        {
            
            // voeg 4 Critters en 2 Monsters toe aan de lijst
            for(int i = 0; i < 4; i++)
            {
                creatures.Add(new Critter(5, new Vec2(random.Next(-3, 3), random.Next(-3, 3))));
            }

            for (int i = 0; i < 2; i++)
            {
                creatures.Add(new Monster(10, new Vec2(random.Next(-4, 4), random.Next(-4, 4))));
            }
        }

        public void MoveCreatures()
        {
            // beweeg alle creatures in een willekeurige richting, monsters bewegen aan dubbele
            // snelheid.
            creatures.ForEach((creature) =>
            {
                if(creature is Critter)
                {
                    creature.Move((Direction)random.Next((int)Direction.MAX), 1);
                } else
                {
                    creature.Move((Direction)random.Next((int)Direction.MAX), 2);
                }
                
            });
        }

        public void MovePlayer()
        {
            Player.Move((Direction)random.Next((int)Direction.MAX), 1);
        }

        public void HitNearbyCritters()
        {
            // Sla alle creatures die minder dan 2 meter ver zijn.
            int hits = 0;
            creatures.ForEach((creature) =>
            {
                if (creature.Pos.Distance(Player.Pos) < 2)
                {
                    creature.Hit(1);
                    hits++;
                }
            });
            Console.WriteLine(Player.Name + " was able to hit " + hits + " creatures.");
        }

        public void BitePlayer()
        {
            // Alle critters die minder dan 2 meter van de player
            // verwijderd zijn, bijten de player met kracht 0.25.
            // Monsters slaan je met een kracht 0.5.
            int hits = 0;
            creatures.ForEach((creature) =>
            {
                if (creature.Pos.Distance(Player.Pos) < 2)
                {
                    if (creature is Monster) Player.Hit(0.5f);
                    else Player.Hit(0.25f);
                    hits++;
                }
            });
            Console.WriteLine(Player.Name + " has been hit by " + hits + " creatures.");
        }

        public void PrintStatus()
        {
            // toon de health van de player en van alle critters op het scherm
            Console.WriteLine("There are " + creatures.Count + " creatures: ");
            creatures.ForEach((creature) =>
            {
                if (creature is Monster) Console.WriteLine("- A monster with " + creature.Health + " health.");
                else Console.WriteLine("- A critter with " + creature.Health + " health.");
            });
            Console.WriteLine(Player.Name + " has a health of " + Player.Health);
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
