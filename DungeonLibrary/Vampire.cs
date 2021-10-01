using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Vampire
    {

        //fields/props
        public DateTime HourChangeBack { get; set; }

        //ctor - This ctor will not include the HourChangeBack date/time as a parameter. Instead, using the property to determine the time of day this instance of a vampire was created.
        public Vampire(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description) : base(name, life, maxLife, hitChance, block, minDamage, maxDamage, description)
        {
            HourChangeBack = DateTime.Now;

            if (HourChangeBack.Hour < 6 || HourChangeBack.Hour > 18)
            {
                //This means the time of day is between 6pm and 6am
                HitChance += 10;
                Block += 10;
                MinDamage += 1;
                MaxDamage += 2;
            }//end if
        }//end ctor

        //methods
        public override string ToString()
        {
            return $"{base.ToString()}\n" +
                $"{(HourChangeBack.Hour < 6 || HourChangeBack.Hour > 18 ? "It looks strong and angry." : "In the daylight, it looks kind of weak...")}";
        }//end ToString()

    }//end class
}//end namespace
