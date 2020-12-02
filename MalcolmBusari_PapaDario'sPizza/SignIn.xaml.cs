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
    public sealed partial class SignIn : Page
    {
        public SignIn()
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

        private void joinBtn_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SignUp));
        }

        private void email_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void password1_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }

        private async void logInBtn_Click(object sender, RoutedEventArgs e)
        {
            if(email.Text == "Dario2020" && password1.Password == "abcde")
            {
                this.Frame.Navigate(typeof(MainPageAdmin));
            }
            else if(email.Text == "malcolm@email.com" && password1.Password == "password")
            {
                this.Frame.Navigate(typeof(MainPageCustomer));
            }
            else if(email.Text == "customer2" && password1.Password == "56789")
            {
                this.Frame.Navigate(typeof(MainPageCustomer));
            }
            else
            {
                var messageDialog = new MessageDialog("Incorrect username or password");
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
        }
    }
}
