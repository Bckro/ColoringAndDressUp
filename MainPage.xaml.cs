/*
 * MAINPAGE.XAML
 * 
 * Przy page atrybut NavigationCacheMode="Enabled" służy do zapisywania pamięci cache strony.
 * Dzięki temu można zapisywać np. stan przycisku włączania/wyłączania muzyki podczas nawigacji do innych stron.
 * Dalej mamy definicję wierszy, obrazek z logiem, Stack Panel z przyciskami nawigującymi do innych stron oraz
 * Stack Panel z przyciskiem włączania/wyłączania muzyki oraz combo box zmiany języka.
*/

/*
 * PLIK APP.XAML
 * 
 * Tam znajduje się customowy styl przycisków.
 */

/*
 * !!! FOLDERY STRINGS ORAZ MULTILINGUALRESOUCES !!!
 * 
 * W Strings są podfoldery z dostępnymi językami, a w nich są pliki Resources.resw. Znajdują się w nich linijki
 * do przetłumaczenia w formacie tabelek, np.
 * 
 *          NAME              |      VALUE
 *      Back.Content          |     Return (en-US)
 *      BrushSize.Text        |     Brush size
 *      
 * W każdym tkolumna name jest taka sama, różni się tylko values, odpowiednio przetłumaczone. W name wymienione są
 * kolejne Uid elementów (Text Boxów, Buttonów itd.).
 * 
 * W folderze MultilingualResources są pliki pomocnicze rozszerzenia Multilingual App Toolkit.
 * 
 * Jak tłumaczenia były robione?
 * 
 * 1. Utworzono folder Strings, podfloder en-US, a w nim plik Resources.resw.
 * 2. Nadano elementom, które chciano przetłumaczyć uid.
 * 3. Uid zostały zapisane w kolumnie NAME, a w VALUES odpowiednia nazwa angielska.
 * 4. Z menu wybrano Tools -> Multilingual App Toolkit -> Enable Selection.
 * 5. Prawym przyciskiem kliknięto na ikonie projektu -> Multilingual App Toolkit -> Add translation languages.
 * 6. Wybrano języki pl-PL, ja-JP, de-DE.
 * 7. Automatycznie wygenerowano foldery w strings oraz folder w MultilingualResources.
 * 8. Prawym przyciskiem kliknięto na każdy z plików xlf -> Multilingual App Toolkit -> Generate machine translations.
 * 9. Uruchomiono aplikację.
 * 10. Edytowano każdy z plików Resource.resw, aby poprawić ewentualne błędy lub braki tłumaczenia.
 */

