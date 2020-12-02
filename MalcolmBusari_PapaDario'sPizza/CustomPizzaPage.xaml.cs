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
    public sealed partial class CustomPizzaPage : Page
    {
        Pizza p = new Pizza();
        OrderPage order = new OrderPage();
        public CustomPizzaPage()
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void cartBtn_Click(object sender, RoutedEventArgs e)
        {
            double subTotal = 0;

            if (cmbBox1.SelectedIndex == 0)
            {
                subTotal += 8.99;
            }
            else if (cmbBox1.SelectedIndex == 1)
            {
                subTotal += 12.99;
            }
            else if (cmbBox1.SelectedIndex == 2)
            {
                subTotal += 16.99;
            }
            else
            {
                subTotal += 0.00;
            }

            if (topping1.IsChecked == true)
            {
                subTotal += 1.00;
            }
            else
            {
                subTotal += 0.00;
            }

            if (topping2.IsChecked == true)
            {
                subTotal += 1.50;
            }
            else
            {
                subTotal += 0.00;
            }

            if (topping3.IsChecked == true)
            {
                subTotal += 2.00;
            }
            else
            {
                subTotal += 0.00;
            }

            if (topping4.IsChecked == true)
            {
                subTotal += 1.00;
            }
            else
            {
                subTotal += 0.00;
            }

            if (topping5.IsChecked == true)
            {
                subTotal += 1.50;
            }
            else
            {
                subTotal += 0.00;
            }

            if (topping6.IsChecked == true)
            {
                subTotal += 0.50;
            }
            else
            {
                subTotal += 0.00;
            }

            if (topping7.IsChecked == true)
            {
                subTotal += 0.50;
            }
            else
            {
                subTotal += 0.00;
            }

            if (topping8.IsChecked == true)
            {
                subTotal += 0.50;
            }
            else
            {
                subTotal += 0.00;
            }

            if (topping9.IsChecked == true)
            {
                subTotal += 0.50;
            }
            else
            {
                subTotal += 0.00;
            }

            if (topping10.IsChecked == true)
            {
                subTotal += 0.50;
            }
            else
            {
                subTotal += 0.00;
            }
            if (topping11.IsChecked == true)
            {
                subTotal += 0.50;
            }
            else
            {
                subTotal += 0.00;
            }
            if (topping12.IsChecked == true)
            {
                subTotal += 0.75;
            }
            else
            {
                subTotal += 0.00;
            }
            if (topping13.IsChecked == true)
            {
                subTotal += 0.75;
            }
            else
            {
                subTotal += 0.00;
            }

            if (topping14.IsChecked == true)
            {
                subTotal += 0.75;
            }
            else
            {
                subTotal += 0.00;
            }

            if (topping15.IsChecked == true)
            {
                subTotal += 0.75;
            }
            else
            {
                subTotal += 0.00;
            }

 

            subTotalTxtBox.Text = subTotal.ToString();
        }

        private void addCartBtn_Click(object sender, RoutedEventArgs e)
        {
            p.DeleteTable((App.Current as App).ConnectionString3);
            p.AddPizza((App.Current as App).ConnectionString3, "Custom Pizza", Double.Parse(subTotalTxtBox.Text), ((ComboBoxItem)cmbBox1.SelectedItem).Content.ToString(), 1, order.OrderNo);
        }

        private void cartBtn_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Cart));
        }
    }
    }
