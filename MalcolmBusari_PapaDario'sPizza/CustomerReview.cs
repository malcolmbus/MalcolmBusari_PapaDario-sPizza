using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace MalcolmBusari_PapaDario_sPizza
{
    class CustomerReview : INotifyPropertyChanged
    {
        public int ReviewID { get; set; }
        public string ReviewCode { get { return ReviewID.ToString(); } }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Review { get; set; }

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

        public ObservableCollection<CustomerReview> GetReviews(string connectionString)
        {
            const string GetReviewsQuery = "select * from Reviews";
            var reviews= new ObservableCollection<CustomerReview>();
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if(conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = GetReviewsQuery;
                            using(SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var review  = new CustomerReview();
                                    review.ReviewID = reader.GetInt32(0);
                                    review.FirstName = reader.GetString(1);
                                    review.LastName = reader.GetString(2);
                                    review.Email = reader.GetString(3);
                                    review.Review = reader.GetString(4);
                                    reviews.Add(review);
                                }
                            }

                        }
                    }
                }
                return reviews;
            }catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return null;
        }

    }
}
