/*
 * DRESSUP.XAML
 * 
 * Mamy definicję kolumn, 9 stack paneli z kategoriami (np. ciało, oczy, usta). Na początku widoczny jesst jedynie
 * stack panel ciało. Dalej mamy stack panele z elementami z danej kategorii, canvas z laleczką do ubrania oraz
 * stack panel z przyciskami resetu, zapisu, powrotu do strony głównej i stack panelem z kolorami do wyboru.
*/

using ColoringAndDressUp.Assets;
using ColoringAndDressUp.GUI;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace ColoringAndDressUp
{
    public sealed partial class DressUp : Page
    {
        //Zadeklarowane zmienne pomocnicze.
        //Stack panel z obecnie wybraną kategorią, zmienne string oraz obecnie wybrany image.
        //Wszystko będzie jaśniejsze dalej.

        private StackPanel currentCategory;
        private String currentColor = "white", currentBody = "body_", currentEyes, currentMouth, currentHairFront,
            currentHairBack, currentTop, currentBottom, currentSuit, currentShoes, item;
        private Image currentImage;

        public DressUp()
        {
            this.InitializeComponent();

            //Początkowo wybraną kategorią jest ciało, tak samo obrazem.

            currentCategory = BodyCategory;
            currentImage = body;
        }

        public void CheckCategory()
        {
            //Funkcja do pomocniczego sprawdzania obecnie wybranej kategorii oraz
            //przypisywania odpowiednich wartości do zmiennych currentImage oraz item.

            if (currentCategory == BodyCategory)
            {
                currentImage = body;
                item = currentBody;
            }
            else if (currentCategory == EyesCategory)
            {
                currentImage = eyes;
                item = currentEyes;
            }
            else if (currentCategory == HairFrontCategory)
            {
                currentImage = hairfront;
                item = currentHairFront;
            }
            else if (currentCategory == HairBackCategory)
            {
                currentImage = hairback;
                item = currentHairBack;
            }
            else if (currentCategory == TopCategory)
            {
                currentImage = top;
                item = currentTop;
            }
            else if (currentCategory == BottomCategory)
            {
                currentImage = bottom;
                item = currentBottom;
            }
            else if (currentCategory == SuitCategory)
            {
                currentImage = suit;
                item = currentSuit;
            }
            else if (currentCategory == SuitCategory)
            {
                currentImage = suit;
                item = currentSuit;
            }
            else if (currentCategory == ShoesCategory)
            {
                currentImage = shoes;
                item = currentShoes;
            }
        }

        private void bDReset_Click(object sender, RoutedEventArgs e)
        {
            //Resetowanie laleczki, czyli wracamy do stanu pierwotnego strony. źródła poszczególnych kategorii (image)
            //zmieniane są na pusty przezroczysty plik png, wartość zmiennej currentCategory to z powrotem ciało,
            //podobnie jak currentImage. Wartość pozostałych zmiennych zmieniana jest na pusty string.

            Sound.PlaySoundEffect();
            body.Source = new BitmapImage(new Uri("ms-appx:///Assets/DressUp/BodyCategory/body_white.png"));
            eyes.Source = new BitmapImage(new Uri("ms-appx:///Assets/DressUp//blank.png"));
            mouth.Source = new BitmapImage(new Uri("ms-appx:///Assets/DressUp//blank.png"));
            hairfront.Source = new BitmapImage(new Uri("ms-appx:///Assets/DressUp//blank.png"));
            hairback.Source = new BitmapImage(new Uri("ms-appx:///Assets/DressUp//blank.png"));
            top.Source = new BitmapImage(new Uri("ms-appx:///Assets/DressUp//blank.png"));
            bottom.Source = new BitmapImage(new Uri("ms-appx:///Assets/DressUp//blank.png"));
            suit.Source = new BitmapImage(new Uri("ms-appx:///Assets/DressUp//blank.png"));
            shoes.Source = new BitmapImage(new Uri("ms-appx:///Assets/DressUp//blank.png"));
            currentCategory = BodyCategory;
            currentImage = body;
            currentEyes = currentMouth = currentHairFront = currentHairBack = currentTop = currentBottom = currentSuit = currentShoes = "";
        }

        private void bDSave_Click(object sender, RoutedEventArgs e)
        {
            //Laleczka zapisywana jest do pliku png (dzięki czemu jest ona na przezroczystym tle).
            //Dokładniejszy opis znajduje się z odpowiedniej klasie - SaveImage.

            Sound.PlaySoundEffect();
            SaveImage.PNG(dressUpCanvas);
            Frame.GoBack();
        }

        //Funkcja pomocnicza do zmiany kategorii ubioru. Sprawdzamy, czy kategoria, to Usta. Jeśli tak, to chowamy
        //paletę. Jeśli nie, to paleta jest pokazywana. Związane jest to z tym, że nie ma możliwości zmiany
        //koloru ust. Następnie następuje ukrycie obecnie wybranej kategori, oraz pokazanie klikniętej.
        //Oprócz tego zmieniana jest wartość zmiennej pomocniczej.

        void categoryClick(StackPanel category)
        {
            Sound.PlaySoundEffect();
            if (category != MouthCategory)
            {
                ColorPalette.Visibility = Visibility.Visible;
            }
            else
            {
                ColorPalette.Visibility = Visibility.Collapsed;
            }
            currentCategory.Visibility = Visibility.Collapsed;
            category.Visibility = Visibility.Visible;
            currentCategory = category;
        }

        private void bOne_Click(object sender, RoutedEventArgs e)
        {
            categoryClick(BodyCategory);
        }

        private void bTwo_Click(object sender, RoutedEventArgs e)
        {
            categoryClick(EyesCategory);
        }

        private void bThree_Click(object sender, RoutedEventArgs e)
        {
            categoryClick(MouthCategory);
        }

        private void bFour_Click(object sender, RoutedEventArgs e)
        {
            categoryClick(HairFrontCategory);
        }

        private void bFive_Click(object sender, RoutedEventArgs e)
        {
            categoryClick(HairBackCategory);
        }

        private void bSix_Click(object sender, RoutedEventArgs e)
        {
            categoryClick(TopCategory);
        }

        private void bSeven_Click(object sender, RoutedEventArgs e)
        {
            categoryClick(BottomCategory);
        }

        private void bEight_Click(object sender, RoutedEventArgs e)
        {
            categoryClick(SuitCategory);
        }

        private void bNine_Click(object sender, RoutedEventArgs e)
        {
            categoryClick(ShoesCategory);
        }

        //Tutaj funkcja pomocnicza do klikania w przyciski z kolorami - red, orange, yellow... black. Wywoływana jest funkcja
        //pomocnicza CheckCategory, zmieniany jest obecny kolor oraz następuje pokazanie pokolorowanego na odpowiedni kolor elementu.
        //Dlatego zmieniane jest źródło obecnie wybranego image (kategorii) za pomocą zmiennych pomocniczych używanych do tworzenia uri.

        void changeColor(string color)
        {
            Sound.PlaySoundEffect();
            CheckCategory();
            currentColor = color;
            currentImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/DressUp/" + currentCategory.Name.ToString() + "/" + item + currentColor + ".png"));
        }

        private void red_Click(object sender, RoutedEventArgs e)
        {
            changeColor("red");
        }

        private void orange_Click(object sender, RoutedEventArgs e)
        {
            changeColor("orange");
        }

        private void yellow_Click(object sender, RoutedEventArgs e)
        {
            changeColor("yellow");
        }

        private void green_Click(object sender, RoutedEventArgs e)
        {
            changeColor("green");
        }

        private void lightblue_Click(object sender, RoutedEventArgs e)
        {
            changeColor("lightblue");
        }

        private void darkblue_Click(object sender, RoutedEventArgs e)
        {
            changeColor("darkblue");
        }

        private void purple_Click(object sender, RoutedEventArgs e)
        {
            changeColor("purple");
        }

        private void lightpink_Click(object sender, RoutedEventArgs e)
        {
            changeColor("lightpink");
        }

        private void darkpink_Click(object sender, RoutedEventArgs e)
        {
            changeColor("darkpink");
        }

        private void beige_Click(object sender, RoutedEventArgs e)
        {
            changeColor("beige");
        }

        private void white_Click(object sender, RoutedEventArgs e)
        {
            changeColor("white");
        }
        private void black_Click(object sender, RoutedEventArgs e)
        {
            changeColor("black");
        }

        //Tutaj eventy klikania w poszczególne elementy danej kategorii są one pokazywane na laleczce w białym kolorze.
        //Jedynie pry kliknięciu w suit, bottom oraz top są drobne różnice. Jeśli jest założony suit, a chcemy założyć
        //top albo bottom, trzeba suit najpierw ukryć. Jeśli założony jest top lub bottom, a chcemy założyć suit,
        //musimy ukryć top lub suit.

        private void body__Click(object sender, RoutedEventArgs e)
        {
            Sound.PlaySoundEffect();
        }

        private void eyes1__Click(object sender, RoutedEventArgs e)
        {
            Sound.PlaySoundEffect();
            if (currentEyes != "eyes1_")
            {
                eyes.Source = new BitmapImage(new Uri("ms-appx:///Assets/DressUp/EyesCategory/eyes1_white.png"));
                currentEyes = "eyes1_";
            }
        }

        private void eyes2__Click(object sender, RoutedEventArgs e)
        {
            Sound.PlaySoundEffect();
            if (currentEyes != "eyes2_")
            {
                eyes.Source = new BitmapImage(new Uri("ms-appx:///Assets/DressUp/EyesCategory/eyes2_white.png"));
                currentEyes = "eyes2_";
            }
        }

        private void eyes3__Click(object sender, RoutedEventArgs e)
        {
            Sound.PlaySoundEffect();
            if (currentEyes != "eyes3_")
            {
                eyes.Source = new BitmapImage(new Uri("ms-appx:///Assets/DressUp/EyesCategory/eyes3_white.png"));
                currentEyes = "eyes3_";
            }
        }

        private void mouth1_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlaySoundEffect();
            if (currentMouth != "mouth1")
            {
                mouth.Source = new BitmapImage(new Uri("ms-appx:///Assets/DressUp/MouthCategory/mouth1.png"));
                currentMouth = "mouth1";
            }
        }

        private void mouth2_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlaySoundEffect();
            if (currentMouth != "mouth2")
            {
                mouth.Source = new BitmapImage(new Uri("ms-appx:///Assets/DressUp/MouthCategory/mouth2.png"));
                currentMouth = "mouth2";
            }
        }

        private void mouth3_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlaySoundEffect();
            if (currentMouth != "mouth3")
            {
                mouth.Source = new BitmapImage(new Uri("ms-appx:///Assets/DressUp/MouthCategory/mouth3.png"));
                currentMouth = "mouth3";
            }
        }

        private void hairfront1_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlaySoundEffect();
            if (currentHairFront != "hairfront1_")
            {
                hairfront.Source = new BitmapImage(new Uri("ms-appx:///Assets/DressUp/HairFrontCategory/hairfront1_white.png"));
                currentHairFront = "hairfront1_";
            }
        }

        private void hairfront2_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlaySoundEffect();
            if (currentHairFront != "hairfront2_")
            {
                hairfront.Source = new BitmapImage(new Uri("ms-appx:///Assets/DressUp/HairFrontCategory/hairfront2_white.png"));
                currentHairFront = "hairfront2_";
            }
        }

        private void hairfront3_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlaySoundEffect();
            if (currentHairFront != "hairfront3_")
            {
                hairfront.Source = new BitmapImage(new Uri("ms-appx:///Assets/DressUp/HairFrontCategory/hairfront3_white.png"));
                currentHairFront = "hairfront3_";
            }
        }

        private void bDBack_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlaySoundEffect();
            Frame.GoBack();
        }

        private void hairback1_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlaySoundEffect();
            if (currentHairBack != "hairback1_")
            {
                hairback.Source = new BitmapImage(new Uri("ms-appx:///Assets/DressUp/HairBackCategory/hairback1_white.png"));
                currentHairBack = "hairback1_";
            }
        }

        private void hairback2_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlaySoundEffect();
            if (currentHairBack != "hairback2_")
            {
                hairback.Source = new BitmapImage(new Uri("ms-appx:///Assets/DressUp/HairBackCategory/hairback2_white.png"));
                currentHairBack = "hairback2_";
            }
        }

        private void hairback3_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlaySoundEffect();
            if (currentHairBack != "hairback3_")
            {
                hairback.Source = new BitmapImage(new Uri("ms-appx:///Assets/DressUp/HairBackCategory/hairback3_white.png"));
                currentHairBack = "hairback3_";
            }
        }

        private void top1_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlaySoundEffect();
            if (currentTop != "top1_")
            {
                suit.Source = new BitmapImage(new Uri("ms-appx:///Assets/DressUp/blank.png"));
                top.Source = new BitmapImage(new Uri("ms-appx:///Assets/DressUp/TopCategory/top1_white.png"));
                currentTop = "top1_";
            }
        }

        private void top2_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlaySoundEffect();
            if (currentTop != "top2_")
            {
                suit.Source = new BitmapImage(new Uri("ms-appx:///Assets/DressUp/blank.png"));
                top.Source = new BitmapImage(new Uri("ms-appx:///Assets/DressUp/TopCategory/top2_white.png"));
                currentTop = "top2_";
            }
        }

        private void top3_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlaySoundEffect();
            if (currentTop != "top3_")
            {
                suit.Source = new BitmapImage(new Uri("ms-appx:///Assets/DressUp/blank.png"));
                top.Source = new BitmapImage(new Uri("ms-appx:///Assets/DressUp/TopCategory/top3_white.png"));
                currentTop = "top3_";
            }
        }

        private void bottom1_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlaySoundEffect();
            if (currentBottom != "bottom1_")
            {
                suit.Source = new BitmapImage(new Uri("ms-appx:///Assets/DressUp/blank.png"));
                bottom.Source = new BitmapImage(new Uri("ms-appx:///Assets/DressUp/BottomCategory/bottom1_white.png"));
                currentBottom = "bottom1_";
            }
        }

        private void bottom2_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlaySoundEffect();
            if (currentBottom != "bottom2_")
            {
                suit.Source = new BitmapImage(new Uri("ms-appx:///Assets/DressUp/blank.png"));
                bottom.Source = new BitmapImage(new Uri("ms-appx:///Assets/DressUp/BottomCategory/bottom2_white.png"));
                currentBottom = "bottom2_";
            }
        }

        private void bottom3_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlaySoundEffect();
            if (currentBottom != "bottom3_")
            {
                suit.Source = new BitmapImage(new Uri("ms-appx:///Assets/DressUp/blank.png"));
                bottom.Source = new BitmapImage(new Uri("ms-appx:///Assets/DressUp/BottomCategory/bottom3_white.png"));
                currentBottom = "bottom3_";
            }
        }

        private void suit1_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlaySoundEffect();
            if (currentSuit != "suit1_")
            {
                top.Source = new BitmapImage(new Uri("ms-appx:///Assets/DressUp/blank.png"));
                bottom.Source = new BitmapImage(new Uri("ms-appx:///Assets/DressUp/blank.png"));
                suit.Source = new BitmapImage(new Uri("ms-appx:///Assets/DressUp/SuitCategory/suit1_white.png"));
                currentSuit = "suit1_";
            }
        }

        private void suit2_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlaySoundEffect();
            if (currentSuit != "suit2_")
            {
                top.Source = new BitmapImage(new Uri("ms-appx:///Assets/DressUp/blank.png"));
                bottom.Source = new BitmapImage(new Uri("ms-appx:///Assets/DressUp/blank.png"));
                suit.Source = new BitmapImage(new Uri("ms-appx:///Assets/DressUp/SuitCategory/suit2_white.png"));
                currentSuit = "suit2_";
            }
        }

        private void suit3_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlaySoundEffect();
            if (currentSuit != "suit3_")
            {
                top.Source = new BitmapImage(new Uri("ms-appx:///Assets/DressUp/blank.png"));
                bottom.Source = new BitmapImage(new Uri("ms-appx:///Assets/DressUp/blank.png"));
                suit.Source = new BitmapImage(new Uri("ms-appx:///Assets/DressUp/SuitCategory/suit3_white.png"));
                currentSuit = "suit3_";
            }
        }

        private void shoes1_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlaySoundEffect();
            if (currentShoes != "shoes1_")
            {
                shoes.Source = new BitmapImage(new Uri("ms-appx:///Assets/DressUp/ShoesCategory/shoes1_white.png"));
                currentShoes = "shoes1_";
            }
        }

        private void shoes2_Click(object sender, RoutedEventArgs e)
        {
            Sound.PlaySoundEffect();
            if (currentShoes != "shoes2_")
            {
                shoes.Source = new BitmapImage(new Uri("ms-appx:///Assets/DressUp/ShoesCategory/shoes2_white.png"));
                currentShoes = "shoes2_";
            }
        }
    }
}