using ColoringAndDressUp.Assets;
using ColoringAndDressUp.GUI;
using System;
using System.Collections.Generic;
using Windows.ApplicationModel.Resources.Core;
using Windows.Globalization;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace ColoringAndDressUp
{
    public sealed partial class MainPage : Page
    {
        //Tutaj pobierany jest obecny język aplikacji w formacie string.

        string current = ApplicationLanguages.PrimaryLanguageOverride.ToString();

        public MainPage()
        {
            this.InitializeComponent();

            //Tutaj sprawdzamy, czy muzyka jest włączona czy wyłączona za pomocą zmiennej pomoczniczej onOff w klasie Sound.
            //Jeśli ten tekst jest równy "on", to muzyka gra. Jeśli "off", to muzyka jest wyłączana.

            if (Sound.onOff == "on")
            {
                Sound.PlayBackgroundMusic();
                musicStateIcon.Source = new BitmapImage(new Uri("ms-appx:///Assets/Sound/Icons/sound_on.png"));
            }
            else
            {
                Sound.StopBackgroundMusic();
                musicStateIcon.Source = new BitmapImage(new Uri("ms-appx:///Assets/Sound/Icons/sound_off.png"));
            }

            //Ustawiamy wyświetlanie w pełnym ekranie.            
            SetFullscreen.Set();

            checkDefaultLanguage();
        }

        public void checkDefaultLanguage()
        {
            //Funkcja pomocnicza służąca do ustawienia na combo boxie obecnego języka aplikacji.
            //Tworzona jest pomocnicza lista z językami, następnie jest ona przeszukiwana w pętli,
            //a gdy obecnie wybrany element z listy jest równy obecnemu językowi, obecnie wybrany
            //index na combo boxie jest zmieniany. Jeśli natomiast język aplikaji jest inny, niż
            //języki z listy, ustawiany jest domyślnie język angielski.

            List<string> list = new List<string>
            {
                "en",
                "pl",
                "de",
                "ja"
            };

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == current)
                {
                    languages.SelectedIndex = i;
                }
            }

            if (languages.SelectedIndex == -1)
            {
                languages.SelectedIndex = 0;
            }
        }

        private void bColoring_Click(object sender, RoutedEventArgs e)
        {
            //Po kliknięciu w przycisk jest grany odgłos, następnie następuje nawigacja do strony ColoringPages.

            Sound.PlaySoundEffect();
            this.Frame.Navigate(typeof(ColoringPages));
        }

        private void bDressup_Click(object sender, RoutedEventArgs e)
        {
            //Po kliknięciu w przycisk jest grany odgłos, następnie następuje nawigacja do strony DressUp.

            Sound.PlaySoundEffect();
            this.Frame.Navigate(typeof(DressUp));
        }

        private void bAuthors_Click(object sender, RoutedEventArgs e)
        {
            //Po kliknięciu w przycisk jest grany odgłos, następnie następuje nawigacja do strony CreatorsPage.

            Sound.PlaySoundEffect();
            this.Frame.Navigate(typeof(CreatorsPage));
        }

        private void bExit_Click(object sender, RoutedEventArgs e)
        {
            //Po kliknięciu w przycisk wychodzi się z aplikacji.

            Sound.PlaySoundEffect();
            Application.Current.Exit();
        }

        private void musicState_Click(object sender, RoutedEventArgs e)
        {

            //Tutaj przy kliknięciu w przycisk sprawdzany jest status muzyki za pomocą zmiennej pomocniczej onOff
            //w klasie Sound. Jeśli zmienna równa "on", to muzyka jest zatrzymywana, zmieniana jest ikona
            //Buttona oraz tekst pomocniczy w TextBoxie. Jeśli nie, to muzyka jest rozpoczynana,
            //zmieniana jest ikona Buttona oraz tekst pomocniczy w TextBoxie.

            if (Sound.onOff == "on")
            {
                Sound.StopBackgroundMusic();
                musicStateIcon.Source = new BitmapImage(new Uri("ms-appx:///Assets/Sound/Icons/sound_off.png"));
                Sound.onOff = "off";
            }
            else
            {
                Sound.PlayBackgroundMusic();
                musicStateIcon.Source = new BitmapImage(new Uri("ms-appx:///Assets/Sound/Icons/sound_on.png"));
                Sound.onOff = "on";
            }
        }

        private void languages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Gdy zmieniony jest wybór na combo boxie, następuje sprawdzanie obecnie wybranego indeksu.
            //0 - angielski, 1 - polski, 2 - niemiecki, 3 - japoński            

            if (languages.SelectedIndex == 0)
            {
                refresh("en");
            }
            if (languages.SelectedIndex == 1)
            {
                refresh("pl");
            }
            if (languages.SelectedIndex == 2)
            {
                refresh("de");
            }
            if (languages.SelectedIndex == 3)
            {
                refresh("ja");
            }
        }

        //Jeśli obecny język jest różny od wybranego, język aplikacji jest zmieniany. Pobierana jest bieżąca zawartość
        //okna aplikacji i przypisywana jest do zmiennej typu Frame. Właściwość CacheSize określa liczbę stron,
        //które Frame może przechowywać w pamięci w celu buforowania nawigacji. Ustawienie jej na 0 oznacza wyłączenie
        //buforowania, co skutkuje usuwaniem stron z pamięci po ich opuszczeniu. Wywoływana jest metoda Reset,
        //która przywraca domyślne wartości dla kontekstu zasobów bieżącego widoku (okna). Kolejne wywołanie Reset
        //podobnie jest poprzednio, przywraca domyślne wartości dla kontekstu zasobów niezależnego od widoku.
        //Ten kontekst może być używany do dostępu do zasobów, które nie są powiązane z konkretnym widokiem.
        //Podsumowując, ten kod resetuje buforowanie w ramce, a także przywraca domyślne wartości
        //dla kontekstów zasobów bieżącego widoku i niezależnego od widoku.

        private void refresh(string lan)
        {
            if (current != lan)
            {
                ApplicationLanguages.PrimaryLanguageOverride = lan;
                var rootFrame = Window.Current.Content as Frame;
                rootFrame.CacheSize = 0;
                ResourceContext.GetForCurrentView().Reset();
                ResourceContext.GetForViewIndependentUse().Reset();
                rootFrame.Navigate(typeof(MainPage));

            }
        }
    }
}
