﻿using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for Achievements.xaml
    /// </summary>
    public partial class Achievements : Window
    {
        public Achievements()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide (); 
            MainWindow mw = new MainWindow(); 
            mw.Show(); 
        }
    }
}
