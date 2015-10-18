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
            switch (e.Key)
            {
                case VirtualKey.A:
                    audioFileName = "drum-1.wav";
                    DrumCanvas.Background = new SolidColorBrush(Colors.Blue);
                    break;
                case VirtualKey.W:
                    audioFileName = "drum-2.wav";
                    DrumCanvas.Background = new SolidColorBrush(Colors.Blue);
                    break;
                case VirtualKey.D:
                    audioFileName = "drum-3.wav";
                    DrumCanvas.Background = new SolidColorBrush(Colors.Blue);
                    break;
                case VirtualKey.S:
                    audioFileName = "drum-4.wav";
                    DrumCanvas.Background = new SolidColorBrush(Colors.Blue);
                    break;
                case VirtualKey.Q:
                    audioFileName = "drum-5.wav";
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
