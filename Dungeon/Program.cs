using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DungeonLibrary;

namespace DungeonApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dungeon Of NIGHT TERROR!\nYour journey begins...");
            Console.Title = "DUNGEON OF NIGHT TERROR";

            int score = 0;

            Weapon sword = new Weapon(1, 8, "Long Sword", 10, true);
           
            Player player = new Player("Leeeeeeeroy Jenkins", 70, 5, 50, 40, Race.Toddler, sword);

         
            bool exit = false;

            do
            {
                
                Console.WriteLine(GetRoom());

               
                Rabbit r1 = new Rabbit();

                Rabbit r2 = new Rabbit("White Rabbit", 25, 25, 50, 20, 2, 8, "That's no ordinary rabbit! Look at the bones!", true);

                Vampire v1 = new Vampire("The Count", 40, 40, 40, 15, 2, 12, "Yikes, it's a vampire!");

                Turtle t1 = new Turtle();
                Turtle t2 = new Turtle("Leo", 30, 30, 65, 40, 3, 15, "This turtle got into the ooze...watch it!", 10, 25);

               
                Monster[] monsters = { r1, r2, v1, t1, t2 };

               
                Random rand = new Random();
                Monster monster = monsters[rand.Next(monsters.Length)];

                Console.WriteLine("\nIn this room: " + monster.Name);

                
                bool reload = false;

                do
                {
                    
                    #region MENU
                    Console.Write("\nPlease choose an action:\n" +
                        "A) Attack\n" +
                        "R) Run Away\n" +
                        "P) Player Info\n" +
                        "M) Monster Info\n" +
                        "X) Exit\n");

                    ConsoleKey userChoice = Console.ReadKey(true).Key;

                    Console.Clear();

                   
                    switch (userChoice)
                    {
                        case ConsoleKey.A:
                            Console.WriteLine("Attack");
                          
                            Combat.DoBattle(player, monster);

                            
                            if (monster.Life <= 0)
                            {
                              
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nYou killed {0}!\n", monster.Name);
                                Console.ResetColor();
                              
                                reload = true;
                               
                                score++;
                            }
                            break;
                        case ConsoleKey.R:
                            Console.WriteLine("Run Away!!");
                            
                            Console.WriteLine($"{monster.Name} attacks you as you flee!");
                            Console.WriteLine();
                            Combat.DoAttack(monster, player);
                            Console.WriteLine();
                            reload = true;
                            break;
                        case ConsoleKey.P:
                            Console.WriteLine("Player Info");
                           
                            Console.WriteLine(player);
                            Console.WriteLine("Monsters defeated: " + score);
                            break;
                        case ConsoleKey.M:
                            Console.WriteLine("Monster Info");
                         
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
                    }
                    #endregion

                 
                    if (player.Life <= 0)
                    {
                        Console.WriteLine("Dude...you died. I guess that's game over!");
                        exit = true;
                    }
                } while (!exit && !reload);
            } while (!exit);

            Console.WriteLine("You defeated " + score + " monster" +
                (score == 1 ? "." : "s."));
        }     
        
        private static string GetRoom()
        {
            string[] rooms =
            {
                "The room is dark and full of SHARKS AND the smell of lost souls.",
                "You enter a pretty pink powder room and instantly get glitter on you.",
                "You arrive in a dance room filled with dancers dancing to Staying Alive. Oh NO!",
                "You enter a quiet VERY LOUD library... SILENCE... You wish for silence....",
                "As you enter this room, you know you are standing on a platform surrounded by SHARKS",
                "Oh NO....It smells like...FEAR...You are standing in a pile of SHARKS",
                "You now go to another dark room; you hear LOUD music blaring.... THIS is BADDDD!",
                "Oh NO.... It's even worstl... Sharks Everywhere....",
                "This DARK new room looks like your parent's office... or does it?"
            };

            Random rand = new Random();

            int indexNbr = rand.Next(rooms.Length);

            string room = rooms[indexNbr];

            return room;
        }
    }
}
