using System;
namespace DungeonQuest
{
    public class Store
    {

        public static void SupplyStore(Player x)
        {
            RunStore(x);
        }


        public static void RunStore(Player x)
        {
            int potionPrice;
            int armorPrice;
            int weaponPrice;
            int diffPrice;
            while (true)
            {
                potionPrice = 20 + 10 * x.Mods;
                armorPrice = 100 * (x.ArmorValue + 1);
                weaponPrice = 100 * x.WeaponValue;
                diffPrice = 300 + 100 * x.Mods;
                Console.Clear();
                Console.WriteLine($"              Dungeon Store            |");
                Console.WriteLine($"---------------------------------------|");
                Console.WriteLine($"|(A)rmor:             $ {armorPrice}    ");
                Console.WriteLine($"|(W)eapons:           $ {weaponPrice}   ");
                Console.WriteLine($"|(P)otion:            $ {potionPrice}   ");
                Console.WriteLine($"|(D)ifficulty:        $ {diffPrice}     ");
                Console.WriteLine($"|--------------------------------------|");
                Console.WriteLine($"|(E)xit                                |");
                Console.WriteLine($"|______________________________________|");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine($"             {x.Name} Stats              ");
                Console.WriteLine($"_________________________________________");
                Console.WriteLine($"|Defense Strength:     {x.ArmorValue}    ");
                Console.WriteLine($"|Offensive Strength:   {x.WeaponValue}   ");
                Console.WriteLine($"|Current Health:       {x.Health}        ");
                Console.WriteLine($"|Potion Count:         {x.Potion}        ");
                Console.WriteLine($"|Difficulty Mods:      {x.Mods}          ");
                Console.WriteLine($"|Gold Coin Count:      {x.Coins}         ");
                Console.WriteLine($"|________________________________________|");
                //Wait for input
                var input = Console.ReadLine().ToLower();

                if (input == "a" || input == "armor")
                {
                    TryBuy("a", armorPrice, x);
                }
                else if (input == "w" || input == "weapons")
                {
                    TryBuy("w", weaponPrice, x);
                }
                else if (input == "p" || input == "potion")
                {
                    TryBuy("p", potionPrice, x);
                }
                else if (input == "d" || input == "difficulty")
                {
                    TryBuy("d", diffPrice, x);
                }
                else if (input == "e" || input == "exit")
                    break;
            }            
        }

        public static void TryBuy(string item, int cost, Player x)
        {
            if(x.Coins >= cost)
            {
                if (item == "a")
                    x.ArmorValue++;
                else if (item == "w")
                    x.WeaponValue++;
                else if (item == "p")
                    x.Potion++;
                else if (item == "d")
                    x.Mods++;

                x.Coins -= cost;
            }
            else
            {
                Console.WriteLine("You don't have enough coinage!\n");
                Console.ReadKey();
            }
        }
    }   
}
