using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
//using Windows.UI.Popups;
//using Windows.UI.Xaml;
//using Windows.UI.Xaml.Controls;

namespace MalcolmBusari_PapaDario_sPizza
{
    class Pizza : Item, INotifyPropertyChanged
    {

        //private string name;
        //private double price;
        //private string size;
        //private int quantity;
        //List<Pizza> pizzas = new List<Pizza>();
        //public List<Pizza> Pizzas
        //{
        //    get { return pizzas; }
        //}
        public int PizzaID { get; set; }
        public string PizzaCode { get { return PizzaID.ToString(); } }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
        public int OrderNo { get; set; }
        public string OrderCode { get { return OrderNo.ToString(); } }

        public PropertyChangedEventHandler PropertyChanged;

        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddPizza(string connectionString, string pName, double price, string size, int quantity, int orderNo)
        {
            const string AddPizzaQuery = "INSERT INTO Pizzas(PizzaName,Price,Size,Quantity,OrderNumber)" +
                "values(@PizzaName, @Price, @Size, @Quantity, @OrderNumber)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.Parameters.AddWithValue("PizzaName", pName);
                        cmd.Parameters.AddWithValue("Price", price);
                        cmd.Parameters.AddWithValue("Size", size);
                        cmd.Parameters.AddWithValue("Quantity", quantity);
                        cmd.Parameters.AddWithValue("OrderNumber", orderNo);
                        cmd.CommandText = AddPizzaQuery;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public override void DeleteTable(string connectionString)
        {
            string DeletePizzaQuery = "DELETE FROM Pizzas";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = DeletePizzaQuery;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public ObservableCollection<Pizza> GetPizzas(string connectionString)
        {
            const string GetPizzasQuery = "select * from Pizzas";
            var pizzas = new ObservableCollection<Pizza>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = GetPizzasQuery;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var pizza = new Pizza();
                                    pizza.PizzaID = reader.GetInt32(0);
                                    pizza.Name = reader.GetString(1);
                                    pizza.Price = reader.GetInt32(2);
                                    pizza.Size = reader.GetString(3);
                                    pizza.Quantity = reader.GetInt32(4);
                                    pizza.OrderNo = reader.GetInt32(5);
                                    pizzas.Add(pizza);
                                }
                            }

                        }
                    }
                }
                return pizzas;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return null;
        }

        //public Pizza(string name, double price, string size, int quantity)
        //{
        //    this.name = name;
        //    this.price = price;
        //    this.size = size;
        //    this.quantity = quantity;
        //}

        //public Pizza()
        //{
        //}

        //public override void AddToList(string name, double price, string size, int quantity)
        //{
        //    Pizza pizza = new Pizza();
        //    pizza.Name = name;
        //    pizza.Price = price;
        //    pizza.Size = size;
        //    pizza.Quantity = quantity;
        //    pizzas.Add(pizza);
        //}

        //    public async void IfValidAddToList(string quantityText, double price, TextBox txtBox, ComboBox cmbBox)
        //    {
        //        int quantity;
        //        double pricePerUnit;
        //        if (String.IsNullOrEmpty(quantityText) || (String.IsNullOrWhiteSpace(quantityText)))
        //        {
        //            quantity = 1;
        //            pricePerUnit = price;
        //            AddToList(txtBox.Text, pricePerUnit, cmbBox.SelectedValue.ToString(), quantity);
        //        }
        //        else
        //        {
        //            try
        //            {
        //                quantity = Int32.Parse(quantityText);
        //                pricePerUnit = price;
        //                AddToList(txtBox.Text, pricePerUnit, cmbBox.SelectedValue.ToString(), quantity);
        //            }
        //            catch (Exception)
        //            {
        //                var messageDialog = new MessageDialog("Enter a valid quantity");
        //                messageDialog.Commands.Add(new UICommand("OK")
        //                {
        //                    Id = 0
        //                });
        //                messageDialog.Commands.Add(new UICommand("Exit")
        //                {
        //                    Id = 1
        //                });
        //                messageDialog.DefaultCommandIndex = 0;
        //                messageDialog.CancelCommandIndex = 1;
        //                await messageDialog.ShowAsync();
        //            }
        //        }
        //    }

        //    public void writeToTxtFile()
        //    {
        //        try
        //        {

        //            StreamWriter sw = new StreamWriter(@"..\..\cart.txt");
        //            foreach (var pizza in Pizzas)
        //            {
        //                sw.WriteLine(string.Format("{0}/n Price: {1}/n Size: {2}", pizza.name, pizza.price.ToString(), pizza.size));
        //            }
        //            sw.Close();
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine("Exception: " + e.Message);
        //        }
        //        finally
        //        {
        //            Console.WriteLine("Executing finally block.");
        //        }

        //        //string file = @"..\cart.txt";
        //        //    if (!File.Exists(file))
        //        //    {
        //        //        using (StreamWriter sw = File.CreateText(file))
        //        //        {
        //        //            foreach (var item in Pizzas)
        //        //            {
        //        //                sw.WriteLine(string.Format("{0}/n Price: {1}/n Size: {2}", item.name, item.price.ToString(), item.size));
        //        //            }
        //        //        }
        //        //    }
        //        //    else
        //        //    {
        //        //        using (StreamWriter sw = File.AppendText(file))
        //        //        {
        //        //            foreach (var item in Pizzas)
        //        //            {
        //        //                sw.WriteLine(string.Format("{0}/n Price: {1}/n Size: {2}", item.name, item.price.ToString(), item.size));
        //        //            }
        //        //        }
        //    }

        //}
    }
}
