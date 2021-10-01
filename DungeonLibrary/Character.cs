using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{

    public abstract class Character
    {
        //fields
        private int _life;//will have a biz rule on life...it can never be more than maxLife. So have to make a field

        //props
        public string Name { get; set; }
        public int HitChance { get; set; }
        public int Block { get; set; }
        public int MaxLife { get; set; }
        //It is important that any properties that rely on other properties for their creation, that they are listed last after the property they rely on.
        public int Life
        {
            get { return _life; }
            set
            {
                //biz rule - life should not be more than MaxLife
                if (value <= MaxLife)
                {
                    //good to go
                    _life = value;
                }//end if
                else
                {
                    _life = MaxLife;
                }//end else
            }//end set
        }//end int Life

        //ctors
        //not inherit ctors and will build the Player and Monster classes, don't need a ctor in this class.

        //methods
        //No need for the ToString() will handle those in child classes

        //will add CalcBlock(), CalcHitChance(), and CalcDamage() below. All of these methods will include the VIRTUAL keyword, making the method overrideable in child classes.
        public virtual int CalcBlock()
        {
            //This basic version just returns block, but this will give the option to do something different in child classes.
            return Block;
        }//end CalcBlock()

        public int CalcHitChance()
        {
            return HitChance;
        }//end CalcHitChance()

        public int CalcDamage()
        {
            return 0;

            //Starting with 0 in this base method; will override the method in Monster and Player.
        }//end CalcDamage()
    }//end class
}//end namespace
