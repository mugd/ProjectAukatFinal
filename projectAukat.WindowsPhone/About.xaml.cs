using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class About : Page
    {
        public About()
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

            Windows.Phone.UI.Input.HardwareButtons.BackPressed += HardwareButtons_BackPressed;
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
                Application.Current.Exit();
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
    }
}
