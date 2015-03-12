using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Email;
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
    
    public sealed partial class ResultPage : Page
    {
        string exc;
        public Result hi;
        public ResultPage()
        {
            this.InitializeComponent();
            DrawerLayout.InitializeDrawerLayout();

            string[] menuItems = new string[] { "Latest Result","ex-Result", "My Performance", "Compare Me!", "FeedBack", "About" };
            ListMenuItems.ItemsSource = menuItems.ToList();  
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
         private async void onLaunch()
        {
            
            try
            {
                MainFragment.Visibility = Windows.UI.Xaml.Visibility.Visible;
                ListFragment.Visibility = Windows.UI.Xaml.Visibility.Visible;
                TitleBar.Visibility = Windows.UI.Xaml.Visibility.Visible;
                StorageFolder folder = Windows.Storage.ApplicationData.Current.LocalFolder;
                StorageFile sampleFile = await folder.GetFileAsync("sample.txt");

                string testlol = await Windows.Storage.FileIO.ReadTextAsync(sampleFile);
                string he = testlol;
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
                hi = JsonConvert.DeserializeObject<Result>(mainData);
                Paper data = new Paper();

                data.s0 = new List<List<S0>>();

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
                    data.s0.Add(fine);
                }
                secondList.DataContext = data.s0[data.s0.Count - 1];
                string lol123 = JsonConvert.SerializeObject(data);
                StorageFolder folder2 = Windows.Storage.ApplicationData.Current.LocalFolder;
                StorageFile sampleFile2 =
                await folder.CreateFileAsync("data.txt", CreationCollisionOption.ReplaceExisting);
                await Windows.Storage.FileIO.WriteTextAsync(sampleFile2,lol123);
                
            }

            catch(Exception e) 
            {
                MainFragment.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                ListFragment.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                TitleBar.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                Error.Visibility = Windows.UI.Xaml.Visibility.Visible;
                ErrorBlock.Text="This app is made for Indraprasth University, Delhi, India students only! Either enter a valid roll no as provided by the university or check your internet connection. If problem persists kindly contact the developer";
                exc = e.Message;
            }
             
            //TextBlock total = new TextBlock();
            //total.Text = "Total Marks";
             
        }
        private void DrawerIcon_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (DrawerLayout.IsDrawerOpen)
                DrawerLayout.CloseDrawer();
            else
                DrawerLayout.OpenDrawer();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                onLaunch();
                Windows.Phone.UI.Input.HardwareButtons.BackPressed += HardwareButtons_BackPressed;
            }
            catch(Exception ex)
            {
                MainFragment.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                ListFragment.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                TitleBar.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                Error.Visibility = Windows.UI.Xaml.Visibility.Visible;
                ErrorBlock.Text = ex.Message;
                

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            EmailRecipient sendTo = new EmailRecipient()
            {
                Name = "Developer",
                Address = "axejulius@outlook.com"
            };

            // Create email object
            EmailMessage mail = new EmailMessage();
            mail.Subject = "Error in app Hackr Marks";
            mail.Body = exc+"\n what prompted this kindly explain along with your phone model. Thank you\n";

            // Add recipients to the mail object
            mail.To.Add(sendTo);
            //mail.Bcc.Add(sendTo);
            //mail.CC.Add(sendTo);

            // Open the share contract with Mail only:
            await EmailManager.ShowComposeNewEmailAsync(mail);
        }  
    }
}
