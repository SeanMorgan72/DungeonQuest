using System;
namespace DungeonQuest
{
    
    public class Player
    {
        Random ran = new Random();
        public string Name { get; set; }
        public int Id { get; set; }

        public int Coins { get; set; } = 40000;
        public int Health { get; set; } = 10;
        public int Damage { get; set; } = 0;
        public int ArmorValue { get; set; } = 0;
        public int Potion { get; set; } = 5;
        public int WeaponValue { get; set; } = 1;

        public int Mods { get; set; }

        public int GetHealth()
        {
            var upper = 2 * Mods + 5;
            var lower = Mods + 2;
            return ran.Next(lower, upper);
        }

        public int GetPower()
        {
            var upper = 2 * Mods + 3;
            var lower = Mods + 1;
            return ran.Next(lower, upper);
        }
    }
}
