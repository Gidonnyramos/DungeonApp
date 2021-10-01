using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Monster : Character
    {
        //fields
        private int _minDamage;

        //props
        public int MaxDamage { get; set; }
        public string Description { get; set; }
        public int MinDamage
        {
            get { return _minDamage;}
            set
            {
                //cannot be more than maxDamage or less than 1
                if (value > 0 && value <= MaxDamage)
                {
                    _minDamage = value;
                }//end if
                else
                {
                    _minDamage = 1;
                }//end else
            }//end set
        }//end MinDamage

        //ctors
        public Monster()
        {

        }

        public Monster(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description)
        {
            //Set the values of maxLife and maxDamage first
            MaxLife = maxLife;
            MaxDamage = maxDamage;
            Name = name;
            Life = life;
            HitChance = hitChance;
            Block = block;
            MinDamage = minDamage;
            Description = description;
        }//end FQ CTOR

        //methods
        public override string ToString()
        {
            return string.Format("****** Monster ******\n" +
                "{0}\n" +
                "Life: {1} to {2}\n" +
                "Damage: {3} to {4}\n" +
                "Block: {5}\n" +
                "Description:\n{6}",
                Name, Life, MaxLife, MinDamage, MaxDamage, Block, Description);
        }//end ToString()

        //We are going to override CalcDamage from Character class to use properties within this class (MinDamage and MaxDamage)
        public override int CalcDamage()
        {
            //return base.CalcDamage();-returns 0 in Character, we want to change that functionality for Monster
            Random rand = new Random();
            return rand.Next(MinDamage, MaxDamage + 1);//We add 1 to MaxDamage because the upper bound in Next() is exclusive
        }//end CalcDamage()
    }//end class
}//end namespace
