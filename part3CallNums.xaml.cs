using ProgPoe1.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
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
using System.Windows.Threading;

namespace ProgPoe1
{
    /// <summary>
    /// Interaction logic for part3CallNums.xaml
    /// </summary>
    public partial class part3CallNums : Window
    {


        //global variables 

        MediaPlayer mp = new MediaPlayer(); 


        public part3CallNums()
        {
            InitializeComponent();

            mp.Open(new Uri(string.Format("{0}\\intro.mp3", AppDomain.CurrentDomain.BaseDirectory)));

            mp.MediaEnded += new EventHandler(music_stopped);

            if ((bool)Settings.Default["music"] == true)
            {
                mp.Play();
            }

            firstLevelList.Visibility = Visibility.Hidden;

            firstNextBtn.Visibility = Visibility.Hidden; 

            secondLevelList.IsEnabled = true;

            secondLevelList.Visibility = Visibility.Hidden;

            secondNextBtn.Visibility = Visibility.Hidden;

            thirdLevelList.Visibility = Visibility.Hidden;

            thirdLevelList.IsEnabled = false;
            thirdNextBtn.IsEnabled = false;
            thirdNextBtn.Visibility = Visibility.Hidden;

            // submitBtn.Visibility = Visibility.Hidden;

            congratulations.Visibility = Visibility.Hidden; 
            tryAgain.Visibility = Visibility.Hidden;


        }
        private void music_stopped(object sender, EventArgs e)
        {
            if ((bool)Settings.Default["music"] == true)
            {
                mp.Position = TimeSpan.Zero;
                mp.Play();
            }
        } 

        private void firstNextBtn_Click(object sender, RoutedEventArgs e)
        {
            if (firstLevelList.SelectedItem == null)

            {

                MessageBox.Show("Ahh a trickster, You must choose if you want Glory.");

            }

            else

            {

                //Check user answer

                if (firstLevelList.SelectedItem.Equals(CallNumbers.firstLevelAnswer)) 

                {

                    //Give Random positive feeback to user

                    Random rand = new Random(Guid.NewGuid().GetHashCode());

                    var corResponses = new List<string> { "Congratulations!!", "Can Almost Taste Victory!", "Great Job!!" };

                    int choice = rand.Next(corResponses.Count);

                    MessageBox.Show(corResponses[choice]);

                    //Show next phase of game

                    secondLevelList.IsEnabled = true;

                    secondLevelList.Visibility = Visibility.Visible; 

                    secondNextBtn.Visibility = Visibility.Visible;

                    thirdLevelList.Visibility = Visibility.Hidden;

                    thirdLevelList.IsEnabled = false;
                    thirdNextBtn.IsEnabled = false;
                    thirdNextBtn.Visibility = Visibility.Hidden; 

                   // submitBtn.Visibility = Visibility.Hidden;

                    congratulations.Visibility = Visibility.Visible;
                    tryAgain.Visibility = Visibility.Hidden;

                    mp.Stop();

                    SoundPlayer player = new SoundPlayer(new Uri(string.Format("{0}\\Sounds\\pikachu-pika-pika-sound-FX.wav", AppDomain.CurrentDomain.BaseDirectory)).ToString());
                    player.Play();

                    mp.MediaEnded += new EventHandler(music_stopped); 

                }

                else

                {

                    //Random Negative feedback for wrong answer

                    Random rand = new Random(Guid.NewGuid().GetHashCode());

                    var wroResponses = new List<string> { "Better Luck Next Time!", "Keep Going, You're So Close!", "Don't Give Up" };

                    int choice = rand.Next(wroResponses.Count);

                    MessageBox.Show(wroResponses[choice]);


                    congratulations.Visibility = Visibility.Hidden;
                    tryAgain.Visibility = Visibility.Visible;  
                    //Game starts again

                    startBtn.Visibility = Visibility.Visible;

                    startBtn.FontSize = 10;

                    startBtn.Content = "Try Again!";

                    mp.Stop();

                    SoundPlayer player = new SoundPlayer(new Uri(string.Format("{0}\\Sounds\\Pikachu-Crying-_So-Sad_.wav", AppDomain.CurrentDomain.BaseDirectory)).ToString());
                    player.Play();

                    mp.MediaEnded += new EventHandler(music_stopped);

                }
            }
        } 

        private void secondNextBtn_Click(object sender, RoutedEventArgs e)
        {
            //Error message if user selects nothing

            if (secondLevelList.SelectedItem == null)

            {

                MessageBox.Show("Ahh a trickster, You must choose if you want Glory.");

            }

            else

            {

                //Check user answer

                if (secondLevelList.SelectedItem.Equals(CallNumbers.secondLevelAnswer))

                {

                    //Give Random positive feeback to user

                    Random rand = new Random(Guid.NewGuid().GetHashCode());

                    var corResponses = new List<string> { "Congratulations!!", "Can Almost Taste Victory!", "Great Job!!" }; 

                    int choice = rand.Next(corResponses.Count);

                    MessageBox.Show(corResponses[choice]);

                    //Show next phase of game

                    secondLevelList.IsEnabled = true;

                    secondNextBtn.Visibility = Visibility.Visible;

                    thirdLevelList.Visibility = Visibility.Visible;

                    thirdLevelList.IsEnabled = true;

                    //submitBtn.Visibility = Visibility.Visible;
                    thirdNextBtn.Visibility = Visibility.Visible;    
                    thirdNextBtn.IsEnabled = true;

                    congratulations.Visibility = Visibility.Visible;
                    tryAgain.Visibility = Visibility.Hidden;

                    mp.Stop();

                    SoundPlayer player = new SoundPlayer(new Uri(string.Format("{0}\\Sounds\\pikachu-pika-pika-sound-FX.wav", AppDomain.CurrentDomain.BaseDirectory)).ToString());
                    player.Play();

                    mp.MediaEnded += new EventHandler(music_stopped);
                }

                else

                {

                    //Random Negative feedback for wrong answer

                    Random rand = new Random(Guid.NewGuid().GetHashCode());

                    var wroResponses = new List<string> { "Better Luck Next Time!", "Keep Going, You're So Close!", "Don't Give Up" };

                    int choice = rand.Next(wroResponses.Count);

                    MessageBox.Show(wroResponses[choice]);


                    congratulations.Visibility = Visibility.Hidden;
                    tryAgain.Visibility = Visibility.Visible;

                    //Game starts again

                    startBtn.Visibility = Visibility.Visible;

                    startBtn.FontSize = 10;

                    startBtn.Content = "Try Again!";

                    mp.Stop();

                    SoundPlayer player = new SoundPlayer(new Uri(string.Format("{0}\\Sounds\\Pikachu-Crying-_So-Sad_.wav", AppDomain.CurrentDomain.BaseDirectory)).ToString());
                    player.Play();

                    mp.MediaEnded += new EventHandler(music_stopped);


                }

            }
        }

