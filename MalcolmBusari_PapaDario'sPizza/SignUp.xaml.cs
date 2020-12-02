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
    public sealed partial class SignUp : Page
    {
        public SignUp()
        {
            this.InitializeComponent();
        }

        private void homeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void orderBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(OrderPage));
        }

        private void dealsBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Deals));
        }

        private void aboutBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(About));
        }

        private void reviewBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Review));
        }

        private void signInBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SignIn));
        }

        private async void createAccBtn_Click(object sender, RoutedEventArgs e)
        {
            if(password1.Password != password2.Password)
            {
                var messageDialog = new MessageDialog("Failed to create an account. Passwords do not match.");
                messageDialog.Commands.Add(new UICommand("OK")
                {
                    Id = 0
                });
                messageDialog.Commands.Add(new UICommand("Exit")
                {
                    Id = 1
                });
                messageDialog.DefaultCommandIndex = 0;
                messageDialog.CancelCommandIndex = 1;
                await messageDialog.ShowAsync();
            }
            else
            {
                Customer c = new Customer();
                c.AddCustomer((App.Current as App).ConnectionString3, fName.Text, lName.Text, email.Text, phoneNo.Text, password1.Password);

                var messageDialog = new MessageDialog("Successfully created an account!");
                messageDialog.Commands.Add(new UICommand("OK")
                {
                    Id = 0
                });
                messageDialog.DefaultCommandIndex = 0;
                await messageDialog.ShowAsync();
            }

        }

        }
    }
