using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Turtle : Monster
    {

        //fields/props
        public int BonusBlock { get; set; }
        public int HidePercent { get; set; }

        //ctors - use the default to make a basic Turtle and the FQ CTOR to make a unique turtle
        public Turtle()
        {
            //SET MAX VALUES FIRST!!
            MaxLife = 6;
            MaxDamage = 3;
            Life = 6;
            MinDamage = 0;
            HitChance = 5;
            Block = 10;
            Name = "Baby Turtle";
            Description = "It's a cute baby turtle...keep it away from the ooze!";
            BonusBlock = 5;
            HidePercent = 10;
        }//end default

        public Turtle(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description, int bonusBlock, int hidePercent) : base(name, life, maxLife, hitChance, block, minDamage, maxDamage, description)
        {
            //Handle the unique property assignments for Turtle
            BonusBlock = bonusBlock;
            HidePercent = hidePercent;
        }//end FQCTOR

        //Methods
        public override string ToString()
        {
            return $"{base.ToString()}\nChance it will hide: {HidePercent}\nBonus Block: {BonusBlock}";
        }//end ToString

        public override int CalcBlock()
        {
            int calculatedBlock = Block;

            //get a random number from 1-100
            Random rand = new Random();
            int percent = rand.Next(1, 101);
            //see if that is less than or equal to the hide percent...if so, the Turtle gets a bonus
            if (percent <= HidePercent)
            {
                //if so, give a bonus
                calculatedBlock += BonusBlock;
            }

            //return calculatedBlock
            return calculatedBlock;
        }//end CalcBlock()


    }//end class
}//end namespace
