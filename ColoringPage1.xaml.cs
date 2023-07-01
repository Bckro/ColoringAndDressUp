/*
 * COLORINGPAGE1.XAML
 * 
 * Mamy definicję kolumn, przycisk zapisu, powrotu, stack panel z kolorami, sliderem rozmiaru pędzla i text boxem,'
 * canvas, na którym będzie można malować oraz stack panel z wyborem gumki, resetu oraz cofnięcia akcji.
 * 
*/

using ColoringAndDressUp.Assets;
using ColoringAndDressUp.GUI;
using System;
using System.Collections.Generic;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

namespace ColoringAndDressUp
{
    public sealed partial class ColoringPage1 : Page
    {
        //Stos kształtów, czyli to, co będziemy rysować - będzie pomocny przy akcjach cofania oraz resetowania.
        //SolidColorBrush to nasz pędzel, startPoint będzie punktem początkowym, a zmienna boolowska isDrawing
        //służyć będzie do określania, czy obecnie rysujemy, czy też nie.

        Stack<Shape> undoStack = new Stack<Shape>();
        SolidColorBrush brush = new SolidColorBrush(Windows.UI.Colors.White);
        Point startPoint;
        bool isDrawing;

        public ColoringPage1()
        {
            this.InitializeComponent();
        }

        //Ten event powiązany jest ze stroną ColoringPages. Przypisane tam uri z wybranym obrazkiem do kolorowania
        //jest przesyłane tutaj. Zmieniane jest źródło obrazka na canvas, dzięki czemu pokazuje się kolorowanka.

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Uri uri = e.Parameter as Uri;
            backgroundImage.Source = new BitmapImage(uri);
        }

        //Event, gdy poruszymy kursorem na canvas. Jeśli rysuje - czyli zmienna isDrawing równa się true,
        //to zapisywana jest po aktualna pozycja oraz tworzona jest nowa linia z następującymi parametrami:
        //Stroke to nasz pędzal, StrokeThickness to grubość pędzla pobrana ze slidera, X1, Y1 to współrzędne
        //punktu startowego, a X2, Y2 punktu obecnego. StrokeStartLineCap i StrokeLineCap ustawione na
        //PenLineCap.Round powodują, że linia ma zaokrąglone początek oraz koniec. Do canvy dodawane jest
        //children, podobnie jak do stosu undoStack (line). Punktem startowym staje się obecny punkt.


        private void coloring_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            if (!isDrawing)
            {
                return;
            }
            Point currentPoint = e.GetCurrentPoint(coloring).Position;
            Line line = new Line()
            {
                Stroke = brush,
                StrokeThickness = thickness.Value,
                X1 = startPoint.X,
                Y1 = startPoint.Y,
                X2 = currentPoint.X,
                Y2 = currentPoint.Y,
                StrokeStartLineCap = PenLineCap.Round,
                StrokeEndLineCap = PenLineCap.Round
            };
            coloring.Children.Add(line);
            undoStack.Push(line);
            startPoint = currentPoint;
        }

        //Jeśli naciśniemy przycisk myszy na canvas, zapisywana jest obecna pozycja kursora
        //oraz zmieniana wartość zmiennej isDrawing na true - rysujemy.

        private void coloring_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            startPoint = e.GetCurrentPoint(coloring).Position;
            isDrawing = true;
        }

        //Jeśli puścimy przycisk myszki na canvas, zmienna ustawiana jest na false - nie rysujemy.

        private void coloring_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            isDrawing = false;
        }

        //Paleta kolorów. Po kliknięciu w przycisk zmieniany jest kolor pędzla.

        private void Red_Click(object sender, RoutedEventArgs e)
        {
            brush = (e.OriginalSource as Button).Background as SolidColorBrush;
        }

        private void Orange_Click(object sender, RoutedEventArgs e)
        {
            brush = (e.OriginalSource as Button).Background as SolidColorBrush;
        }

        private void Yellow_Click(object sender, RoutedEventArgs e)
        {
            brush = (e.OriginalSource as Button).Background as SolidColorBrush;
        }

        private void Green_Click(object sender, RoutedEventArgs e)
        {
            brush = (e.OriginalSource as Button).Background as SolidColorBrush;
        }

        private void LightBlue_Click(object sender, RoutedEventArgs e)
        {
            brush = (e.OriginalSource as Button).Background as SolidColorBrush;
        }

        private void DarkBlue_Click(object sender, RoutedEventArgs e)
        {
            brush = (e.OriginalSource as Button).Background as SolidColorBrush;
        }

        private void Purple_Click(object sender, RoutedEventArgs e)
        {
            brush = (e.OriginalSource as Button).Background as SolidColorBrush;
        }

        private void LightPink_Click(object sender, RoutedEventArgs e)
        {
            brush = (e.OriginalSource as Button).Background as SolidColorBrush;
        }

        private void DarkPink_Click(object sender, RoutedEventArgs e)
        {
            brush = (e.OriginalSource as Button).Background as SolidColorBrush;
        }

        private void Beige_Click(object sender, RoutedEventArgs e)
        {
            brush = (e.OriginalSource as Button).Background as SolidColorBrush;
        }

        private void White_Click(object sender, RoutedEventArgs e)
        {
            brush = (e.OriginalSource as Button).Background as SolidColorBrush;
        }

        private void Black_Click(object sender, RoutedEventArgs e)
        {
            brush = (e.OriginalSource as Button).Background as SolidColorBrush;
        }

        //Wybór gumki. Zmiana koloru pędzla na biały.

        private void bCRubber_Click(object sender, RoutedEventArgs e)
        {
            brush = new SolidColorBrush(Windows.UI.Colors.White);
        }

        //Cofanie akcji. Jeśli stos nie jest pusty, następuje usunięcie ostatniego children ze stosu i z canvas.

        private void bCUndo_Click(object sender, RoutedEventArgs e)
        {
            if (undoStack.Count > 0)
            {
                var doUsuniecia = undoStack.Pop();
                coloring.Children.Remove(doUsuniecia);
            }
        }

        //Resetowanie. Dopóki stos nie jest pusty, następuje usuwanie kolejnych children ze stosu oraz z canvas.

        private void bCReset_Click(object sender, RoutedEventArgs e)
        {
            while (undoStack.Count > 0)
            {
                var doUsuniecia = undoStack.Pop();
                coloring.Children.Remove(doUsuniecia);
            }
        }

        private void bCBack_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlaySoundEffect();
            Frame.GoBack();
        }

        //Zapisanie pokolorowanego obrazka do pliku JPG.

        private void bCSave_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlaySoundEffect();
            SaveImage.JPG(coloring);
            Frame.GoBack();
        }
    }
}