        private void thirdNextBtn_Click(object sender, RoutedEventArgs e)
        {
            if (thirdLevelList.SelectedItem == null)

            {

                MessageBox.Show("Ahh a trickster, You must choose if you want Glory.");

            }

            else

            {

                //Check user answer

                if (thirdLevelList.SelectedItem.Equals(CallNumbers.thirdLevelAnswer))

                {

                    //Give Random positive feeback to user

                    Random rand = new Random(Guid.NewGuid().GetHashCode());

                    var corResponses = new List<string> { "Congratulations!!", "Can Almost Taste Victory!", "Great Job!!" };

                    int choice = rand.Next(corResponses.Count);

                    MessageBox.Show(corResponses[choice]);

                    //Show next phase of game

                    secondLevelList.IsEnabled = true;

                    secondLevelList.Visibility = Visibility.Visible;

                    secondNextBtn.Visibility = Visibility.Visible;

                    thirdLevelList.Visibility = Visibility.Hidden;

                    thirdLevelList.IsEnabled = false;
                    thirdNextBtn.IsEnabled = false;
                    thirdNextBtn.Visibility = Visibility.Visible;

                    //submitBtn.Visibility = Visibility.Visible;

                    congratulations.Visibility = Visibility.Visible;
                    tryAgain.Visibility = Visibility.Hidden;

                  


                    PokemonMasterWinner pmw = new PokemonMasterWinner(); 
                    pmw.Show();

                    mp.Stop();


                    SoundPlayer player = new SoundPlayer(new Uri(string.Format("{0}\\Sounds\\Pokémon-Theme-Song.wav", AppDomain.CurrentDomain.BaseDirectory)).ToString());
                    player.Play();



                    mp.MediaEnded += new EventHandler(music_stopped);


                }

                else

                {

                    //Random Negative feedback for wrong answer

                    Random rand = new Random(Guid.NewGuid().GetHashCode());

                    var wroResponses = new List<string> { "Better Luck Next Time!", "Keep Going, You're So Close!", "Don't Give Up" };

                    int choice = rand.Next(wroResponses.Count);

                    MessageBox.Show(wroResponses[choice]);


                    congratulations.Visibility = Visibility.Hidden;
                    tryAgain.Visibility = Visibility.Visible;

                    //Game starts again


                    mp.Stop();

                    SoundPlayer player = new SoundPlayer(new Uri(string.Format("{0}\\Sounds\\Pikachu-Crying-_So-Sad_.wav", AppDomain.CurrentDomain.BaseDirectory)).ToString());
                    player.Play();

                    mp.MediaEnded += new EventHandler(music_stopped);


                    startBtn.Visibility = Visibility.Visible;

                    startBtn.FontSize = 10;

                    startBtn.Content = "Restart!"; 

                }
            } 
        }
        private void startBtn_Click(object sender, RoutedEventArgs e)
        {
            startBtn.Content = "Start";
            startBtn.Visibility = Visibility.Hidden;

            firstLevelList.IsEnabled = true;
            firstNextBtn.Visibility = Visibility.Visible;

            firstLevelList.Visibility = Visibility.Visible; 


            secondLevelList.IsEnabled = false;
            secondNextBtn.Visibility = Visibility.Hidden;

            thirdLevelList.IsEnabled = false;
            thirdNextBtn.Visibility = Visibility.Hidden;


            thirdLevelList.Visibility = Visibility.Hidden;


            secondLevelList.Visibility = Visibility.Hidden;
            // Load call nummbers 

            congratulations.Visibility = Visibility.Hidden;
            tryAgain.Visibility = Visibility.Hidden; 

            CallNumbers.LoadCallNumbers();

            mp.Open(new Uri(string.Format("{0}\\intro.mp3", AppDomain.CurrentDomain.BaseDirectory)));

            mp.MediaEnded += new EventHandler(music_stopped);

            if ((bool)Settings.Default["music"] == true)
            {
                mp.Play();
            } 


            //Prepare lists to add quiz options to ui for the user to select 

            thirdLevelList.Items.Clear();
            firstLevelList.Items.Clear();
            secondLevelList.Items.Clear();

            foreach (string i in CallNumbers.firstLevelChoices)
            {

                firstLevelList.Items.Add(i);


            }
            foreach (string i in CallNumbers.secondLevelChoices)
            {

                secondLevelList.Items.Add(i);


            }
            foreach (string i in CallNumbers.thirdLevelChoices)
            {

                thirdLevelList.Items.Add(i);


            }
        }

        private void return_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            this.Close();
            mw.Show(); 
        }
    }
}
