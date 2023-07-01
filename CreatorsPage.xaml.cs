/*
 * CREATORSPAGE.XAML
 * 
 * Mamy definicję wierszy, obrazek z logiem, Stack Panel z text boxamami oraz przycisk powrotu.
 * 
*/

using ColoringAndDressUp.Assets;
using ColoringAndDressUp.GUI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ColoringAndDressUp
{
    public sealed partial class CreatorsPage : Page
    {
        public CreatorsPage()
        {
            this.InitializeComponent();
            SetFullscreen.Set();
        }

        private void bABack_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlaySoundEffect();
            Frame.GoBack();
        }
    }
}
