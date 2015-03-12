using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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
using Windows.UI.Xaml.Navigation;
using WinRTXamlToolkit.Controls.DataVisualization.Charting;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace projectAukat
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Aukat : Page
    {
        public Aukat()
        {
            this.InitializeComponent();
            DrawerLayout.InitializeDrawerLayout();

            string[] menuItems = new string[] { "Latest Result", "ex-Result", "My Performance", "Compare Me!", "FeedBack", "About" };
            ListMenuItems.ItemsSource = menuItems.ToList();  
        }
        private void DrawerIcon_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (DrawerLayout.IsDrawerOpen)
                DrawerLayout.CloseDrawer();
            else
                DrawerLayout.OpenDrawer();
        }
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            onLaunch();
            Windows.Phone.UI.Input.HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        }
        private async void onLaunch()
        {
            
            StorageFolder folder = Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFile sampleFile = await folder.GetFileAsync("data.txt");
            string testlol = await Windows.Storage.FileIO.ReadTextAsync(sampleFile);
            Paper data = new Paper();
            data = JsonConvert.DeserializeObject<Paper>(testlol);
            //now we plot some graphs
            //there are by default 8 garphs declared in xaml visibilty of all collapsed
            //as we will we encounter more data they will become visible and get binded with data
            List<forGraph> myList = new List<forGraph>();
            int inter = 0;
            int f = 0;
            foreach (List<S0> bbh in data.s0)
            {
                f = 0;
                myList = new List<forGraph>();//so that a nw list is made everytime
                foreach (S0 bh in bbh)
                {
                    f++;
                    forGraph temp23 = new forGraph();
                    temp23.Subject = f.ToString();
                    temp23.Marks = bh.total;
                    myList.Add(temp23);
                }
                if (inter == 0)
                {
                    LineChart.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    (LineChart.Series[0] as LineSeries).ItemsSource = myList;
                }
                else if (inter == 1)
                {
                    LineChart2.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    (LineChart2.Series[0] as LineSeries).ItemsSource = myList;
                }
                else if (inter == 2)
                {
                    LineChart3.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    (LineChart3.Series[0] as LineSeries).ItemsSource = myList;
                }
                else if (inter == 3)
                {
                    LineChart4.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    (LineChart4.Series[0] as LineSeries).ItemsSource = myList;
                }
                else if (inter == 4)
                {
                    LineChart5.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    (LineChart5.Series[0] as LineSeries).ItemsSource = myList;
                }
                else if (inter == 5)
                {
                    LineChart6.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    (LineChart6.Series[0] as LineSeries).ItemsSource = myList;
                }
                else if (inter == 6)
                {
                    LineChart7.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    (LineChart7.Series[0] as LineSeries).ItemsSource = myList;
                }
                else if (inter == 7)
                {
                    LineChart8.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    (LineChart8.Series[0] as LineSeries).ItemsSource = myList;
                }          
                inter++;    
            }
            
        }
      
        void HardwareButtons_BackPressed(object sender, Windows.Phone.UI.Input.BackPressedEventArgs e)
        {
            if (DrawerLayout.IsDrawerOpen)
            {
                DrawerLayout.CloseDrawer();
                e.Handled = true;
            }
            else
            {
                Frame.Navigate(typeof(MainPage));
            }
        }

        private void ListMenuItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView a = sender as ListView;
            string b = a.SelectedItem as string;
            if (b[0] == 'C')
            {
                Frame.Navigate(typeof(Compare));
            }
            if (b[0] == 'L')
            {
                Frame.Navigate(typeof(ResultPage));
            }
            if (b[0] == 'e')
            {
                Frame.Navigate(typeof(ex_Result));
            }
            if (b[0] == 'M')
            {
                Frame.Navigate(typeof(Aukat));
            }
            if (b[0] == 'A')
            {
                Frame.Navigate(typeof(About));
            }
            if (b[0] == 'F')
            {
                Frame.Navigate(typeof(Feedback));
            }
        }

        private async void Help_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MessageDialog msgbox = new MessageDialog("Your results are arranged in order of the semseters since 2013 december with marks on x axis and subjects on y axis and subjects in order of display in ex-results");
            await msgbox.ShowAsync();
            //Flyout fly = new Flyout();
            //TextBlock hello = new TextBlock();
            //hello.Text = "Your results are arranged in order of the semseters since 2013 december with marks on x axis and subjects on y axis and subjects in order of display in ex-results";
            //hello.TextWrapping = TextWrapping.Wrap;
            //fly.Content = hello;
           
        }  
    }
}
