using monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monsters
{
    // **************************************************
    //
    // Title: Monsters
    // Description: Demonstration of classes and objects
    // Author: Velis, John
    // Dated Created: 11/11/2019
    // Last Modified: 
    //
    // **************************************************    
    class Program
    {
        static void Main(string[] args)
        {

            //
            //initialize monster list
            //
            List<Monster> monsters = InitializeMonsterList();

            //
            // call menu
            //
            DisplayMenuScreen(monsters);

        }

        static List<Monster> InitializeMonsterList()
        {
            List<Monster> monsters = new List<Monster>();
            //
            //create (instantiate) new monsters
            //
            Monster sid = new Monster();
            Monster lucy = new Monster();

            //
            //
            //
            sid.Name = "Sid";
            sid.Age = 155;
            sid.Attitude = Monster.EmotionalState.happy;

            lucy.Name = "Lucy";
            lucy.Age = 180;
            lucy.Attitude = Monster.EmotionalState.bored;

            //
            //add monster to list
            //
            monsters.Add(sid);
            monsters.Add(lucy);

            return monsters;

        }

        static void DisplayMenuScreen(List<Monster> monsters)
        {
            bool quitApplication = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Main Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("a) List All Monsters");
                Console.WriteLine("b) View Monster");
                Console.WriteLine("c) Add Monster");
                Console.WriteLine("d) ");
                Console.WriteLine("e) ");
                Console.WriteLine("f) ");
                Console.WriteLine("q) Quit");
                Console.Write("Enter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayAllMonters(monsters);
                        break;

                    case "b":
                        DisplayViewMonster(monsters);
                        break;

                    case "c":
                        DisplayAddMonster(monsters);
                        break;

                    case "d":

                        break;

                    case "e":

                        break;

                    case "f":

                        break;

                    case "q":
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("Please enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }


            } while (!quitApplication);
        }

        static void DisplayViewMonster(List<Monster> monsters)
        {
            string name;
            Monster monsterToView = null;

            DisplayScreenHeader("View Monster");

            //
            //list all moster names
            //
            foreach (Monster monster in monsters)
            {
                Console.WriteLine("\t" + monster.Name);         
            }
            Console.WriteLine();

            //
            //user choose a monster
            //

            Console.Write("Enter Name:");
            name = Console.ReadLine();

            //
            //get monster
            //
            foreach (Monster monster in monsters)
            {
                if (monster.Name == name)
                {
                    monsterToView = monster;
                    break;
                }
            }

            //
            //display monster detail
            //
            Console.WriteLine();
            MonsterInfo(monsterToView);

            DisplayContinuePrompt();
        }

        static void DisplayAddMonster(List<Monster> monsters)
        {
            Monster newMonster = new Monster();

            DisplayScreenHeader("Add Monster");

            //
            //get monster properties
            //
            Console.Write("\tName:");
            newMonster.Name = Console.ReadLine();

            Console.Write("\tAge:");
            int.TryParse(Console.ReadLine(), out int age);
            newMonster.Age = age;

            Console.Write("\tAttitude:");
            Enum.TryParse(Console.ReadLine(), out Monster.EmotionalState attitude);
            newMonster.Attitude = attitude;

            //
            //echo monster properties
            //
            Console.WriteLine("\tMonster Properties");
            Console.WriteLine("\t*******************");
            MonsterInfo(newMonster);


            DisplayContinuePrompt();

            monsters.Add(newMonster);
        }

        static void MonsterInfo(Monster monster)
        {
            Console.WriteLine($"\tName: {monster.Name}");
            Console.WriteLine($"\tAge: {monster.Age}");
            Console.WriteLine($"\tAttitude: {monster.Attitude}");
        }

        static void DisplayAllMonters(List<Monster> monsters)
        {
            DisplayScreenHeader("All Monsters");


            Console.WriteLine("\t**********************************");
            foreach (Monster monster in monsters)
            {
                MonsterInfo(monster);
                Console.WriteLine();
                Console.WriteLine("\t*******************************");
                Console.WriteLine();
            }

            DisplayContinuePrompt();
        }

        #region HELPER METHODS

        /// <summary>
        /// display welcome screen
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThe Calculator");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display closing screen
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using the Calculator!");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display screen header
        /// </summary>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }

        #endregion
    }
}
