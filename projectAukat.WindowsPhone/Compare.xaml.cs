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
    public sealed partial class Compare : Page
    {
        private Paper data;
        private Paper data2;
        public Compare()
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
            StorageFile sampleFile = await folder.GetFileAsync("sample.txt");

            string testlol = await Windows.Storage.FileIO.ReadTextAsync(sampleFile);
            string he = testlol;
            Outputbox.Text = he;
            StorageFolder folder2 = Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFile sampleFile2 = await folder2.GetFileAsync("data.txt");

            string testlol2 = await Windows.Storage.FileIO.ReadTextAsync(sampleFile2);
            data = new Paper();
            data = JsonConvert.DeserializeObject<Paper>(testlol2);
            
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
            else if (b[0] == 'L')
            {
                Frame.Navigate(typeof(ResultPage));
            }
            else if (b[0] == 'e')
            {
                Frame.Navigate(typeof(ex_Result));
            }
            else if (b[0] == 'M')
            {
                Frame.Navigate(typeof(Aukat));
            }
            else if (b[0] == 'A')
            {
                Frame.Navigate(typeof(About));
            }
            else if (b[0] == 'F')
            {
                Frame.Navigate(typeof(Feedback));
            }
        }

        private async void box_LostFocus(object sender, RoutedEventArgs e)
        {
            string he = box.Text;
            List<int> index = new List<int>();
            List<string> paperData = new List<string>();
            List<string> paperDataFinal = new List<string>();
            //lol.Source = new Uri("http://akshit.xyz/resultsggsipu");
            HttpClient client = new HttpClient();
            string a = await client.GetStringAsync("http://akshit.xyz/resultsggsipu/dbinteraction/dbConnection.php?" + he);
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
            int j = 9, k;
            for (j = 0; j < index.Count - 1; j++)
            {
                paperData.Add(a.Substring(index[j] + 5, ((index[j + 1] - 8) - index[j])));
            }
            string test = a.Substring(index[j] + 5);
            paperData.Add(test.Substring(0, test.Length - 3));
            string mainData = a.Substring(0, index[0] - 11) + "}";
            Result hi = JsonConvert.DeserializeObject<Result>(mainData);
            data2 = new Paper();

            data2.s0 = new List<List<S0>>();

            foreach (string hell in paperData)
            {
                k = 0;

                for (j = 0; j < hell.Length; j++)
                {
                    if (hell[j] == '}')
                    {
                        paperDataFinal.Add(hell.Substring(k, j - k + 1));
                        k = j + 2;
                    }
                }
                List<S0> fine = new List<S0>();
                foreach (string temp2 in paperDataFinal)
                {
                    S0 appy = new S0();
                    appy = JsonConvert.DeserializeObject<S0>(temp2);
                    fine.Add(appy);
                }
                paperDataFinal.Clear();
                data2.s0.Add(fine);
            }
            lol();
            lol2();
            //List<List<forGraph>> mySuperList = new List<List<forGraph>>();

            //foreach (S0 bh in bbh)
            //{

            //    forGraph temp23 = new forGraph();
            //    temp23.Subject = f.ToString();
            //    temp23.Marks = bh.total;
            //    myList.Add(temp23);
            //}


            //if (inter == 0)
            //{
            //    LineChart.Visibility = Windows.UI.Xaml.Visibility.Visible;
            //    (LineChart.Series[0] as LineSeries).ItemsSource = myList;
            //}
            //else if (inter == 1)
            //{
            //    LineChart2.Visibility = Windows.UI.Xaml.Visibility.Visible;
            //    (LineChart2.Series[0] as LineSeries).ItemsSource = myList;
            //}
            //else if (inter == 2)
            //{
            //    LineChart3.Visibility = Windows.UI.Xaml.Visibility.Visible;
            //    (LineChart3.Series[0] as LineSeries).ItemsSource = myList;
            //}
            //else if (inter == 3)
            //{
            //    LineChart4.Visibility = Windows.UI.Xaml.Visibility.Visible;
            //    (LineChart4.Series[0] as LineSeries).ItemsSource = myList;
            //}
            //else if (inter == 4)
            //{
            //    LineChart5.Visibility = Windows.UI.Xaml.Visibility.Visible;
            //    (LineChart5.Series[0] as LineSeries).ItemsSource = myList;
            //}
            //else if (inter == 5)
            //{
            //    LineChart6.Visibility = Windows.UI.Xaml.Visibility.Visible;
            //    (LineChart6.Series[0] as LineSeries).ItemsSource = myList;
            //}
            //else if (inter == 6)
            //{
            //    LineChart7.Visibility = Windows.UI.Xaml.Visibility.Visible;
            //    (LineChart7.Series[0] as LineSeries).ItemsSource = myList;
            //}
            //else if (inter == 7)
            //{
            //    LineChart8.Visibility = Windows.UI.Xaml.Visibility.Visible;
            //    (LineChart8.Series[0] as LineSeries).ItemsSource = myList;
            //}

        }

        private void lol()
        {
            List<forGraph> myList = new List<forGraph>();

            double f = 1.1;
            //for (int k = 0; k < data.s0.Count; k++)
            //{

                myList = new List<forGraph>();//so that a nw list is made everytime

                List<S0> bbh = new List<S0>();
                List<S0> bbh2 = new List<S0>();
                bbh = data.s0[0];
                bbh2 = data2.s0[0];
                for (int g = 0; g <bbh.Count; g++)
                {
                    
                    forGraph temp23 = new forGraph();
                    temp23.Subject = f.ToString();
                    temp23.Marks = bbh[g].total;
                    myList.Add(temp23);
                    f += 0.1;
                    forGraph temp24 = new forGraph();
                    temp24.Subject = f.ToString();
                    temp24.Marks = bbh2[g].total;
                    myList.Add(temp24);
                    f += 0.9;
                }
                (SubjectChart.Series[0] as ColumnSeries).ItemsSource = myList;
            //}
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lol();
           
        }

        private async void Help_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MessageDialog msgbox = new MessageDialog("Your results of the latest semester is compared subject wise. x.1 shows your marks and x.2 shows your friends marks and x itself denotes the subject in order as shown on present result page! :)");
            await msgbox.ShowAsync();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void lol2()
        {
            List<forGraph> myList = new List<forGraph>();

            double f = 1.1;
            //for (int k = 0; k < data.s0.Count; k++)
            //{

            myList = new List<forGraph>();//so that a nw list is made everytime
            int total, total2;
            total = total2 = 0;
            List<S0> bbh = new List<S0>();
            List<S0> bbh2 = new List<S0>();
            for (int k = 0; k < data.s0.Count;k++ )
            {
                total2 = 0;
                total = 0;
                bbh = data.s0[k];
                bbh2 = data2.s0[k];

                
                    foreach (S0 mark in bbh)
                    {
                        total = total + int.Parse(mark.total);
                    }
                    foreach (S0 mark in bbh2)
                    {
                        total2 = total2 + int.Parse(mark.total);
                    }
                    total = total / bbh.Count;
                    total2 = total2 / bbh2.Count;
                   
                
                forGraph temp23 = new forGraph();
                temp23.Subject = f.ToString();
                temp23.Marks = total.ToString();
                myList.Add(temp23);
                f += 0.1;
                forGraph temp24 = new forGraph();
                temp24.Subject = f.ToString();
                temp24.Marks = total2.ToString();
                myList.Add(temp24);
                f += 0.9;
            }
            (SemesterChart.Series[0] as ColumnSeries).ItemsSource = myList;
            
        }

        private void PivotItem_GotFocus(object sender, RoutedEventArgs e)
        {
            lol2();
        }
    }
}