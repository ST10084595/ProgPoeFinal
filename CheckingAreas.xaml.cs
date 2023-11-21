using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProgPoe1
{
    /// <summary>
    /// Interaction logic for CheckingAreas.xaml
    /// </summary>
    public partial class CheckingAreas : Window
    {
        public CheckingAreas()
        {
            InitializeComponent();
        }


        public static int qCount = 4;
        public static bool callQ = true;
        public static int myScore;
        public static int maxScore;
        Random rnd = new Random();

        IDictionary<string, string> baseQuestions = new Dictionary<string, string>();
        IDictionary<string, string> usedQuestions = new Dictionary<string, string>();

        private void loadDefauts()
        {
           baseQuestions.Clear();
            usedQuestions.Clear();

            baseQuestions.Add("000-099", "General Works");
            baseQuestions.Add("100-199", "Philosophy And Psycology");
            baseQuestions.Add("200-299", "Religion");
            baseQuestions.Add("300-399", "Social Science");
            baseQuestions.Add("400-499", "Language");
            baseQuestions.Add("500-599", "Natural Science And Mathematics");
            baseQuestions.Add("600-699", "Technology");
            baseQuestions.Add("700-799", " The Arts");
            baseQuestions.Add("800-899", "Literature And Rhetoric");
            baseQuestions.Add("900-999", "History, Bigoraphy and Geograaphy");
            
        }

        internal static void FindChildren<T>(List<T> results, DependencyObject startNode)
            where T : DependencyObject
        {

            int count = VisualTreeHelper.GetChildrenCount(startNode);

            for (int i = 0; i < count; i++)
            {
                DependencyObject current = VisualTreeHelper.GetChild(startNode, i);
                if ((current.GetType()).Equals(typeof(T)) ||
                        (current.GetType()).GetTypeInfo().IsSubclassOf(typeof(T)))
                {
                    T asType = (T)current;
                    results.Add(asType);

                }
                FindChildren<T>(results, current);
            }


        }

        public int CalcScore()
        {
            int Score = 0;

            List<ListBoxItem> list = new List<ListBoxItem>();
            FindChildren(list, ListAns);
            for (int i = 0; i < qCount; i++)
            {
                string callNumber;
                string description;

                if (!callQ)
                {
                    callNumber = ListQuestions.Items[i].ToString();
                    description = ListAns.Items[i].ToString();
                }
                else
                {

                    callNumber = ListAns.Items[i].ToString();
                    description = ListQuestions.Items[i].ToString();


                }
                try
                {
  if (usedQuestions[callNumber] == description)
                {
                    list[i].Background = new SolidColorBrush(Colors.Green); 

                    Score++;

                }
                else if (usedQuestions[callNumber] != description) 
                {
                    list[i].Background = new SolidColorBrush(Colors.Red); 
                }
                }
                catch (Exception)
                {
                    MessageBoxResult dialogResult = MessageBox.Show("Please Start A New Game To Check Answers"); 
                    throw; 
                }
              
            }

            //for (int i = 0; i < ListAns.Items.Count; i++)
            //{
            //    list[i].Background = new SolidColorBrush(Colors.PaleVioletRed);

            //}

            return Score;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //subimit btn 
            int Score = CalcScore();
            // submits the answers to be checked 
            // pull method -- setup textblocks  
            // 
            btnUp.IsEnabled = false;
            btnDown.IsEnabled = false;
            //any other btns or features to disable at this point 

            loadDefauts();
            myScore = myScore + Score;

            maxScore = maxScore + qCount;

            if (Score == 4)
            {
                // DevMecha 2020
                //https://www.youtube.com/watch?v=D4XEDfDrNrI


                //  Nelson Darwin Pak Tech 2023
                //https://www.youtube.com/watch?v=FkCiI25Zzlw 

                MessageBoxResult dialogResult = MessageBox.Show("Congratulations You Have Earned");
                SoundPlayer player = new SoundPlayer(new Uri(string.Format("{0}\\Sounds\\Pokemon-Victory-Theme.wav", AppDomain.CurrentDomain.BaseDirectory)).ToString());
                player.Play(); 
                badge b = new badge();
                b.Show(); 

            }
           
            scoreTB.Text = "Score: " + myScore + "/" + maxScore;

           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ////subimit btn 
            //int Score = CalcScore();
            //// submits the answers to be checked 
            //// pull method -- setup textblocks  
            //// 
            //btnUp.IsEnabled = false;
            //btnDown.IsEnabled = false;
            ////any other btns or features to disable at this point 

            //loadDefauts();
            //myScore = myScore + Score;

            //maxScore = maxScore + qCount;

            //if (Score == 4)
            //{
            //    //popup --mbox
            //}
            //else
            //{
            //    //not perfect 
            //}

            //scoreTB.Text = "Score: " + myScore + "/" + maxScore;

        }
        private void getKVP(out string call, out string desc)
        {

            KeyValuePair<string, string> kvp;

            int index = rnd.Next(baseQuestions.Count());
            kvp = baseQuestions.ElementAt(index);
            usedQuestions.Add(kvp);
            baseQuestions.Remove(kvp);
            call = kvp.Key;
            desc = kvp.Value;


        }

        public void repopulateLists()
        {

            ListQuestions.Items.Clear();
            ListAns.Items.Clear();
            //Alternate between call numbs and desc 
            if (callQ)
            {
                for (int i = 0; i < 4; i++)
                {
                    getKVP(out string callNo, out string desc);
                    ListQuestions.Items.Add(callNo);
                    ListAns.Items.Add(desc);
                }

                for (int i = 0; i < 3; i++)
                {
                    getKVP(out _, out string desc);
                    ListAns.Items.Add(desc);
                }

                //prep Alt 
                callQ = false;

            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    getKVP(out string callNo, out string desc);
                    ListQuestions.Items.Add(desc);
                    ListAns.Items.Add(callNo);
                }

                //generate 3 more callNos 
                for (int i = 0; i < 3; i++)
                {
                    getKVP(out string callNo, out _);

                    ListAns.Items.Add(callNo);
                }
                //Prep Alt 
                callQ = true;
            }
            //TODO 
            LisstControls.randomiseList(ListQuestions);
            LisstControls.randomiseList(ListAns);


        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // new game button 

            if (Submit.IsEnabled == true) 

            {
                MessageBoxResult dialogResult = MessageBox.Show("Are you sure you want to start " +
                    "a new game?" + "\nThis will reset your score", "New Game", MessageBoxButton.YesNo);

                if (dialogResult == MessageBoxResult.Yes)
                {
                    //myScore = 0;
                    //maxScore = 0;
                    scoreTB.Text = "Match Columns";

                }
                else
                {
                    return;
                }

            }
            loadDefauts();
            repopulateLists();
            btnUp.IsEnabled = true;
            btnDown.IsEnabled = true;



        }

        private void btnDown_Click(object sender, RoutedEventArgs e)
        {
            LisstControls.SwapIndexes(1, ListAns);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnUp_Click(object sender, RoutedEventArgs e)
        {
            // up btn 
           
        }

        private void btnDown_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void ListQuestions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void up_Click(object sender, RoutedEventArgs e)
        {
            LisstControls.SwapIndexes(-1, ListAns);
        }

        private void down_Click(object sender, RoutedEventArgs e)
        {
            LisstControls.SwapIndexes(1, ListAns); 
        }
    }
}
