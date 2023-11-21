using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProgPoe1
{
    public class CallNumbers
    {
        // Collections to save the data
        // From the text file into levels - 1 - 3
        public static List<string> thirdLevels = new List<string>();
        public static List<string> secondLevels = new List<string>();
        public static List<string> firstLevels = new List<string>();

        // Variables to track answers for checking
        public static string myAnswer = "";
        public static string myGoal = "";
        public static string finalLevelAnswer = "";

        // List to store options user can use
        public static List<string> thirdLevelChoices = new List<string>();
        public static List<string> secondLevelChoices = new List<string>();
        public static List<string> firstLevelChoices = new List<string>();

        // Tracking input
        public static string thirdLevelAnswer = "";
        public static string secondLevelAnswer = "";
        public static string firstLevelAnswer = "";

        // To randomize
        public static Random randNumber = new Random();

        // Get the text file    
        public static void LoadCallNumbers()
        {
            // You can adjust as needed
            string myPath = @"C:\Users\16nai\source\repos\ProgPoe1\bin\Debug\Call.txt";   
            string[] txtFile;

            // Check if file exists
            if (!File.Exists(myPath))
            {
                MessageBox.Show("Call Numbers - Loading Error");
            }
            else
            {
                // Read from the file 
                txtFile = File.ReadAllLines(myPath);
                MessageBox.Show("File Exists");

                // Ready to pass onto the tree
                string totalTree = "";

                foreach (string s in txtFile)
                {
                    totalTree += s;
                }

                treeNode tree = treeNode.BuildTree(txtFile);
                // Space for random generation and scrambling

                // Generate a random answer for the user to guess and random wrong options
                SelectRandomAnswer(tree);

                myGoal = thirdLevelAnswer.Substring(4, thirdLevelAnswer.Length - 4);
            }
        }

        // Method to select random answer
        private static void SelectRandomAnswer(treeNode tree)
        {
            firstLevels.Clear();
            secondLevels.Clear();
            thirdLevels.Clear();

            foreach (treeNode tree1 in tree)
            {
                // Hundreds 7
                firstLevels.Add(tree1.ID);

                foreach (treeNode tree2 in tree)
                {
                    // Tens 6
                    secondLevels.Add(tree2.ID);

                    foreach (treeNode tree3 in tree)
                    {
                        // Units 8
                        thirdLevels.Add(tree3.ID);
                    }
                }
            }

            // Clears user choices
            firstLevelChoices.Clear();
            secondLevelChoices.Clear();
            thirdLevelChoices.Clear();

            // Randomly gen at least 4 options for the user to choose --> tens
            int choice = randNumber.Next(firstLevels.Count());
            firstLevelAnswer = firstLevels[choice];
            firstLevelChoices.Add(firstLevelAnswer);

            // Now add the wrong answers
            for (int i = 0; i < 3; i++)
            {
                Random rand = new Random(Guid.NewGuid().GetHashCode());
                int randomChoice = rand.Next(firstLevels.Count);

                // Check if the answer is correct -- This is where points will be added
                if (!firstLevels[randomChoice].Equals(firstLevelAnswer) && !firstLevelChoices.Contains(firstLevels[randomChoice]))
                {
                    firstLevelChoices.Add(firstLevels[randomChoice]);
                }
                else
                {
                    i--;
                }

            } // End of for -> Level 1

            // Level 2 logic
            for (int i = 0; i < 1; i++)
            {
                Random rand = new Random(Guid.NewGuid().GetHashCode());
                int randomChoice = rand.Next(secondLevels.Count);

                // Cant cont if level 1 answer is wrong
                if (secondLevels[choice].StartsWith(firstLevelAnswer.Substring(0, 1)))
                {
                    secondLevelAnswer = firstLevels[choice];
                    secondLevelChoices.Add(secondLevelAnswer);
                }
                else
                {
                    i--;
                }
            }

            // Now give 3 wrong options for level 2
            for (int i = 0; i < 3; i++)
            {
                Random rand = new Random(Guid.NewGuid().GetHashCode());
                int randomChoice = rand.Next(secondLevels.Count);

                // Check if the answer is correct -- This is where points will be added
                if (!secondLevels[randomChoice].StartsWith(firstLevelAnswer.Substring(0, 1)) && !secondLevelChoices.Equals(secondLevelAnswer) && !secondLevelChoices.Contains(secondLevels[randomChoice]))
                {
                    secondLevelChoices.Add(secondLevels[randomChoice]);
                }
                else
                {
                    // Points / Lives / Scoring / Progress bar
                    i--;
                }
            }

            // Level 3 logic
            for (int i = 0; i < 1; i++)
            {
                Random rand = new Random(Guid.NewGuid().GetHashCode());
                int randomChoice = rand.Next(thirdLevels.Count);

                // Cant cont if level 1 answer is wrong
                if (secondLevels[choice].StartsWith(secondLevelAnswer.Substring(0, 2)))
                {
                    thirdLevelAnswer = thirdLevels[choice];
                    thirdLevelChoices.Add(thirdLevelAnswer);
                }
                else
                {
                    i--;
                }
            }

            // Now give 3 wrong options for level 3
            for (int i = 0; i < 3; i++)
            {
                Random rand = new Random(Guid.NewGuid().GetHashCode());
                int randomChoice = rand.Next(8) + 1;

                // Check if the answer is correct -- This is where points will be added
                // CHECK for consistent string output --> Design
                if (!secondLevels[randomChoice].StartsWith(firstLevelAnswer.Substring(0, 2)) && !secondLevelChoices.Equals(secondLevelAnswer) && !secondLevelChoices.Contains(secondLevels[randomChoice]))
                {
                    secondLevelChoices.Add(secondLevels[randomChoice]);
                }
                else
                {
                    // Points / Lives / Scoring / Progress bar
                    i--;
                }
            }

            //Add random third level wrong options
            for (int i = 0; i < 3; i++)
            {
                Random theRand = new Random(Guid.NewGuid().GetHashCode());
                int randomChoice = theRand.Next(8) + 1;
                string wrongChoice = secondLevelAnswer.Substring(0, 2) + randomChoice;

                if (!wrongChoice.Equals(thirdLevelAnswer.Substring(0, 3)) && !thirdLevelChoices.Contains(wrongChoice))
                {
                    thirdLevelChoices.Add(wrongChoice);
                }
                else
                {
                    i--;
                }

            }

            //Change the format of all third level answers to consistent format
            for (int i = 0; i < thirdLevelChoices.Count; i++)
            {
                thirdLevelChoices[i] = thirdLevelChoices[i].Substring(0, 3);
            }

            //Sort the lists numerically
            firstLevelChoices.Sort();
            secondLevelChoices.Sort();
            thirdLevelChoices.Sort();
        }
    }
}
