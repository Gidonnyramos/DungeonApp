using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Add the following to have easier access to the Dungeon Library
using DungeonLibrary;

namespace DungeonApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dungeon of Doom!\nYour journey begins...");
            Console.Title = "DUNGEON OF DOOM";

            //Variable to keep track of the score
            int score = 0;

            //TODO Create the player and weapon
            //Need to learn about custom classes first
            Weapon sword = new Weapon(1, 8, "Long Sword", 10, true);
            //You could create multiple weapons and have a menu of weapons for the user to choose from.
            //Console.WriteLine(sword);-This was just for testing the Weapon ToString()
            Player player = new Player("Leeeeeeeroy Jenkins", 70, 5, 50, 40, Race.Toddler, sword);

            //Outer dowhile loop - manages the entire game
            //TODO Create a loop for the room and monster to be created
            //Counter
            bool exit = false;

            do
            {
                //TODO - Create a room
                //We are going to write a method for getting a random room from a collection of rooms we create
                Console.WriteLine(GetRoom());

                //TODO - Create a monster
                //We are going to create many different monsters and randomly select a monster from a collection of monsters.
                Rabbit r1 = new Rabbit();

                Rabbit r2 = new Rabbit("White Rabbit", 25, 25, 50, 20, 2, 8, "That's no ordinary rabbit! Look at the bones!", true);

                Vampire v1 = new Vampire("The Count", 40, 40, 40, 15, 2, 12, "Yikes, it's a vampire!");

                Turtle t1 = new Turtle();
                Turtle t2 = new Turtle("Leo", 30, 30, 65, 40, 3, 15, "This turtle got into the ooze...watch it!", 10, 25);

                //Since all of our monsters (Rabbit, Turtle, Vampire) are inheriting from the Monster class, we can create a collection of type Monster
                Monster[] monsters = { r1, r2, v1, t1, t2 };

                //randomly select a monster from the collection
                Random rand = new Random();
                Monster monster = monsters[rand.Next(monsters.Length)];

                //TODO - Display to the user the monster and the room they encountered
                Console.WriteLine("\nIn this room: " + monster.Name);

                //TODO - Create a loop for the menu
                bool reload = false;

                do
                {
                    //TODO - Create the menu
                    #region MENU
                    Console.Write("\nPlease choose an action:\n" +
                        "A) Attack\n" +
                        "R) Run Away\n" +
                        "P) Player Info\n" +
                        "M) Monster Info\n" +
                        "X) Exit\n");

                    //TODO - capture the userChoice
                    ConsoleKey userChoice = Console.ReadKey(true).Key;

                    Console.Clear();

                    //TODO - Build out the switch for the menu
                    switch (userChoice)
                    {
                        case ConsoleKey.A:
                            Console.WriteLine("Attack");
                            //TODO Handle Attack functionality
                            Combat.DoBattle(player, monster);

                            //Handle the monster dying in case we hit them for enough       points
                            if (monster.Life <= 0)
                            {
                                //monster is dead...reload a new room and monster, as       well as adding to the player's score.
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nYou killed {0}!\n", monster.Name);
                                Console.ResetColor();
                                //get a new room
                                reload = true;
                                //add to the player's score
                                score++;                               
                            }
                            break;
                        case ConsoleKey.R:
                            Console.WriteLine("Run Away!!");
                            //TODO Handle Run Away Functionality
                            Console.WriteLine($"{monster.Name} attacks you as you flee!");
                            Console.WriteLine();
                            Combat.DoAttack(monster, player);
                            Console.WriteLine();
                            reload = true;
                            break;
                        case ConsoleKey.P:
                            Console.WriteLine("Player Info");
                            //TODO Display the player info via the ToString()
                            Console.WriteLine(player);
                            Console.WriteLine("Monsters defeated: " + score);
                            break;
                        case ConsoleKey.M:
                            Console.WriteLine("Monster Info");
                            //TODO Display the monster info via the ToString()
                            Console.WriteLine(monster);
                            break;
                        case ConsoleKey.X:
                        case ConsoleKey.E:
                            Console.WriteLine("No one likes a quitter!");
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Thou hast chosen an improper action. Triest thou again!");
                            break;
                    }//end switch
                    #endregion

                    //TODO - Check the player's life
                    if (player.Life <= 0)
                    {
                        Console.WriteLine("Dude...you died. I guess that's game over!");
                        exit = true;
                    }
                } while (!exit && !reload);
            } while (!exit);

            Console.WriteLine("You defeated " + score + " monster" +
                (score == 1 ? "." : "s."));
        }//end Main()       

        //TODO - Create GetRoom() and plug it in to the TODO above
        private static string GetRoom()
        {
            string[] rooms =
            {
                "The room is dark and musty with the smell of lost souls.",
                "You enter a pretty pink powder room and instantly get glitter on you.",
                "You arrive in a room filled with chairs and a ticket stub machine...DMV",
                "You enter a quiet library... silence... nothing but silence....",
                "As you enter the room, you realize you are standing on a platform surrounded by sharks",
                "Oh my.... what is that smell? You appear to be standing in a compost pile",
                "You enter a dark room and all you can hear is hair band music blaring.... This is going to be bad!",
                "Oh no.... the worst of them all... Oprah's bedroom....",
                "The room looks just like the room you are sitting in right now... or does it?"
            };

            Random rand = new Random();

            int indexNbr = rand.Next(rooms.Length);

            string room = rooms[indexNbr];

            return room;
        }//end GetRoom()
    }//end class
}//end namespace
