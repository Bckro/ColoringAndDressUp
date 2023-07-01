using System;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Graphics.Display;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace ColoringAndDressUp.GUI
{
    internal class SaveImage
    {
        /* Metody służące do zapisu do pliku JPG lub PNG obrazu Canvas. Działają one w następująćy sposób:
          
        1. Tworzony jest obiekt RenderTargetBitmap, który będzie używany do renderowania zawartości przekazanego obiektu Canvas.

        2. Wywoływana jest asynchroniczna metoda RenderAsync(canvas), która renderuje zawartość canvas na renderTargetBitmap.
        Ta metoda czeka na zakończenie renderowania przed przejściem do kolejnych kroków.

        3. Pobierany jest bufor pikseli z renderTargetBitmap przy użyciu metody GetPixelsAsync().
        Bufor pikseli jest następnie konwertowany na tablicę bajtów za pomocą metody ToArray().

        4. Pobierane są informacje o wyświetlaniu z obiektu DisplayInformation.
        DisplayInformation.GetForCurrentView() zwraca informacje dotyczące monitora, na którym jest wyświetlana aplikacja.

        5. Tworzony jest obiekt FileSavePicker, który pozwala użytkownikowi wybrać miejsce zapisu pliku.

        6. Uruchamiana jest asynchroniczna metoda PickSaveFileAsync() na obiekcie picker, aby wybrać plik do zapisania.
        Ta metoda czeka na wybór pliku przez użytkownika.

        7. Otwierany jest strumień do wybranego pliku, przy użyciu metody OpenAsync(FileAccessMode.ReadWrite).

        8. Tworzony jest enkoder BitmapEncoder przy użyciu metody CreateAsync.
        Ten enkoder jest używany do zapisu obrazu w formacie JPEG albo PNG.

        9. Ustawiane są dane pikseli na enkoderze za pomocą metody SetPixelData(),
        przekazując format pikseli, rozmiar, rozdzielczość DPI oraz tablicę bajtów pixels.

        10. Wywoływana jest asynchroniczna metodę FlushAsync() na enkoderze, aby zapisać dane obrazu na dysku. */

        public static async void JPG(Canvas canvas)
        {
            RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap();
            await renderTargetBitmap.RenderAsync(canvas);

            var pixelBuffer = await renderTargetBitmap.GetPixelsAsync();
            var pixels = pixelBuffer.ToArray();
            var displayInformation = DisplayInformation.GetForCurrentView();
            var picker = new FileSavePicker();
            picker.FileTypeChoices.Add("JPEG Image", new string[] { ".jpg" });
            StorageFile file = await picker.PickSaveFileAsync();
            using (var stream = await file.OpenAsync(FileAccessMode.ReadWrite))
            {
                var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.JpegEncoderId, stream);
                encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Ignore, (uint)renderTargetBitmap.PixelWidth, (uint)renderTargetBitmap.PixelHeight, displayInformation.RawDpiX, displayInformation.RawDpiY, pixels);
                await encoder.FlushAsync();
            }
        }

        //Zapisanie do pliku PNG zawartości Canvas. Zaczerpnięte ze StackOverflow.

        public static async void PNG(Canvas canvas)
        {
            RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap();
            await renderTargetBitmap.RenderAsync(canvas);

            var pixelBuffer = await renderTargetBitmap.GetPixelsAsync();
            var pixels = pixelBuffer.ToArray();
            var displayInformation = DisplayInformation.GetForCurrentView();
            var picker = new FileSavePicker();
            picker.FileTypeChoices.Add("PNG Image", new string[] { ".png" });
            StorageFile file = await picker.PickSaveFileAsync();
            using (var stream = await file.OpenAsync(FileAccessMode.ReadWrite))
            {
                var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, stream);
                encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Premultiplied, (uint)renderTargetBitmap.PixelWidth, (uint)renderTargetBitmap.PixelHeight, displayInformation.RawDpiX, displayInformation.RawDpiY, pixels);
                await encoder.FlushAsync();
            }
        }
    }
}
