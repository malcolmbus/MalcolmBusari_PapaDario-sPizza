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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MalcolmBusari_PapaDario_sPizza
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OrderCustomer : Page
    {
        public OrderCustomer()
        {
            this.InitializeComponent();
        }

        private void signOutBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void homeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPageCustomer));
        }

        private void orderBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(OrderCustomer));
        }

        private void dealsBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(DealsCustomer));
        }

        private void aboutBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AboutCustomer));
        }

        private void reviewBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ReviewCustomer));
        }
    }
}
