using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using BoiteAClash.Resources;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;

namespace BoiteAClash
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructeur
        public MainPage()
        {

            InitializeComponent();
            collectionClash.DataContext = new Listes();

        }

        // Charger les données pour les éléments ViewModel
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }

        private void Element_OnTap(object sender, GestureEventArgs e)
        {
            mediaAudio.Stop();
            var data = (sender as Grid).DataContext as Clash;
            if (data != null )
            {
                mediaAudio.Source = new Uri(data.PathSound,UriKind.Relative);
                mediaAudio.MediaOpened+=(o, args) => 
                mediaAudio.Play();
            }
        }

        private void MediaAudio_OnMediaEnded(object sender, RoutedEventArgs e)
        {
            collectionClash.SelectedItem = null;    
        }
    }
}