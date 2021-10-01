using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
    public class Combat 
    {
        // just a "warehouse" for combat functionality.
        public static void DoAttack(Character attacker, Character defender)
        {
            //get a random number from 1-100 as the dice roll
            Random rand = new Random();
            int diceRoll = rand.Next(1, 101);
            System.Threading.Thread.Sleep(100);

            //Then compare the dice roll against the Attacker's hitChance - defender's calcBlock(). If the dice roll is lower than that algorithm, the attacker hit for damage.
            if (diceRoll <= (attacker.CalcHitChance() - defender.CalcBlock()))
            {
                //calc the damage
                int damageDealt = attacker.CalcDamage();

                //assign the damage
                defender.Life -= damageDealt;

                //Write the result to the screen
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0} hit {1} for {2} damage!",
                    attacker.Name, defender.Name, damageDealt);
                Console.ResetColor();
            }//end if
            else
            {
                //Attacker missed
                Console.WriteLine("{0} missed!", attacker.Name);
            }//end else
        }//end DoAttack()

        public static void DoBattle(Player player, Monster monster)
        {
            //Player attacks first
            DoAttack(player, monster);

            //If the monster is still alive, they get an attack on the player
            if (monster.Life > 0)
            {
                DoAttack(monster, player);
            }//end if
        }//end DoBattle()
    }//end class 
}//end namespace