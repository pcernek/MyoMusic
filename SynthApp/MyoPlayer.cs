using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SynthApp
{
    

    class MyoPlayer 
    {

        private MediaElement mediaElement;
        private StorageFolder storageFolder;
        private Dictionary<VirtualKey, int> keyMap = new Dictionary<VirtualKey, int>();
        bool hasBeenInitialized;
        bool hasSoundBank;

        private ISoundBank soundBank;
        public ISoundBank CurrentSoundBank
        {
            get
            {
                return soundBank;
            }
            set
            {
                soundBank = value;
                hasSoundBank = true;
            }
        }

        public MyoPlayer(MediaElement me,
                         VirtualKey key1,
                         VirtualKey key2,
                         VirtualKey key3,
                         VirtualKey key4,
                         VirtualKey key5)
        {
            this.mediaElement = me;
            keyMap.Add(key1, 1);
            keyMap.Add(key2, 2);
            keyMap.Add(key3, 3);
            keyMap.Add(key4, 4);
            keyMap.Add(key5, 5);
        }

        public async Task Play(VirtualKey keyStroke)
        {
            try
            {
                checkStateIsValid();
                string audioFileName = resolveKeyStroke(keyStroke);
                await playAudioFile(audioFileName);
            }
            catch (Exception e) when (e is ArgumentException || e is InvalidOperationException)
            {
                
            }

        }

        public bool AcceptsKey(VirtualKey keyStroke)
        {
            return keyMap.ContainsKey(keyStroke);
        }

        private async Task playAudioFile(string audioFileName)
        {
            StorageFile storageFile = await storageFolder.GetFileAsync(audioFileName);
            var stream = await storageFile.OpenAsync(FileAccessMode.Read);
            mediaElement.SetSource(stream, storageFile.ContentType);
            mediaElement.Play();
        }

        private async void checkStateIsValid()
        {
            await checkAssetStorageLocationInitialized();
            checkHasSoundBank();
        }

        private void checkHasSoundBank()
        {
            if (!hasSoundBank)
            {
                throw new InvalidOperationException("Must first assign an ISoundBank to MyoPlayer.");
            }
        }

        private async Task checkAssetStorageLocationInitialized()
        {
            if (!hasBeenInitialized)
            {
                storageFolder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
                hasBeenInitialized = true;
            }
        }

        private string resolveKeyStroke(VirtualKey keyStroke)
        {
            switch (keyMap[keyStroke])
            {
                case 1:
                    return this.soundBank.GetSound1();
                case 2:
                    return this.soundBank.GetSound2();                    
                case 3:
                    return this.soundBank.GetSound3();                    
                case 4:
                    return this.soundBank.GetSound4();
                case 5:
                    return this.soundBank.GetSound5();
            }
            throw new ArgumentException("Key " + keyStroke + " is not in the domain of this MyoPlayer.");
        }
        
        
    }
}
