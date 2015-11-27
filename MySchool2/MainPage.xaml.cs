using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;


// Документацию по шаблону элемента "Пустая страница" см. по адресу http://go.microsoft.com/fwlink/?LinkId=391641

namespace MySchool2
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
        
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Вызывается перед отображением этой страницы во фрейме.
        /// </summary>
        /// <param name="e">Данные события, описывающие, каким образом была достигнута эта страница.
        /// Этот параметр обычно используется для настройки страницы.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Подготовьте здесь страницу для отображения.

            // TODO: Если приложение содержит несколько страниц, обеспечьте
            // обработку нажатия аппаратной кнопки "Назад", выполнив регистрацию на
            // событие Windows.Phone.UI.Input.HardwareButtons.BackPressed.
            // Если вы используете NavigationHelper, предоставляемый некоторыми шаблонами,
            // данное событие обрабатывается для вас.
        }

        private void Changeimg(object sender, TappedRoutedEventArgs e)
        {
            for (var i = 0; i < 24; i++)
            {
                if (((BitmapImage)((Image)classgrid.Children.ElementAt(i)).Source).UriSource != new Uri(((Image)sender).BaseUri, "Assets/енот лапа.png"))
                {
                    ((BitmapImage)((Image)classgrid.Children.ElementAt(i)).Source).UriSource = new Uri(((Image)sender).BaseUri, "Assets/енот лапа.png");
                }
            }
                ((BitmapImage)((Image)sender).Source).UriSource = new Uri(((Image)sender).BaseUri, "Assets/енот лапа зел.png");
            
            localSettings.Values["myclass"] = (string)((Image)sender).Tag;

            go.Content = "Далее";
        }

        private void go_Click(object sender, RoutedEventArgs e)
        {
            if (localSettings.Values["myclass"] != null)
            {
                Frame.Navigate(typeof(FirstPage));
            }
        }
    }
}
