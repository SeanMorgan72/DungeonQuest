using System;

namespace DungeonQuest
{
    class Program
    {
        public static Player currentPlayer = new Player();
        public static bool battleLoop = true;
        static void Main(string[] args)
        {
            
            Start();
            
            while (battleLoop)
            {
                Encounters.RandomCombat();
            }
        }


        static void Start()
        {
            Console.WriteLine("\t\t\t\tDungeon Quest\t\t\t\t");
            Console.WriteLine("\t\t\t\tby: Sean Morgan\t\t\t\t");
            Console.WriteLine("\t\t\t---------------------------\t\t\t");
            Console.WriteLine("");
            Console.WriteLine("Name: \n");
            currentPlayer.Name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("After cram studying and taking exams at the local University, you come bach to the dorm to relax.\n");
            Console.WriteLine("You start playing your favorite rpg video game and as some time passes you become drowsy and fall asleep.\n");
            Console.WriteLine("You awaken from the feeling of shivers from the cold, damp, dark room.\n");
            Console.WriteLine("A feeling of confusion comes over you and your having trouble remembering what has happened.\n");
            if(currentPlayer.Name == "")
                Console.WriteLine("Though, you can not even remember your own name...\n");
            else
                Console.WriteLine($"Though, you know your name is {currentPlayer.Name}\n");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("You begin to grope blindly in the dark room until you feel the cold metal door handle.\n");
            Console.WriteLine("Trying to turn the handle, there is some resistance until the rusted door lock brittles to dust.\n");
            Console.WriteLine("Upon the door opening you gaze upon a gruesome creature.\n");
        }                 
    }
}
