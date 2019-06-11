
/*
 * Greig Myles
 * 
 * This program will ask the user to create a character based on the tabletop game Dungeons & Dragons. The user will be asked to either create a character, or read descriptions of the races 
 * availible to choose from. The user will go through several procedures to get the race, the sub-race if applicable, the name of the charcter which is created depending on the race previously chosen and taken
 * from a text file. The user is then asked which class they would like to choose from a list, the next procedure will use a random generator to create stats based on different abilities such as strength,
 * dexterity etc. After the stat numbers have been generated, the stats are increased depending on the characters selected race there is a small maths function that gets the modifiers of the stats. 
 * All the character information will then be written into a text file. 
 * 
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Character_Creator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Character Stats
            //Array designations
            //0 - Strength
            //1 - Dexterity
            //2 - Wisdom
            //3 - Intelligence
            //4 - Constitution
            //5 - Charisma

            //Stat & Mod Arrays
            int[] statAttributes = new int[6];
            int[] statModifiers = new int[6];

            //Character Information
            string cRace = "";
            string cClass = "";
            string cSubRace = "";
            string cName = "";

            //Arrays
            string[] stats = { "Strength", "Dexterity", "Wisdom", "Intelligence", "Constitution", "Charisma" };
            string[] classes = { "Barbarian", "Bard", "Cleric", "Druid", "Fighter", "Monk", "Paladin", "Ranger", "Rogue", "Sorcerer", "Warlock", "Wizard" };
            string[] races = { "Dwarf", "Elf", "Halfling", "Human", "Dragonborn", "Gnome", "Half-Elf", "Half-Orc", "Tiefling" };

            //Other
            bool showDes = false;
            int choice = 0;

            do
            {
                Console.WriteLine("Would you like to create a character, or look at the racial descriptons?");
                Console.WriteLine("Press 1 for descriptions, or 2 for character creator");
                choice = Convert.ToInt16(Console.ReadLine());

                if (choice == 1)
                {
                    showDes = true;
                }
                else
                {
                    // Run Charcter Creator procedures
                }

                Console.Clear();

            } while (choice < 1 || choice > 2);


            while (showDes == true)
            {
                //This will get the race of the character
                GetRace(races, ref cRace);
                //This procedure will check the race of the character chosen and get a description of that race
                GetDescription(ref showDes, cRace);
            }

            //This will get the race of the character
            GetRace(races, ref cRace);
            //This will get the sub race of some races
            GetSubRace(races, cRace, ref cSubRace);
            //This will get the names depending on the characters race & gender
            GetNames(races, cRace, ref cName);
            //This will get the class of the character
            GetClass(classes, ref cClass);
            //This will get the stats of the character
            GetStats(ref statAttributes, stats);
            //This procedure will check the race of the character and add certain skills points
            GetScoreIncrease(ref statAttributes, cRace, cSubRace);
            //This will get the modifiers of the character
            GetModifiers(statAttributes, ref statModifiers);
            //This will show the final output to the user / print the data to a specific file
            CharacterOutput(statAttributes, statModifiers, stats, cRace, cClass, cName);

        }//end main

        //This procedure uses a for loop to run the amount of races.Length. This prints the races in numerical order to be chosen by the user. The choice is them stored in a variable called cRace (Character Race).
        //Validated by a do while loop to check that the users input is between 1 & 9 (amount of races availible)
        static void GetRace(string[] races, ref string cRace)
        {
            int choice = 0;

            do
            {
                Console.WriteLine("Choose a race from the following");
                for (int i = 0; i < races.Length; i++)
                {
                    Console.WriteLine("{0}: {1}", i + 1, races[i]);
                }//end menu loop

                choice = Convert.ToInt16(Console.ReadLine());

            } while (choice < 1 || choice > 9);
            //end while control

            cRace = races[choice - 1];

        }//end GetRace

        //This procedure will ask the user for a sub race, depending on the race chosen in previous procedures. Not all races have a sub-race. An if statement checks if the cRace against the races that have a
        //sub-race and asks the user to type which sub race they would like to choose by selecting 1 or 2, it validated with a do while loop checking that the number is not less then 1, or more than 2
        //and stores it in variable cSubRace (Character Sub Race)
        static void GetSubRace(string[] races, string cRace, ref string cSubRace)
        {
            int choice = 0;

            do
            {
                if (cRace == races[0])
                {
                    Console.WriteLine("There are two types of Dwarf,");
                    Console.WriteLine("1. Hill \n2.Mountain");
                    choice = Convert.ToInt16(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            cSubRace = "HILL";
                            break;
                        case 2:
                            cSubRace = "MOUNTAIN";
                            break;

                        default:
                            break;

                    }//end switch
                }//end Dwarf subraces

                else if (cRace == races[1])
                {
                    Console.WriteLine("There are two types of Elf,");
                    Console.WriteLine("1. High \n2. Wood");
                    choice = Convert.ToInt16(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            cSubRace = "HIGH";
                            break;
                        case 2:
                            cSubRace = "WOOD";
                            break;

                        default:
                            break;

                    }//end switch
                }//end Elf subraces

                else if (cRace == races[2])
                {
                    Console.WriteLine("There are two types of Halfling,");
                    Console.WriteLine("1. Lightfoot \n2. Stout");
                    choice = Convert.ToInt16(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            cSubRace = "LIGHTFOOT";
                            break;
                        case 2:
                            cSubRace = "STOUT";
                            break;

                        default:
                            break;

                    }//end switch
                }//end Halfling subraces

                else if (cRace == races[5])
                {
                    Console.WriteLine("There are two types of Gnome,");
                    Console.WriteLine("1. Forest \n2. Rock");
                    choice = Convert.ToInt16(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            cSubRace = "FOREST";
                            break;
                        case 2:
                            cSubRace = "ROCK";
                            break;

                        default:
                            break;

                    }//end switch
                }//end Gnome subraces

                else
                {
                    //DO NOTHING
                }

            } while (!(choice == 1 || choice == 2));



        }//end GetSubRace

        //This procedure will get the class of the users character by printing a list using a for loop to run by classes.Length. The users choice is validated by a do while loop to check that the input is between
        //1 & 12 the users choice is then stored in the variable cClass (Character Class)
        static void GetClass(string[] classes, ref string cClass)
        {
            int choice = 0;

            do
            {
                Console.WriteLine("Choose a class from the following list.");

                for (int i = 0; i < classes.Length; i++)
                {
                    Console.WriteLine("{0}: {1}", i + 1, classes[i]);
                }

                choice = Convert.ToInt16(Console.ReadLine());

            } while (choice < 1 || choice > 12);//validates input

            cClass = classes[choice - 1];

        }//end GetClass

        //This procedure will run a Random Number Generator to determine the attributes of the created character. Using a for loop to run though statAttributes.Length adding each attribute to the allocated
        //slot for each type of stat (Strength, Dexterity etc)
        static int[] GetStats(ref int[] statAttributes, string[] stats)
        {
            Random generator = new Random();
            int no = 0;

            for (int i = 0; i < statAttributes.Length; i++)
            {
                no = generator.Next(8, 15);
                Console.WriteLine(stats[i]);
                statAttributes[i] += no;
                Console.WriteLine("{0}", statAttributes[i]);
                Console.ReadLine();
            }

            return statAttributes;
        }//end GetStats

        //This procedure will run through the statAttributes array by using a for loop, it will take the value in each incementation minus 10 and divide by 2. The result is stored as an int in the statModifiers
        //array in the same slots as the statAttributes array
        static int[] GetModifiers(int[] statAttributes, ref int[] statModifiers)
        {
            for (int i = 0; i < statAttributes.Length; i++)
            {
                statModifiers[i] = (statAttributes[i] - 10) / 2;
            }
            return statModifiers;
        }//end GetModifiers

        //This procedure will check the race & sub-race of the created character and add a value to the stat that is relevent to the type of character. This uses a switch case statement to check the charatcers
        //race and sub-race.
        static void GetScoreIncrease(ref int[] statAttributes, string cRace, string cSubrace)
        {
            string subrace = cSubrace.ToUpper();
            string race = cRace.ToUpper();

            switch (race)
            {
                case "DWARF":
                    statAttributes[4] += 2;
                    break;

                case "ELF":
                    statAttributes[1] += 2;
                    break;

                case "HALFLING":
                    statAttributes[1] += 2;
                    break;

                case "HUMAN":
                    statAttributes[0] += 1;
                    statAttributes[1] += 1;
                    statAttributes[2] += 1;
                    statAttributes[3] += 1;
                    statAttributes[4] += 1;
                    statAttributes[5] += 1;
                    break;

                case "DRAGONBORN":
                    statAttributes[0] += 2;
                    break;

                case "GNOME":
                    statAttributes[3] += 2;
                    break;

                case "HALF-ELF":
                    statAttributes[5] += 2;
                    break;

                case "HALF-ORC":
                    statAttributes[0] += 2;
                    statAttributes[4] += 1;
                    break;

                case "TIEFLING":
                    statAttributes[3] += 1;
                    statAttributes[5] += 2;
                    break;
                default:
                    break;
            }//end race switch

            switch (subrace)
            {
                case "MOUNTAIN":
                    statAttributes[0] += 2;
                    break;
                case "HILL":
                    statAttributes[2] += 1;
                    break;
                case "HIGH":
                    statAttributes[3] += 1;
                    break;
                case "WOOD":
                    statAttributes[2] += 1;
                    break;
                case "STOUT":
                    statAttributes[4] += 1;
                    break;
                case "LIGHTFOOT":
                    statAttributes[5] += 1;
                    break;
                case "ROCK":
                    statAttributes[4] += 1;
                    break;
                case "FOREST":
                    statAttributes[1] += 1;
                    break;
                default:
                    break;
            }//end subrace switch
        }//end GetScoreIncrease

        //This procedure will ask which gender the created character is, it will then check which race the character is and load names & surnames from text files. Using a random umber generator it will pick a
        //name from a string array then assigns them as cName (Character Name)
        static void GetNames(string[] races, string cRace, ref string cName)
        {
            Random gen = new Random();
            int gender = 0;

            while (gender <= 0 || gender > 2)
            {
                Console.WriteLine("What gender is your character?");
                Console.WriteLine("1. Male");
                Console.WriteLine("2. Female");
                gender = Convert.ToInt16(Console.ReadLine());
                Console.Clear();
            }//end while

            switch (gender)
            {
                //Male names switch
                case 1:
                    if (cRace == races[0])
                    {
                        string[] names = File.ReadAllLines(@"F:\College Work\Software Design\Programming\C#\Assesment\DnD_Character_Creator\Names\Male\mDwarfNames.txt");
                        string[] surnames = File.ReadAllLines(@"F:\College Work\Software Design\Programming\C#\Assesment\DnD_Character_Creator\Names\DwarfSurnames.txt");

                        cName = names[gen.Next(0, names.Length)] + surnames[gen.Next(0, surnames.Length)];
                    }
                    else if (cRace == races[1])
                    {
                        string[] names = File.ReadAllLines(@"F:\College Work\Software Design\Programming\C#\Assesment\DnD_Character_Creator\Names\Male\mElvenNames.txt");
                        string[] surnames = File.ReadAllLines(@"F:\College Work\Software Design\Programming\C#\Assesment\DnD_Character_Creator\Names\ElvenSurnames.txt");

                        cName = names[gen.Next(0, names.Length)] + surnames[gen.Next(0, surnames.Length)];
                    }
                    else if (cRace == races[2])
                    {
                        string[] names = File.ReadAllLines(@"F:\College Work\Software Design\Programming\C#\Assesment\DnD_Character_Creator\Names\Male\mHalflingNames.txt");
                        string[] surnames = File.ReadAllLines(@"F:\College Work\Software Design\Programming\C#\Assesment\DnD_Character_Creator\Names\HalflingSurnames.txt");

                        cName = names[gen.Next(0, names.Length)] + surnames[gen.Next(0, surnames.Length)];
                    }
                    else if (cRace == races[3])
                    {
                        string[] names = File.ReadAllLines(@"F:\College Work\Software Design\Programming\C#\Assesment\DnD_Character_Creator\Names\Male\mHumanNames.txt");
                        string[] surnames = File.ReadAllLines(@"F:\College Work\Software Design\Programming\C#\Assesment\DnD_Character_Creator\Names\HumanSurnames.txt");

                        cName = names[gen.Next(0, names.Length)] + surnames[gen.Next(0, surnames.Length)];
                    }
                    else if (cRace == races[4])
                    {
                        string[] names = File.ReadAllLines(@"F:\College Work\Software Design\Programming\C#\Assesment\DnD_Character_Creator\Names\Male\mDragonbornNames.txt");
                        string[] surnames = File.ReadAllLines(@"F:\College Work\Software Design\Programming\C#\Assesment\DnD_Character_Creator\Names\DragonbornSurnames.txt");

                        cName = names[gen.Next(0, names.Length)] + surnames[gen.Next(0, surnames.Length)];
                    }
                    else if (cRace == races[5])
                    {
                        string[] names = File.ReadAllLines(@"F:\College Work\Software Design\Programming\C#\Assesment\DnD_Character_Creator\Names\Male\mGnomeNames.txt");
                        string[] surnames = File.ReadAllLines(@"F:\College Work\Software Design\Programming\C#\Assesment\DnD_Character_Creator\Names\GnomeSurnames.txt");

                        cName = names[gen.Next(0, names.Length)] + surnames[gen.Next(0, surnames.Length)];
                    }
                    else if (cRace == races[6])
                    {
                        string[] names = File.ReadAllLines(@"F:\College Work\Software Design\Programming\C#\Assesment\DnD_Character_Creator\Names\Male\mElvenNames.txt");
                        string[] surnames = File.ReadAllLines(@"F:\College Work\Software Design\Programming\C#\Assesment\DnD_Character_Creator\Names\HumanSurnames.txt");

                        cName = names[gen.Next(0, names.Length)] + surnames[gen.Next(0, surnames.Length)];
                    }
                    else if (cRace == races[7])
                    {
                        string[] names = File.ReadAllLines(@"F:\College Work\Software Design\Programming\C#\Assesment\DnD_Character_Creator\Names\Male\mHalfOrcNames.txt");
                        string[] surnames = File.ReadAllLines(@"F:\College Work\Software Design\Programming\C#\Assesment\DnD_Character_Creator\Names\HumanSurnames.txt");

                        cName = names[gen.Next(0, names.Length)] + surnames[gen.Next(0, surnames.Length)];
                    }
                    else if (cRace == races[8])
                    {
                        string[] names = File.ReadAllLines(@"F:\College Work\Software Design\Programming\C#\Assesment\DnD_Character_Creator\Names\Male\mTieflingNames.txt");

                        cName = names[gen.Next(0, names.Length)];
                    }
                    break;

                //Female names switch
                case 2:
                    if (cRace == races[0])
                    {
                        string[] names = File.ReadAllLines(@"F:\College Work\Software Design\Programming\C#\Assesment\DnD_Character_Creator\Names\Female\fDwarfNames.txt");
                        string[] surnames = File.ReadAllLines(@"F:\College Work\Software Design\Programming\C#\Assesment\DnD_Character_Creator\Names\DwarfSurnames.txt");

                        cName = names[gen.Next(0, names.Length)] + surnames[gen.Next(0, surnames.Length)];
                    }
                    else if (cRace == races[1])
                    {
                        string[] names = File.ReadAllLines(@"F:\College Work\Software Design\Programming\C#\Assesment\DnD_Character_Creator\Names\Female\fElvenNames.txt");
                        string[] surnames = File.ReadAllLines(@"F:\College Work\Software Design\Programming\C#\Assesment\DnD_Character_Creator\Names\ElvenSurnames.txt");

                        cName = names[gen.Next(0, names.Length)] + surnames[gen.Next(0, surnames.Length)];
                    }
                    else if (cRace == races[2])
                    {
                        string[] names = File.ReadAllLines(@"F:\College Work\Software Design\Programming\C#\Assesment\DnD_Character_Creator\Names\Female\fHalflingNames.txt");
                        string[] surnames = File.ReadAllLines(@"F:\College Work\Software Design\Programming\C#\Assesment\DnD_Character_Creator\Names\HalflingSurnames.txt");

                        cName = names[gen.Next(0, names.Length)] + surnames[gen.Next(0, surnames.Length)];
                    }
                    else if (cRace == races[3])
                    {
                        string[] names = File.ReadAllLines(@"F:\College Work\Software Design\Programming\C#\Assesment\DnD_Character_Creator\Names\Female\fHumanNames.txt");
                        string[] surnames = File.ReadAllLines(@"F:\College Work\Software Design\Programming\C#\Assesment\DnD_Character_Creator\Names\HumanSurnames.txt");

                        cName = names[gen.Next(0, names.Length)] + surnames[gen.Next(0, surnames.Length)];
                    }
                    else if (cRace == races[4])
                    {
                        string[] names = File.ReadAllLines(@"F:\College Work\Software Design\Programming\C#\Assesment\DnD_Character_Creator\Names\Female\fDragonbornNames.txt");
                        string[] surnames = File.ReadAllLines(@"F:\College Work\Software Design\Programming\C#\Assesment\DnD_Character_Creator\Names\DragonbornSurnames.txt");

                        cName = names[gen.Next(0, names.Length)] + surnames[gen.Next(0, surnames.Length)];
                    }
                    else if (cRace == races[5])
                    {
                        string[] names = File.ReadAllLines(@"F:\College Work\Software Design\Programming\C#\Assesment\DnD_Character_Creator\Names\Female\fGnomeNames.txt");
                        string[] surnames = File.ReadAllLines(@"F:\College Work\Software Design\Programming\C#\Assesment\DnD_Character_Creator\Names\GnomeSurnames.txt");

                        cName = names[gen.Next(0, names.Length)] + surnames[gen.Next(0, surnames.Length)];
                    }
                    else if (cRace == races[6])
                    {
                        string[] names = File.ReadAllLines(@"F:\College Work\Software Design\Programming\C#\Assesment\DnD_Character_Creator\Names\Female\mElvenNames.txt");
                        string[] surnames = File.ReadAllLines(@"F:\College Work\Software Design\Programming\C#\Assesment\DnD_Character_Creator\Names\HumanSurnames.txt");

                        cName = names[gen.Next(0, names.Length)] + surnames[gen.Next(0, surnames.Length)];
                    }
                    else if (cRace == races[7])
                    {
                        string[] names = File.ReadAllLines(@"F:\College Work\Software Design\Programming\C#\Assesment\DnD_Character_Creator\Names\Female\fHalfOrcNames.txt");
                        string[] surnames = File.ReadAllLines(@"F:\College Work\Software Design\Programming\C#\Assesment\DnD_Character_Creator\Names\HumanSurnames.txt");

                        cName = names[gen.Next(0, names.Length)] + surnames[gen.Next(0, surnames.Length)];
                    }
                    else if (cRace == races[8])
                    {
                        string[] names = File.ReadAllLines(@"F:\College Work\Software Design\Programming\C#\Assesment\DnD_Character_Creator\Names\Female\fTieflingNames.txt");

                        cName = names[gen.Next(0, names.Length)];
                    }
                    break;
            }//end gender switch

        }//end GetNames

        //This procedure takes all information created and inputs it into a text file. The name of the text file is the variable cName.
        static void CharacterOutput(int[] statAttributes, int[] statModifiers, string[] stats, string cRace, string cClass, string cName)
        {
            StreamWriter file = new StreamWriter(@"F:\College Work\Software Design\Programming\C#\Assesment\DnD_Character_Creator\Complete Characters\" + cName + ".txt");

            file.WriteLine(cName);
            file.WriteLine(cRace);
            file.WriteLine(cClass);

            //Prints each stat along side it's value
            for (int i = 0; i < statAttributes.Length; i++)
            {
                file.WriteLine("");
                file.WriteLine(stats[i]);
                file.WriteLine(statAttributes[i]);
                file.WriteLine("Modifier {0}", statModifiers[i]);
            }//Final output

            file.Close();

            Console.ReadLine();
        }//end CharacterOutput

        //This search function will run at the should the user want to see descriptions of the races before they run the creator in main. 
        static void GetDescription(ref bool showDes, string cRace)
        {
            string[] description = File.ReadAllLines(@"F:\College Work\Software Design\Programming\C#\Assesment\DnD_Character_Creator\Race Description\" + cRace + ".txt");
            int choice = 0;

            for (int i = 0; i < description.Length; i++)
            {
                Console.WriteLine(description[i]);
            }

                Console.WriteLine("Would you like to see a character description?");
                Console.WriteLine("Enter 1 for YES, Enter 2 for NO");
                Console.Clear();
                choice = Convert.ToInt16(Console.ReadLine());

                if (choice == 2)

                {
                    showDes = false;
                    cRace = "";
                }

                else
                {
                    //Do Nothing
                }
        }//end GetDescription

    }//end class
}//end namespace
