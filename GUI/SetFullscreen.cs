using Windows.UI.ViewManagement;

namespace ColoringAndDressUp.GUI
{
    internal class SetFullscreen
    {
        //Klasa służy do ustawienia strony na pełen ekran. Pierwsza linijka pobiera obiekt ApplicationView
        //dla bieżącego widoku (okna) aplikacji. ApplicationView reprezentuje wygląd i zachowanie okna aplikacji
        //w systemie operacyjnym. Następnie wywoływana jest metoda TryEnterFullScreenMode() na obiekcie view,
        //próbując zmienić tryb wyświetlania aplikacji na pełny ekran. 
        public static void Set()
        {
            ApplicationView view = ApplicationView.GetForCurrentView();
            view.TryEnterFullScreenMode();
        }
    }
}
