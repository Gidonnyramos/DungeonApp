using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Turtle : Monster
    {

        public int BonusBlock { get; set; }
        public int HidePercent { get; set; }

        public Turtle()
        {
         
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
        }

        public Turtle(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description, int bonusBlock, int hidePercent) : base(name, life, maxLife, hitChance, block, minDamage, maxDamage, description)
        {
       
            BonusBlock = bonusBlock;
            HidePercent = hidePercent;
        }

   
        public override string ToString()
        {
            return $"{base.ToString()}\nChance it will hide: {HidePercent}\nBonus Block: {BonusBlock}";
        }

        public override int CalcBlock()
        {
            int calculatedBlock = Block;

            Random rand = new Random();
            int percent = rand.Next(1, 101);
     
            if (percent <= HidePercent)
            {
        
                calculatedBlock += BonusBlock;
            }


            return calculatedBlock;
        }


    }
}
