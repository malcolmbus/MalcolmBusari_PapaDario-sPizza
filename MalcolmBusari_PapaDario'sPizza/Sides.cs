using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using System.Diagnostics;

namespace MalcolmBusari_PapaDario_sPizza
{
    class Sides: Item, INotifyPropertyChanged
    {
        //private string name;
        //private double price;
        //private string serving;
        public int SidesID { get; set; }
        public string SidesCode { get { return SidesID.ToString(); } }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Sauce { get; set; }
        public string Serving { get; set; }
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

        public void AddSides(string connectionString, string sName, double price, string sauce, string serving, int orderNo)
        {
            const string AddSideQuery = "INSERT INTO Sides(SideName,Price,Sauce,Serving,OrderNumber)" +
                "values(@SideName, @Price, @Sauce, @Serving, @OrderNumber)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.Parameters.AddWithValue("SideName", sName);
                        cmd.Parameters.AddWithValue("Price", price);
                        cmd.Parameters.AddWithValue("Sauce", sauce);
                        cmd.Parameters.AddWithValue("Serving", serving);
                        cmd.Parameters.AddWithValue("OrderNumber", orderNo);
                        cmd.CommandText = AddSideQuery;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public override void DeleteTable(string connectionString)
        {
            string DeleteSidesQuery = "DELETE FROM Sides";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = DeleteSidesQuery;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public ObservableCollection<Sides> GetSides(string connectionString)
        {
            const string GetSidesQuery = "select * from Sides";
            var sides = new ObservableCollection<Sides>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = GetSidesQuery;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var side = new Sides();
                                    side.SidesID = reader.GetInt32(0);
                                    side.Name = reader.GetString(1);
                                    side.Price = reader.GetInt32(2);
                                    side.Sauce = reader.GetString(3);
                                    side.Serving = reader.GetString(4);
                                    side.OrderNo = reader.GetInt32(5);
                                    sides.Add(side);
                                }
                            }

                        }
                    }
                }
                return sides;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return null;
        }

        //public Sides(string name, double price, string serving)
        //{
        //    this.name = name;
        //    this.price = price;
        //    this.serving = serving;
        //}

        //public override void AddToList(string name, double price, string serving, int quantity)
        //{
        //    Sides side = new Sides();
        //    side.Name = name;
        //    side.Price = price;
        //    side.Serving = serving;
        //    sideOrders.Add(side);
        //}

        //public void IfValidAddToList(double price, TextBox txtBox, ComboBox cmbBox)
        //{
        //    int quantity;
        //    double pricePerUnit;
        //    quantity = 1;
        //    pricePerUnit = price;
        //    AddToList(txtBox.Text, pricePerUnit,  cmbBox.SelectedValue.ToString(), quantity);
        //}

    }
}
