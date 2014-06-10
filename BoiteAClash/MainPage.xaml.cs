using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Windows.Phone.Speech.VoiceCommands;
using Microsoft.Phone.Controls;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;

namespace BoiteAClash
{
    public partial class MainPage : PhoneApplicationPage
    {
        private Listes Listes { get; set; }
        // Constructeur
        public MainPage()
        {

            InitializeComponent();
            Listes = new Listes();
            collectionClash.DataContext = Listes;

        }

        protected override void OnNavigatedTo(NavigationEventArgs args)
        {
            if (args.NavigationMode == NavigationMode.New)
            {
                string voiceCommandName;

                if (NavigationContext.QueryString.TryGetValue("voiceCommandName", out voiceCommandName))
                {
                    HandleVoiceCommand(voiceCommandName);
                }
                else
                {
                    // If we just freshly launched this app without a Voice Command, asynchronously try to install the 
                    // Voice Commands.
                    // If the commands are already installed, no action will be taken--there's no need to check.
                    Task.Run(() => InstallVoiceCommands());

                    // Just for fun, we'll also animate the home page buttons
                }
            }
        }

        private async void InstallVoiceCommands()
        {
            const string wp81vcdPath = "ms-appx:///VoiceCommandDefinition1.xml";

            try
            {

                Uri vcdUri = new Uri(wp81vcdPath);

                await VoiceCommandService.InstallCommandSetsFromFileAsync(vcdUri);
            }
            catch (Exception vcdEx)
            {
                Dispatcher.BeginInvoke(() => MessageBox.Show(String.Format("error {0} {1}", vcdEx.HResult, vcdEx.Message)));
            }
        }

        private void HandleVoiceCommand(string voiceCommandName)
        {
            // Voice Commands can be typed into Cortana; when this happens, "voiceCommandMode" is populated with the
            // "textInput" value. In these cases, we'll want to behave a little differently by not speaking back.
            bool typedVoiceCommand = (NavigationContext.QueryString.ContainsKey("commandMode") 
                && (NavigationContext.QueryString["commandMode"] == "text"));

            string phraseTopicContents = null;
            bool doSearch = false;

            switch (voiceCommandName)
            {
                case "Play":
                    if (NavigationContext.QueryString.TryGetValue("cmd", out phraseTopicContents)
                        && !String.IsNullOrEmpty(phraseTopicContents))
                    {
                        if(phraseTopicContents.Contains("popopo"))
                            Play(Listes.Clashes.First(c => c.Txt.Contains("popo")));
                        if (phraseTopicContents.Contains("bagarre"))
                            Play(Listes.Clashes.First(c => c.Txt.Contains("bagarre")));
                        if (phraseTopicContents.Contains("mot"))
                            Play(Listes.Clashes.First(c => c.Txt.Contains("mot")));
                        if (phraseTopicContents.Contains("poua"))
                            Play(Listes.Clashes.First(c => c.PathImage.Contains("badjoke")));
                        if (phraseTopicContents.Contains("cheval"))
                            Play(Listes.Clashes.First(c => c.Txt.Contains("horse")));
                        if (phraseTopicContents.Contains("mere"))
                            Play(Listes.Clashes.First(c => c.Txt.Contains("mère")));
                    }
                    break;
            }

        }



        private void Element_OnTap(object sender, GestureEventArgs e)
        {
            mediaAudio.Stop();
            var data = (sender as Grid).DataContext as Clash;
            Play(data);
        }

        private void Play(Clash data)
        {
            if (data != null)
            {
                mediaAudio.Source = new Uri(data.PathSound, UriKind.Relative);
                mediaAudio.MediaOpened += (o, args) =>
                    mediaAudio.Play();
            }
        }

        private void MediaAudio_OnMediaEnded(object sender, RoutedEventArgs e)
        {
            collectionClash.SelectedItem = null;
        }
    }
}