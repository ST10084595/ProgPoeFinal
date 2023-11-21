using ProgPoe1.Properties;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace ProgPoe1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // DevMecha 2020
        //https://www.youtube.com/watch?v=D4XEDfDrNrI


        //  Nelson Darwin Pak Tech 2023
        //https://www.youtube.com/watch?v=FkCiI25Zzlw  

        MediaPlayer mp = new MediaPlayer(); 



        public MainWindow()
        {
            InitializeComponent();


            // DevMecha 2020
            //https://www.youtube.com/watch?v=D4XEDfDrNrI


            //  Nelson Darwin Pak Tech 2023
            //https://www.youtube.com/watch?v=FkCiI25Zzlw 

            mp.Open(new Uri(string.Format("{0}\\intro.mp3", AppDomain.CurrentDomain.BaseDirectory)));

        

            mp.MediaEnded += new EventHandler(music_stopped);

            if ((bool)Settings.Default["music"] == true)
            {
                mp.Play();
            } 

            Achievements.MouseLeftButtonDown += Achievements_Click;  
        }

        private void music_stopped(object sender, EventArgs e)
        {
            if ((bool)Settings.Default["music"] == true)
            {
                mp.Position = TimeSpan.Zero;
                mp.Play();
            }
        }



        private void replaceBooks_Click(object sender, RoutedEventArgs e)

        {
            // DevMecha 2020
            //https://www.youtube.com/watch?v=D4XEDfDrNrI


            //  Nelson Darwin Pak Tech 2023
            //https://www.youtube.com/watch?v=FkCiI25Zzlw  


            SoundPlayer player = new SoundPlayer(new Uri(string.Format("{0}\\Sounds\\Pokeball-Capture.mp4.wav", AppDomain.CurrentDomain.BaseDirectory)).ToString()); 
            player.Play();

            

            this.Hide(); 
            ReplacingBooks rb = new ReplacingBooks();
            rb.Show(); 

          
           



        


        }

        private void music_stop(object sender, EventArgs e) 
        {
            if ((bool)Settings.Default["music"] == true)
            {
                mp.Position = TimeSpan.Zero;
                mp.Play();
            } 
        }  



        private void Achievements_Click(object sender, MouseButtonEventArgs e)  
        {


            SoundPlayer player = new SoundPlayer(new Uri(string.Format("{0}\\Sounds\\pokeball-opening-sound-FX.wav", AppDomain.CurrentDomain.BaseDirectory)).ToString());
            player.Play(); 




            this.Hide();
            Achievements ac = new Achievements();
            ac.Show(); 
        }

        private void Achievements_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {   
            //takes the user to the achievements page   
        }

        private void IdentifyAreas_Click(object sender, RoutedEventArgs e)
        {

           // SoundPlayer player = new SoundPlayer(new Uri(string.Format("{0}\\Sounds\\pokeball-opening-sound-FX.wav", AppDomain.CurrentDomain.BaseDirectory)).ToString());
           // player.Play();

           //identifyingAreas ca = new identifyingAreas();
           // this.Hide(); 

           // ca.Show(); 




             
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer player = new SoundPlayer(new Uri(string.Format("{0}\\Sounds\\pokeball-opening-sound-FX.wav", AppDomain.CurrentDomain.BaseDirectory)).ToString());
            player.Play();

            CheckingAreas ca = new CheckingAreas(); 
            this.Hide();

            ca.Show(); 
        }

        private void CallNumbers_Click(object sender, RoutedEventArgs e)
        {

            SoundPlayer player = new SoundPlayer(new Uri(string.Format("{0}\\Sounds\\pokeball-opening-sound-FX.wav", AppDomain.CurrentDomain.BaseDirectory)).ToString());
            player.Play();

            mp.Stop(); 

            part3CallNums cn = new part3CallNums(); 
            
            this.Hide(); 
            cn.Show();

        }
    }
}
