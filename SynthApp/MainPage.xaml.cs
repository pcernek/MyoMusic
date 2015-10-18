using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.System;
using Windows.Media.Playback;
using Windows.Storage;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SynthApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        StorageFolder storageFolder;

        public MainPage()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Set the input focus to ensure that keyboard events are raised.
            this.Loaded += delegate { this.Focus(FocusState.Programmatic); };
            storageFolder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
        }

        private async void Grid_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            string audioFileName = "";
            MediaElement player;
            switch (e.Key)
            {
                case VirtualKey.Q:
                    player = drumPlayer;
                    audioFileName = "drum-1.wav";
                    DrumCanvas.Background = new SolidColorBrush(Colors.Blue);
                    break;
                case VirtualKey.W:
                    player = drumPlayer;
                    audioFileName = "drum-2.wav";
                    DrumCanvas.Background = new SolidColorBrush(Colors.Blue);
                    break;
                case VirtualKey.E:
                    player = drumPlayer;
                    audioFileName = "drum-3.wav";
                    DrumCanvas.Background = new SolidColorBrush(Colors.Blue);
                    break;
                case VirtualKey.R:
                    player = drumPlayer;
                    audioFileName = "drum-4.wav";
                    DrumCanvas.Background = new SolidColorBrush(Colors.Blue);
                    break;
                case VirtualKey.T:
                    player = drumPlayer;
                    audioFileName = "drum-5.wav";
                    DrumCanvas.Background = new SolidColorBrush(Colors.Blue);
                    break;
                case VirtualKey.A:
                    player = guitarPlayer;
                    audioFileName = "guitar-E.wav";
                    DrumCanvas.Background = new SolidColorBrush(Colors.Blue);
                    break;
                case VirtualKey.S:
                    player = guitarPlayer;
                    audioFileName = "guitar-G.wav";
                    DrumCanvas.Background = new SolidColorBrush(Colors.Blue);
                    break;
                case VirtualKey.D:
                    player = guitarPlayer;
                    audioFileName = "guitar-A.wav";
                    DrumCanvas.Background = new SolidColorBrush(Colors.Blue);
                    break;
                case VirtualKey.F:
                    player = guitarPlayer;
                    audioFileName = "guitar-C.wav";
                    DrumCanvas.Background = new SolidColorBrush(Colors.Blue);
                    break;
                case VirtualKey.G:
                    player = guitarPlayer;
                    audioFileName = "guitar-D.wav";
                    DrumCanvas.Background = new SolidColorBrush(Colors.Blue);
                    break;
                case VirtualKey.Z:
                    player = pianoPlayer;
                    audioFileName = "piano-E.wav";
                    DrumCanvas.Background = new SolidColorBrush(Colors.Blue);
                    break;
                case VirtualKey.X:
                    player = pianoPlayer;
                    audioFileName = "piano-G.wav";
                    DrumCanvas.Background = new SolidColorBrush(Colors.Blue);
                    break;
                case VirtualKey.C:
                    player = pianoPlayer;
                    audioFileName = "piano-A.wav";
                    DrumCanvas.Background = new SolidColorBrush(Colors.Blue);
                    break;
                case VirtualKey.V:
                    player = pianoPlayer;
                    audioFileName = "piano-C.wav";
                    DrumCanvas.Background = new SolidColorBrush(Colors.Blue);
                    break;
                case VirtualKey.B:
                    player = pianoPlayer;
                    audioFileName = "piano-D.wav";
                    DrumCanvas.Background = new SolidColorBrush(Colors.Blue);
                    break;
                default:
                    return;
            }

            StorageFile storageFile = await storageFolder.GetFileAsync(audioFileName);
            var stream = await storageFile.OpenAsync(FileAccessMode.Read);
            player.SetSource(stream, storageFile.ContentType);
            player.Play();

        }

        private void Grid_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            DrumCanvas.Background = new SolidColorBrush(Colors.White);
        }
        
    }
}
