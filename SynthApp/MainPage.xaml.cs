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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SynthApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private NotePlayer notePlayer;

        public MainPage()
        {
            this.InitializeComponent();
            this.notePlayer = new NotePlayer();
            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Set the input focus to ensure that keyboard events are raised.
            this.Loaded += delegate { this.Focus(FocusState.Programmatic); };
        }

        private void Grid_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            switch (e.Key)
            {
                case VirtualKey.C:
                    notePlayer.playDrumNote("C");
                    break;
                case VirtualKey.D:
                    notePlayer.playDrumNote("D");
                    break;
                case VirtualKey.E:
                    notePlayer.playDrumNote("E");
                    break;
                case VirtualKey.G:
                    notePlayer.playDrumNote("G");
                    break;
                case VirtualKey.A:
                    notePlayer.playDrumNote("A");
                    break;
            }

        }

        private void Grid_KeyUp(object sender, KeyRoutedEventArgs e)
        {

        }
        
    }
}
