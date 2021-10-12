using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    //The abstract modifier indicates that this is an incomplete implementation of a class and only to be used as a base for other classes. In other words, by using ABSTRACT, we are making it impossible to create an object of type Character in the console application. Use the abstract modifier in a class signature to indicate that the class is intended to only be a base (parent) class to its children, but never directly used in the UI.
    public abstract class Character
    {
        //fields
        private int _life;//We will have a biz rule on life...it can never be more than maxLife. So we have to make a field

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
        //Since we don't inherit ctors and we will build the Player and Monster classes, we don't need a ctor in this class.

        //methods
        //No need for the ToString() as we will handle those in child classes

        //We will add CalcBlock(), CalcHitChance(), and CalcDamage() below. All of these methods will include the VIRTUAL keyword, making the method overrideable in child classes.
        public virtual int CalcBlock()
        {
            //This basic version just returns block, but this will give us the option to do something different in child classes.
            return Block;
        }//end CalcBlock()

        public virtual int CalcHitChance()
        {
            return HitChance;
        }//end CalcHitChance()

        public virtual int CalcDamage()
        {
            return 0;

            //Starting with 0 in this base method. We will override the method in Monster and Player.
        }//end CalcDamage()
    }//end class
}//end namespace
