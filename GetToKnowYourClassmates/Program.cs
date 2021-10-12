using System;
using System.Collections.Generic;

namespace GetToKnowYourClassmates
{
    class Program
    {
        static void Main(string[] args)
        {
            bool cntnu = true;
            string[] classmates = new string[10];
            classmates[0] = "Beer, Andy";
            classmates[1] = "Conrad, Phillip";
            classmates[2] = "Parr, Zachary";
            classmates[3] = "Christian, Cortez";
            classmates[4] = "Walter, Erin";
            classmates[5] = "Moss, Richard";
            classmates[6] = "Flynn, Cullin";
            classmates[7] = "Reddy, Anurag";
            classmates[8] = "Patton, Marjorie";
            classmates[9] = "Ebberhart, Cordero";

            Dictionary<string, string> HomeTown = new Dictionary<string, string>();
            HomeTown.Add("Beer, Andy", "Berkley, MI");
            HomeTown.Add("Conrad, Phillip", "Canton, MI");
            HomeTown.Add("Parr, Zachary", "Wyandotte, MI");
            HomeTown.Add("Christian, Cortez", "Detroit, MI");
            HomeTown.Add("Walter, Erin", "Troy, MI");
            HomeTown.Add("Moss, Richard", "Canton, MI");
            HomeTown.Add("Flynn, Cullin", "Fowlerville, MI");
            HomeTown.Add("Reddy, Anurag", "Rochester Hills, MI");
            HomeTown.Add("Patton, Marjorie", "Detroit, MI");
            HomeTown.Add("Ebberhart, Cordero", "Berkley, MI");

            Dictionary<string, string> FavFood = new Dictionary<string, string>();
            FavFood.Add("Beer, Andy", "French Fries");
            FavFood.Add("Conrad, Phillip", "Fried Chicken");
            FavFood.Add("Parr, Zachary", "Sushi");
            FavFood.Add("Christian, Cortez", "Chicken Fettuccine Alfredo");
            FavFood.Add("Walter, Erin", "Tacos");
            FavFood.Add("Moss, Richard", "Sushi");
            FavFood.Add("Flynn, Cullin", "Pad Thai");
            FavFood.Add("Reddy, Anurag", "Tacos");
            FavFood.Add("Patton, Marjorie", "Lasagna");
            FavFood.Add("Ebberhart, Cordero", "BBQ");

            Console.WriteLine("Welcome to DevBuild7!");

            /*
            foreach(string mate in classmates)
            {
                Console.WriteLine(mate);
            }

            foreach(KeyValuePair<string,string> kvp in HomeTown)
            {
                Console.WriteLine($"{kvp.Key} is from {kvp.Value}");
            }

            foreach(KeyValuePair<string,string> kvp2 in FavFood)
            {
                Console.WriteLine($"{kvp2.Key} favorite food is {kvp2.Value}");
            }
            */

            while (cntnu)
            {
                int studentNumber = 1;
                string pickClassMember = GetUserInput("Which student would you like to learn more about? (enter a number from 1-10): ");
                if(!int.TryParse(pickClassMember, out studentNumber) || int.Parse(pickClassMember)>10 || int.Parse(pickClassMember) < 0)
                {
                    
                    cntnu = ShallWe("error");
                    if(cntnu == false)
                    {
                        break;
                    }
                    else
                    {
                        continue;
                    }

                }

                //int studentNumber = int.Parse(pickClassMember);
                studentNumber = studentNumber - 1; //arrays start at 0, student numbers start at 1, so need to subtract 1.
                string selectedStudent = classmates[studentNumber];
                Console.WriteLine("");
                Console.WriteLine($"Student: {selectedStudent} ");
                Console.WriteLine("");
                if (SpillTheBeans(selectedStudent) == "hometown")
                {
                    Console.WriteLine($"{selectedStudent} is from {HomeTown[selectedStudent]}");
                }
                else
                {
                    Console.WriteLine($"{selectedStudent} likes to eat {FavFood[selectedStudent]}");
                }
                Console.WriteLine("");
                cntnu = ShallWe(" ");
            }
            
        }
        private static string GetUserInput(string prompt)
        {
            Console.Write(prompt);
            string response = Console.ReadLine();

            return response;
        }
        private static bool ShallWe(string reason)
        {
            string answer;
            if(reason == "error")
            {
                Console.WriteLine("That was not a valid selection");
                answer = GetUserInput("Would you like to continue?(y/n)");
            }
            else
            {
                answer = GetUserInput("Would you like to learn about another student?(y/n): ");
            }
            
            if (answer.ToLower() == "y")
            {
                return true;
            }
            else if(answer.ToLower() == "n")
            {
                Console.WriteLine("Goodbye!");
                return false;
            }
            else
            {
                Console.WriteLine("Sorry, I did not understand that");
                return ShallWe(reason);

            }

        }
        private static string SpillTheBeans(string whoIsIt)
        {
            //string whoNow = whoIsIt;
            string whatNow = GetUserInput($"What would you like to know about {whoIsIt}? (enter 'hometown' or 'favorite food'): ");
            if (whatNow == "hometown" || whatNow == "home town")
            {
                return whatNow;

            }
            else if (whatNow == "favorite food" || whatNow == "favoritefood") 
            {
                return whatNow;
            }
            else
            {
                Console.WriteLine("That data does not exist. Please try again. Enter 'hometown' or 'favorite food'");
                return SpillTheBeans(whoIsIt);
            }
        }
    }
}
