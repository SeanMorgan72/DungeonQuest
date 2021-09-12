using System;
namespace DungeonQuest
{
    public class Encounters
    {
        static Random ran = new Random();
        //Generic Encounters




        //Battle Encounters
        public static void BattleOne()
        {
            Console.WriteLine("The creature bellows a ear shrieking roar and lunges toward you. Quickly, you lunge toward \n");
            Console.WriteLine("your right and come upon a rusty blade that you instictivly grabbed, The creature turns...\n");
            Console.ReadKey();
            Combat(true, "", 1, 5);
        }

        public static void BasicBattle()
        {
            Console.Clear();
            Console.WriteLine("You make your way through the corridors of the dungeon to come upon ...\n");
            Console.ReadKey();
            Combat(true, "", 0, 0);
        }

        public static void BattleTwo()
        {
            Console.Clear();
            Console.WriteLine("You come upon a gate that is made of a  mixture of iron and steel, the gate will not budge.\n");
            Console.WriteLine("While turning to walk another path, the gate starts to rise open and a gust of odorous wind comes forth.\n");
            Console.WriteLine("Then you see a ...\n");
            Console.ReadKey();
            Combat(true, "", 2, 8);
        }



        //Encounter Tools
        public static void RandomCombat()
        {
            switch(ran.Next(0, 2))
            {
                case 0:
                    BasicBattle();
                    break;

                case 1:
                    BattleOne();
                    break;

                case 2:
                    BattleTwo();
                    break;
            }
        }
        public static void Combat(bool random, string name, int power, int health)
        {
            string n = "";
            int p = 0;
            int h = 0;
            if (random)
            {
                n = GetName();
                p = Program.currentPlayer.GetPower();
                h = Program.currentPlayer.GetHealth();
            }
            else
            {
                n = name;
                p = power;
                h = health;
            }

            while(h > 0)
            {
                Console.Clear();
                Console.WriteLine($"{n}");
                Console.WriteLine($"Power: {p} / Health: {h}");
                Console.WriteLine("---------------------------");
                Console.WriteLine("|   (A)ttach  (D)efend    |");
                Console.WriteLine("|   (R)un     (H)eal      |");
                Console.WriteLine("|   (Q)uit Game           |");
                Console.WriteLine("---------------------------");
                Console.WriteLine($"Potions: {Program.currentPlayer.Potion} Health: {Program.currentPlayer.Health}");
                var input = Console.ReadLine();
                if(input.ToLower() == "a" || input.ToLower() == "attack")
                {
                    //Attack
                    Console.WriteLine("With all your fighting instinct you lunge forward flaying the rust covered blade.\n");
                    Console.WriteLine($"As you pass the {n} strikes at you with his spiked club.\n");
                    var damage = p - Program.currentPlayer.ArmorValue;
                    if (damage < 0)
                        damage = 0;
                    var attack = ran.Next(0, Program.currentPlayer.WeaponValue) + ran.Next(1, 5);
                    Console.WriteLine($"You obtained a lose of {damage} in health and dealt {attack} in damage.\n");
                    Program.currentPlayer.Health -= damage;
                    h -= attack;
                }
                else if (input.ToLower() == "d" || input.ToLower() == "defend")
                {
                    //Defend
                    Console.WriteLine($"As the {n} prepares to deal another swing, you grab your blade in a defensive posture.\n");
                    var damage = (p/4) - Program.currentPlayer.ArmorValue;
                    if (damage < 0)
                        damage = 0;
                    var attack = ran.Next(0, Program.currentPlayer.WeaponValue) / 2;
                    Console.WriteLine($"You obtained a lose of {damage} in health and dealt {attack} damage.\n");
                    Program.currentPlayer.Health -= damage;
                    h -= attack;
                }
                else if (input.ToLower() == "r" || input.ToLower() == "run")
                {
                    //Run
                    if(ran.Next(0, 2) == 0)
                    {
                        Console.WriteLine($"As you swiftly run away from {n}, it's mighty strike catches upto you and wallops you to the ground.\n");
                        var damage = p - Program.currentPlayer.ArmorValue;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine($"You lose {damage} to health and are unable to escape propable death.\n");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine($"You use your quick agility and speed to evade the {n} and successfully escape!\n");
                        Console.ReadKey();
                        Store.SupplyStore(Program.currentPlayer);
                    }
                }
                else if (input.ToLower() == "h" || input.ToLower() == "heal")
                {
                    //Heal
                    if(Program.currentPlayer.Potion == 0)
                    {
                        Console.WriteLine("As you desperately search in your carry bag for a potion, all you feel are empty containers.\n");
                        var damage = p - Program.currentPlayer.ArmorValue;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine($"The {n} strikes at you with a mighty blow to your side and you lose {damage} to your health.\n");
                    }
                    else
                    {
                        Console.WriteLine("In a deperate search for a potion in your carry bag, you succesfully felt one last bottle.\n");
                        var potionValue = 10;
                        Console.WriteLine($"You guzzle the potion down in one continuous drinking motion and gained {potionValue} added to health.\n");
                        Program.currentPlayer.Health += potionValue;
                        Console.WriteLine($"While you were occupied in recovery from drinking the potion, the {n} advanced toward you.\n");
                        var damage = (p / 2) - Program.currentPlayer.ArmorValue;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine($"The {n} lunges at you while attempting to deal a mighty blow; you lose {damage} to your health.\n");
                    }
                    Console.ReadKey();
                }
                else if(input == "q" || input == "quit")
                {
                    Console.WriteLine($"{Program.currentPlayer.Name} has decided to leave the dungeon and quit the quest.\n");
                    Console.ReadKey();
                    System.Environment.Exit(0);
                }
                if(Program.currentPlayer.Health <= 0)
                {
                    //Death
                    Console.WriteLine($"As you slump helplessly on the ground, the {n} stands over you.\n");
                    Console.WriteLine($"As the {n} menacingly laughs over you while dealing the final death blow.\n");
                    Console.ReadKey();
                    System.Environment.Exit(0);
                }
                Console.ReadKey();
            }
            var coins = ran.Next(10, 50);
            Console.WriteLine($"As you survive this battle with the {n}, you witnes the body slowly dissolve into {coins} gold coins.\n");
            Program.currentPlayer.Coins += coins;
            Console.ReadKey();
        }

        public static string GetName()
        {
            switch(ran.Next(0, 6))
            {
                case 0:
                    return "Bandit";

                case 1:
                    return "HobGoblin";

                case 2:
                    return "Ogre";

                case 3:
                    return "Death Knight";

                case 4:
                    return "Samurai Skeleton";

                case 5:
                    return "Dark Elf";

                default:
                    return "Doppleganger";
            }
        }
    }
}
