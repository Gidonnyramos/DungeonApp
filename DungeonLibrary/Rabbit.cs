using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Rabbit : Monster
    {
        //fields

        //props
        public bool IsFluffy { get; set; }

        //ctors
        //FQ CTOR
        public Rabbit(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description, bool isFluffy) : base(name, life, maxLife, hitChance, block, minDamage, maxDamage, description)
        {
            //Just handle unique assignments - isFluffy
            IsFluffy = isFluffy;
        }//end FQCTOR

        //Below: hijack the default ctor to provide some hardcoded, default values for a basic Rabbit
        public Rabbit()
        {
            //Set some hardcoded values
            MaxLife = 6;//Set Max values first
            MaxDamage = 3;
            Name = "Baby Rabbit";
            Life = 6;
            HitChance = 20;
            Block = 20;
            MinDamage = 1;
            Description = "It's just a cute little bunny. Why would you want to hurt it?!";
            IsFluffy = false;
        }//end default Rabbit ctor

        //methods
        public override string ToString()
        {
            return base.ToString() + (IsFluffy ? "Fluffy" : "Not so fluffy...");
        }//end ToString()

        //override the block to say that if the Rabbit is fluffy they get a 50% bonus on block
        public override int CalcBlock()
        {

            //Typically when dealing with a method that has a return type, will create a variable of that type, then create the return, then add the necessary functionality between the variable's declaration and the return
            int calculatedBlock = Block;

            if (IsFluffy)
            {
                //add a 50% bonus
                calculatedBlock += calculatedBlock / 2;
            }//end if

            return calculatedBlock;
        }//end CalcBlock
    }//end class
}//end namespace
