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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace projectAukat
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Feedback : Page
    {
        public Feedback()
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
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {

            Windows.Phone.UI.Input.HardwareButtons.BackPressed += HardwareButtons_BackPressed;
            StorageFolder folder = Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFile sampleFile = await folder.GetFileAsync("sample.txt");
            Result hi;
            string testlol = await Windows.Storage.FileIO.ReadTextAsync(sampleFile);
            string he = testlol;
            List<int> index = new List<int>();
            List<string> paperData = new List<string>();
            List<string> paperDataFinal = new List<string>();
            //lol.Source = new Uri("http://akshit.xyz/resultsggsipu");
            HttpClient client2 = new HttpClient();
            string a = await client2.GetStringAsync("http://akshit.xyz/resultsggsipu/dbinteraction/dbConnection.php?" + he);
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == 's')
                {
                    if (a[i + 1] == '0')
                    {
                        index.Add(i);
                    }
                    if (a[i + 1] == '1')
                    {
                        index.Add(i);
                    }
                    if (a[i + 1] == '2')
                    {
                        index.Add(i);
                    }
                    if (a[i + 1] == '3')
                    {
                        index.Add(i);
                    }
                    if (a[i + 1] == '4')
                    {
                        index.Add(i);
                    }
                    if (a[i + 1] == '5')
                    {
                        index.Add(i);
                    }
                    if (a[i + 1] == '6')
                    {
                        index.Add(i);
                    }
                    if (a[i + 1] == '7')
                    {
                        index.Add(i);
                    }

                }

            }
            int j = 9;
            for (j = 0; j < index.Count - 1; j++)
            {
                paperData.Add(a.Substring(index[j] + 5, ((index[j + 1] - 8) - index[j])));
            }
            string test = a.Substring(index[j] + 5);
            paperData.Add(test.Substring(0, test.Length - 3));
            string mainData = a.Substring(0, index[0] - 11) + "}";
            hi = JsonConvert.DeserializeObject<Result>(mainData);
            Namen.Text = hi.studentname;
            RollNo.Text = hi.rollnumber;
            Program.Text = hi.program;
        }
        private async void lol()
        {
            
            
            using (var client = new HttpClient())
            {
                var values = new Dictionary<string, string>
    {
       { "name", Namen.Text },
       { "rollnumber", RollNo.Text },
       {"program",Program.Text},
       {"semester",Semester.Text},
       {"appear",Appear.Text},
       {"explanation",Explanation.Text}
    };

                var content = new FormUrlEncodedContent(values);

                var response = await client.PostAsync("http://akshit.xyz/resultsggsipu/problemform.html", content);

                var responseString = await response.Content.ReadAsStringAsync();
                MessageDialog msgbox = new MessageDialog("Thank you for your feedback :)");
                await msgbox.ShowAsync();
                Frame.Navigate(typeof(ResultPage));
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lol();
        }  
    }
}
