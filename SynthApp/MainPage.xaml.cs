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
        MyoPlayer MyoPlayer1;
        MyoPlayer MyoPlayer2;
        MyoPlayer MyoPlayer3;

        public MainPage()
        {
            this.InitializeComponent();
            MyoPlayer1 = new MyoPlayer(mediaElement1, VirtualKey.Q, VirtualKey.W, VirtualKey.E, VirtualKey.R, VirtualKey.T);
            MyoPlayer2 = new MyoPlayer(mediaElement2, VirtualKey.A, VirtualKey.S, VirtualKey.D, VirtualKey.F, VirtualKey.G);
            MyoPlayer3 = new MyoPlayer(mediaElement3, VirtualKey.Z, VirtualKey.X, VirtualKey.C, VirtualKey.V, VirtualKey.B);

            // XXX: THIS IS TEMPORARY, PLEASE DELETE
            MyoPlayer1.CurrentSoundBank = new DrumKitSoundBank();
            MyoPlayer2.CurrentSoundBank = new GuitarSoundBank();
            MyoPlayer3.CurrentSoundBank = new PianoSoundBank();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Set the input focus to ensure that keyboard events are raised.
            this.Loaded += delegate { this.Focus(FocusState.Programmatic); };
        }

        private async void Grid_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (MyoPlayer1.AcceptsKey(e.Key))
            {
                await MyoPlayer1.Play(e.Key);
                MyoPlayer1Canvas.Background = new SolidColorBrush(Colors.Blue);
            }
            else if (MyoPlayer2.AcceptsKey(e.Key))
            {
                await MyoPlayer2.Play(e.Key);
                MyoPlayer2Canvas.Background = new SolidColorBrush(Colors.Blue);
            }
            else if (MyoPlayer3.AcceptsKey(e.Key))
            {
                await MyoPlayer3.Play(e.Key);
                MyoPlayer3Canvas.Background = new SolidColorBrush(Colors.Blue);
            }
            else
            {
                // ignore keystroke
            }

        }

        private void Grid_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            MyoPlayer1Canvas.Background = new SolidColorBrush(Colors.White);
            MyoPlayer2Canvas.Background = new SolidColorBrush(Colors.White);
            MyoPlayer3Canvas.Background = new SolidColorBrush(Colors.White);
        }
        
    }
}
