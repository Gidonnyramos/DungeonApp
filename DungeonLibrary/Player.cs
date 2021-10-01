using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    //This class is a child of Character. The sealed keyword indicates that this class cannot be used as a base/parent class for any other class. No inheritance can occur for Player from here.
    public sealed class Player : Character
    {
        //fields
        //no biz rules - so all auto-props

        //props
        public Race CharacterRace { get; set; }
        public Weapon EquippedWeapon { get; set; }

        //ctors
        //FQ CTOR
        public Player(string name, int hitChance, int block, int life, int maxLife, Race characterRace, Weapon equippedWeapon)
        {
            //life depends on maxLife to have a value, so set MaxLife first!
            MaxLife = maxLife;
            Name = name;
            HitChance = hitChance;
            Block = block;
            Life = life;
            CharacterRace = characterRace;
            EquippedWeapon = equippedWeapon;
        }//end FQ CTOR

        //methods
        public override string ToString()
        {
            return string.Format("-=-= {0} =-=-\n" +
                "Life: {1} of {2}\n" +
                "Hit Chance: {3}%\n" +
                "Weapon:\n{4}\n" +
                "Block: {5}\n" +
                "Description: {6}",
                Name,
                Life, MaxLife,
                CalcHitChance(),
                EquippedWeapon,
                Block,
                CharacterRace);
        }//end ToString

        //The below methods are inherited from Character. We override these methods to create custom functionality for the Player class
        public override int CalcDamage()
        {
            //Create a random object
            //Random rand = new Random();
            ////determine the damage
            //int damage = rand.Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);
            ////return the damage
            //return damage;

            return new Random().Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);
        }//end CalcDamage()

        public override int CalcHitChance()
        {
            return base.CalcHitChance() + EquippedWeapon.BonusHitChance;
        }//end CalcHitChance()
    }//end class
}//end namespace
