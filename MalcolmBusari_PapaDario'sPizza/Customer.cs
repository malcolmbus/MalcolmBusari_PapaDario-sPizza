using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalcolmBusari_PapaDario_sPizza
{
    class Customer:INotifyPropertyChanged
    {
        public int CustomerID { get; set; }
        public string CustomerCode { get { return CustomerID.ToString(); } }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CustPassword { get; set; }

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

        public void AddCustomer(string connectionString, string fName, string lName, string email, string phoneNo, string password)
        {
            const string AddCustomerQuery = "INSERT INTO Customers(FirstName,LastName,Email,PhoneNumber,CustPassword)" +
                "values(@FirstName, @LastName, @Email, @PhoneNumber, @CustPassword)";

            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                if(conn.State == System.Data.ConnectionState.Open)
                {
                    using(SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.Parameters.AddWithValue("FirstName", fName);
                        cmd.Parameters.AddWithValue("LastName", lName);
                        cmd.Parameters.AddWithValue("Email", email);
                        cmd.Parameters.AddWithValue("PhoneNumber", phoneNo);
                        cmd.Parameters.AddWithValue("CustPassword", password);
                        cmd.CommandText = AddCustomerQuery;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public void AddReview(string connectionString, string fName, string lName, string email, string review)
        {
            const string AddCustomerQuery = "INSERT INTO Reviews(FirstName,LastName,Email,Review)" +
                "values(@FirstName, @LastName, @Email, @Review)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.Parameters.AddWithValue("FirstName", fName);
                        cmd.Parameters.AddWithValue("LastName", lName);
                        cmd.Parameters.AddWithValue("Email", email);
                        cmd.Parameters.AddWithValue("Review", review);
                        cmd.CommandText = AddCustomerQuery;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public void DeleteCustomerByID(string connectionString, int id)
        {
            string DeleteCustomerIDQuery = "DELETE FROM Customers WHERE CustomerID=@CustomerID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.Parameters.AddWithValue("CustomerID", id);
                        cmd.CommandText = DeleteCustomerIDQuery;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public void DeleteCustomerByName(string connectionString, string fName, string lName)
        {
            string DeleteCustomerNameQuery = "DELETE FROM Customers WHERE FirstName=@FirstName AND LastName=@LastName";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.Parameters.AddWithValue("FirstName", fName);
                        cmd.Parameters.AddWithValue("LastName", lName);
                        cmd.CommandText = DeleteCustomerNameQuery;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public void UpdateCustomerByID(string connectionString, int id, string fName, string lName, string email, string phoneNo, string password)
        {
            string UpdateCustomerQuery = "UPDATE Customers SET FirstName=@FirstName, LastName=@LastName, Email=@Email, PhoneNumber=@PhoneNumber, CustPassword=@CustPassword " +
                "WHERE CustomerID=@CustomerID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.Parameters.AddWithValue("FirstName", fName);
                        cmd.Parameters.AddWithValue("LastName", lName);
                        cmd.Parameters.AddWithValue("Email", email);
                        cmd.Parameters.AddWithValue("PhoneNumber", phoneNo);
                        cmd.Parameters.AddWithValue("CustPassword", password);
                        cmd.Parameters.AddWithValue("CustomerID", id);
                        cmd.CommandText = UpdateCustomerQuery;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public ObservableCollection<Customer> GetCustomers(string connectionString)
        {
            const string GetCustomersQuery = "select * from Customers";
            var customers = new ObservableCollection<Customer>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = GetCustomersQuery;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var customer = new Customer();
                                    customer.CustomerID = reader.GetInt32(0);
                                    customer.FirstName = reader.GetString(1);
                                    customer.LastName = reader.GetString(2);
                                    customer.Email = reader.GetString(3);
                                    customer.PhoneNumber = reader.GetString(4);
                                    customer.CustPassword = reader.GetString(5);
                                    customers.Add(customer);
                                }
                            }

                        }
                    }
                }
                return customers;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return null;
        }

    }
}
