using System;
using Windows.Media.Core;
using Windows.Media.Playback;

namespace ColoringAndDressUp.Assets
{
    internal static class Sound
    {
        //Dwa MediaPlayer do odtwarzania efektów dźwiękowych oraz muzyki oraz zmienna pomocnicza,
        //która pozwala na określenie, czy muzyka jest włączona, czy nie.
        //W musicPlayer włączone jest zapętlenie oraz zmieniona głośność.
        //Dlaczego źródło musicPlayera ustawiamy tutaj, a źródło soundPlayera niżej, w funkcji?
        //Ponieważ gdybyśmy ustawili Source soundPlayera tutaj, to przy kliknięciu odtworzony dźwięk
        //musiałby się zakończyć, żeby po naciśnięciu następnego również zagrał - żeby za każdym kliknięciem
        //ustawiane było źródło i dzięki temu po każdym kliknięciu był efekt dźwiękowy.

        public static MediaPlayer soundPlayer = new MediaPlayer();
        public static MediaPlayer musicPlayer = new MediaPlayer()
        {
            Volume = 0.4,
            IsLoopingEnabled = true,
            Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/Sound/music.wav"))
        };
        public static String onOff = "on";

        //Metoda pozwala na odtwarzanie muzyki.

        public static void PlayBackgroundMusic()
        {
            musicPlayer.Play();
        }

        //Metoda pozwala na zatrzymanie odtwarzania muzyki.

        public static void StopBackgroundMusic()
        {
            musicPlayer.Pause();
        }

        //Metoda pozwala na odtworzenie efektu dźwiękowego przy klikaniu w przycisk.
        public static void PlaySoundEffect()
        {
            soundPlayer.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/Sound/press.mp3"));
            soundPlayer.Play();
        }
    }
}
