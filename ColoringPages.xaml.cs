/*
 * COLORINGPAGES.XAML
 * 
 * Mamy definicję wierszy, obrazek z logiem, Stack Panel z obrazkami oraz przycisk powrotu.
 * 
*/

using ColoringAndDressUp.Assets;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ColoringAndDressUp
{
    public sealed partial class ColoringPages : Page
    {
        //Pomocznicze zmienne - będą używane przy wyborze kolorowanki.

        public String whichColoring;
        public Uri uri;

        public ColoringPages()
        {
            this.InitializeComponent();
        }

        private void bCPBack_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlaySoundEffect();
            Frame.GoBack();
        }

        //Funkcja pomocnicza do wybrania odpowiedniej kolorowanki. Do zmiennej whichColoring przypisywany jest numer
        //odpowiedniej kolorowanki, tworzone jest uri oraz następuje nawigacja do strony kolorowania z parametrem uri.

        void pickColoring(string coloring)
        {
            Sound.PlaySoundEffect();
            whichColoring = coloring;
            uri = new Uri("ms-appx:///Assets/Coloring/ColoringPages/" + coloring + ".png");
            this.Frame.Navigate(typeof(ColoringPage1), uri);
        }

        private void bColoring1_Click(object sender, RoutedEventArgs e)
        {
            pickColoring("Coloring1");
        }

        private void bColoring2_Click(object sender, RoutedEventArgs e)
        {
            pickColoring("Coloring2");
        }

        private void bColoring3_Click(object sender, RoutedEventArgs e)
        {
            pickColoring("Coloring3");
        }

        private void bColoring4_Click(object sender, RoutedEventArgs e)
        {
            pickColoring("Coloring4");
        }

        private void bColoring5_Click(object sender, RoutedEventArgs e)
        {
            pickColoring("Coloring5");
        }

        private void bColoring6_Click(object sender, RoutedEventArgs e)
        {
            pickColoring("Coloring6");
        }
    }
}
