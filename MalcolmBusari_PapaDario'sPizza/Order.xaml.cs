using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Services.Store;
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
    public sealed partial class OrderPage : Page
    {
        Pizza p = new Pizza();
        Sides s = new Sides();
        int orderNo = Item.generateOrderNumber();

        public int OrderNo
        {
            get
            {
                return orderNo;
            }
        }

        public OrderPage()
        {
            p.DeleteTable((App.Current as App).ConnectionString3);
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

        private void createPizzaBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CustomPizzaPage));
        }

        private async void addToCartBtn1_Click(object sender, RoutedEventArgs e)
        {
            if (cmbBox1.SelectedItem == null)
            {
                var messageDialog = new MessageDialog("You must select a size");
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
                switch (cmbBox1.SelectedIndex)
                {
                    case 0:
                        p.AddPizza((App.Current as App).ConnectionString3, pizzaName1.Text, 14.99, ((ComboBoxItem)cmbBox1.SelectedItem).Content.ToString(), Int32.Parse(quantity1.Text), orderNo);
                        break;
                    case 1:
                        p.AddPizza((App.Current as App).ConnectionString3, pizzaName1.Text, 18.99, ((ComboBoxItem)cmbBox1.SelectedItem).Content.ToString(), Int32.Parse(quantity1.Text), orderNo);
                        break;
                    case 2:
                        p.AddPizza((App.Current as App).ConnectionString3, pizzaName1.Text, 22.99, ((ComboBoxItem)cmbBox1.SelectedItem).Content.ToString(), Int32.Parse(quantity1.Text), orderNo);
                        break;
                }
            }
        }

            private async void addToCartBtn2_Click(object sender, RoutedEventArgs e)
            {
                if (cmbBox2.SelectedItem == null)
                {
                    var messageDialog = new MessageDialog("You must select a size");
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

                    switch (cmbBox2.SelectedIndex)
                    {
                        case 0:
                        p.AddPizza((App.Current as App).ConnectionString3, pizzaName2.Text, 9.99, ((ComboBoxItem)cmbBox2.SelectedItem).Content.ToString(), Int32.Parse(quantity2.Text), orderNo);
                        break;
                        case 1:
                        p.AddPizza((App.Current as App).ConnectionString3, pizzaName2.Text, 13.99, ((ComboBoxItem)cmbBox2.SelectedItem).Content.ToString(), Int32.Parse(quantity2.Text), orderNo);
                        break;
                        case 2:
                        p.AddPizza((App.Current as App).ConnectionString3, pizzaName2.Text, 17.99, ((ComboBoxItem)cmbBox2.SelectedItem).Content.ToString(), Int32.Parse(quantity2.Text), orderNo);
                            break;
                    }

                }
            }

            private async void addToCartBtn3_Click(object sender, RoutedEventArgs e)
            {
                if (cmbBox3.SelectedItem == null)
                {
                    var messageDialog = new MessageDialog("You must select a size");
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
                switch (cmbBox3.SelectedIndex)
                {

                    case 0:
                        p.AddPizza((App.Current as App).ConnectionString3, pizzaName3.Text, 14.99, ((ComboBoxItem)cmbBox3.SelectedItem).Content.ToString(), Int32.Parse(quantity3.Text), orderNo);
                        break;
                    case 1:
                        p.AddPizza((App.Current as App).ConnectionString3, pizzaName3.Text, 18.99, ((ComboBoxItem)cmbBox3.SelectedItem).Content.ToString(), Int32.Parse(quantity3.Text), orderNo);
                        break;
                    case 2:
                        p.AddPizza((App.Current as App).ConnectionString3, pizzaName3.Text, 22.99, ((ComboBoxItem)cmbBox3.SelectedItem).Content.ToString(), Int32.Parse(quantity3.Text), orderNo);
                        break;
                }

            }
        }

            private async void addToCartBtn4_Click(object sender, RoutedEventArgs e)
            {
                if (cmbBox4.SelectedItem == null)
                {
                    var messageDialog = new MessageDialog("You must select a size");
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
                switch (cmbBox4.SelectedIndex)
                {
                    case 0:
                        p.AddPizza((App.Current as App).ConnectionString3, pizzaName4.Text, 14.99, ((ComboBoxItem)cmbBox4.SelectedItem).Content.ToString(), Int32.Parse(quantity4.Text), orderNo);
                        break;
                    case 1:
                        p.AddPizza((App.Current as App).ConnectionString3, pizzaName4.Text, 18.99, ((ComboBoxItem)cmbBox4.SelectedItem).Content.ToString(), Int32.Parse(quantity4.Text), orderNo);
                        break;
                    case 2:
                        p.AddPizza((App.Current as App).ConnectionString3, pizzaName4.Text, 22.99, ((ComboBoxItem)cmbBox4.SelectedItem).Content.ToString(), Int32.Parse(quantity4.Text), orderNo);
                        break;
                }

            }
        }

            private async void addToCartBtn5_Click(object sender, RoutedEventArgs e)
            {
                if (cmbBox5.SelectedItem == null)
                {
                    var messageDialog = new MessageDialog("You must select a size");
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
                switch (cmbBox5.SelectedIndex)
                {
                    case 0:
                        p.AddPizza((App.Current as App).ConnectionString3, pizzaName5.Text, 14.99, ((ComboBoxItem)cmbBox5.SelectedItem).Content.ToString(), Int32.Parse(quantity5.Text), orderNo);
                        break;
                    case 1:
                        p.AddPizza((App.Current as App).ConnectionString3, pizzaName3.Text, 18.99, ((ComboBoxItem)cmbBox5.SelectedItem).Content.ToString(), Int32.Parse(quantity5.Text), orderNo);
                        break;
                    case 2:
                        p.AddPizza((App.Current as App).ConnectionString3, pizzaName5.Text, 22.99, ((ComboBoxItem)cmbBox5.SelectedItem).Content.ToString(), Int32.Parse(quantity5.Text), orderNo);
                        break;
                }

            }
            }

            private async void addToCartBtn6_Click(object sender, RoutedEventArgs e)
            {
                if (cmbBox6.SelectedItem == null)
                {
                    var messageDialog = new MessageDialog("You must select a size");
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
                    switch (cmbBox6.SelectedIndex)
                    {
                    case 0:
                        p.AddPizza((App.Current as App).ConnectionString3, pizzaName6.Text, 14.99, ((ComboBoxItem)cmbBox6.SelectedItem).Content.ToString(), Int32.Parse(quantity6.Text), orderNo);
                        break;
                    case 1:
                        p.AddPizza((App.Current as App).ConnectionString3, pizzaName6.Text, 18.99, ((ComboBoxItem)cmbBox6.SelectedItem).Content.ToString(), Int32.Parse(quantity6.Text), orderNo);
                        break;
                    case 2:
                        p.AddPizza((App.Current as App).ConnectionString3, pizzaName6.Text, 22.99, ((ComboBoxItem)cmbBox6.SelectedItem).Content.ToString(), Int32.Parse(quantity6.Text), orderNo);
                        break;
                }

                }
            }

            private async void addToCartBtn7_Click(object sender, RoutedEventArgs e)
            {
                if (cmbBox7.SelectedItem == null)
                {
                    var messageDialog = new MessageDialog("You must select a size");
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
                switch (cmbBox7.SelectedIndex)
                {
                    case 0:
                        s.AddSides((App.Current as App).ConnectionString3, sideName1.Text, 7.99, 
                            ((ComboBoxItem)cmbBoxSauce1.SelectedItem).Content.ToString(), ((ComboBoxItem)cmbBox7.SelectedItem).Content.ToString(), orderNo);
                        break;
                    case 1:
                        s.AddSides((App.Current as App).ConnectionString3, sideName1.Text, 10.99,
    ((ComboBoxItem)cmbBoxSauce1.SelectedItem).Content.ToString(), ((ComboBoxItem)cmbBox7.SelectedItem).Content.ToString(), orderNo);
                        break;
                }

            }
            }

            private async void addToCartBtn8_Click(object sender, RoutedEventArgs e)
            {
                if (cmbBox8.SelectedItem == null)
                {
                    var messageDialog = new MessageDialog("You must select a size");
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
                switch (cmbBox8.SelectedIndex)
                {
                    case 0:
                        s.AddSides((App.Current as App).ConnectionString3, sideName2.Text, 5.99,
                            ((ComboBoxItem)cmbBoxSauce2.SelectedItem).Content.ToString(), ((ComboBoxItem)cmbBox8.SelectedItem).Content.ToString(), orderNo);
                        break;
                    case 1:
                        s.AddSides((App.Current as App).ConnectionString3, sideName1.Text, 8.99,
                            ((ComboBoxItem)cmbBoxSauce2.SelectedItem).Content.ToString(), ((ComboBoxItem)cmbBox8.SelectedItem).Content.ToString(), orderNo);
                        break;
                }

            }
            }

            private async void addToCartBtn9_Click(object sender, RoutedEventArgs e)
            {
                if (cmbBox9.SelectedItem == null)
                {
                    var messageDialog = new MessageDialog("You must select a size");
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
                switch (cmbBox9.SelectedIndex)
                {
                    case 0:
                        s.AddSides((App.Current as App).ConnectionString3, sideName3.Text, 4.99, "", ((ComboBoxItem)cmbBox9.SelectedItem).Content.ToString(), orderNo);
                        break;
                    case 1:
                        s.AddSides((App.Current as App).ConnectionString3, sideName3.Text, 7.99, "", ((ComboBoxItem)cmbBox9.SelectedItem).Content.ToString(), orderNo);
                        break;
                }

            }
        }

            private void cartBtn_Click(object sender, RoutedEventArgs e)
            {
                //p.writeToTxtFile();

            }

        private void cartBtn_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Cart));
        }
    }
    }
    