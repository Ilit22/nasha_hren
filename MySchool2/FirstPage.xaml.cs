using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента пустой страницы см. по адресу http://go.microsoft.com/fwlink/?LinkID=390556

namespace MySchool2
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class FirstPage : Page
    {
        ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
        public FirstPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Вызывается перед отображением этой страницы во фрейме.
        /// </summary>
        /// <param name="e">Данные события, описывающие, каким образом была достигнута эта страница.
        /// Этот параметр обычно используется для настройки страницы.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void stackpanel_loaded(object sender, RoutedEventArgs e)
        {
            cab.Text = localSettings.Values["myclass"].ToString();
        }

        private void back_view(object sender, PointerRoutedEventArgs e)
        {
           ((StackPanel)sender).Background = new SolidColorBrush(Color.FromArgb(10, 255, 255, 255));
        }

        private void back_view2(object sender, PointerRoutedEventArgs e)
        {
            ((StackPanel)sender).Background = new SolidColorBrush(Color.FromArgb(50, 0, 0, 0));

        }

        private async void timel_loaded(object sender, RoutedEventArgs e)
        {

            while (true)
            {
                DateTime dt = DateTime.Now;
                //timel.Text = dt.ToString("HH:mm:ss");
                int dh = dt.Hour;
                int dm = dt.Minute;
                int ds = dt.Second;

                int[,] hms =
                {
                {8, 30, 60, 15, 1}, //1 
                {9, 00, 15, -45, 1}, //1
                {9, 15, 30, -30, 2},
                {9, 30, 60, 15, 1}, //2
                {10, 00, 15, -45, 1}, //2
                {10, 15, 35, -25, 2},
                {10, 35, 60, 20, 1}, //3
                {11, 00, 20, -40, 1}, //3
                {11, 20, 35, -25, 2},
                {11, 35, 60, 20, 1}, //4
                {12, 00, 20, -40, 1}, //4
                {12, 20, 30, -30, 2},
                {12, 30, 60, 15, 1}, //5
                {13, 00, 15, -45, 1}, //5
                {13, 15, 25, -35, 2},
                {13, 25, 60, 10, 1}, //6
                {14, 00, 10, -50, 1}, //6
                {14, 10, 30, -30, 2},
                {14, 30, 60, 15, 1}, //7
                {15, 00, 15, -45, 1} //7
                };

                for (int i = 0; i < 20; i++)
                {
                    if (dh == hms[i, 0] && dm >= hms[i, 1] && dm < hms[i, 2])
                    {
                    dh = 0;
                    dm = 59 - dm + hms[i, 3];
                    ds = 59 - ds;
                    }

                    if (dh == hms[i, 0] && dm >= hms[i, 1] && dm < hms[i, 2] & hms[i, 4] == 1) {
                        timel.Foreground = new SolidColorBrush(Color.FromArgb(255, 234, 34, 34));
                    }
                    else   
                    {
                        timel.Foreground = new SolidColorBrush(Color.FromArgb(255, 92, 193, 10));
                    }
                }

                string sdh = dh.ToString(), sdm = dm.ToString(), sds = ds.ToString();

                if (ds < 10) {
                    sds = "0" + ds;
                }

                if (dm < 10)
                {
                    sdm = "0" + dm;
                }

                if (dh < 10)
                {
                    sdh = "0" + dh;
                }

                timel.Text = sdh + ":" + sdm + ":" + sds;
                await Task.Delay(1000);
            }
        }
    }
}
