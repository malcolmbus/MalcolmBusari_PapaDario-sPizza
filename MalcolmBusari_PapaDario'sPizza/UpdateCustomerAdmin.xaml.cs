using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
    public sealed partial class UpdateCustomerAdmin : Page
    {
        public UpdateCustomerAdmin()
        {
            this.InitializeComponent();
        }

        private void homeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPageAdmin));
        }

        private void custBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ViewCustomersAdmin));
        }

        private void addDelcustBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddCustomerAdmin));
        }

        private void upcustBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(UpdateCustomerAdmin));
        }

        private void feedBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ViewFeedbackAdmin));
        }

        private void signOutBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private async void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            Customer c = new Customer();
            c.UpdateCustomerByID((App.Current as App).ConnectionString, Int32.Parse(custID.Text), fName.Text, lName.Text, email.Text, phoneNo.Text, password.Text);
            var messageDialog = new MessageDialog("Successfully updated customer with ID " + custID.Text);
            messageDialog.Commands.Add(new UICommand("OK")
            {
                Id = 0
            });
            messageDialog.DefaultCommandIndex = 0;
            await messageDialog.ShowAsync();
        }
    }
    }
