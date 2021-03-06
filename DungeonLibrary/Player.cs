using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    
    public sealed class Player : Character
    {
     

        public Race CharacterRace { get; set; }
        public Weapon EquippedWeapon { get; set; }

     
        public Player(string name, int hitChance, int block, int life, int maxLife, Race characterRace, Weapon equippedWeapon)
        {
         
            MaxLife = maxLife;
            Name = name;
            HitChance = hitChance;
            Block = block;
            Life = life;
            CharacterRace = characterRace;
            EquippedWeapon = equippedWeapon;
        }

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
        }

        public override int CalcDamage()
        {
     

            return new Random().Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);
        }

        public override int CalcHitChance()
        {
            return base.CalcHitChance() + EquippedWeapon.BonusHitChance;
        }
    }
}