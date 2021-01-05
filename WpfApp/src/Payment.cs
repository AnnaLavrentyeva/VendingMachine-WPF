using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp.src
{
    public class Payment: Objects
    {
        private double _total;
        public double _inserted;
        public double _change;
        public double _store;
        public double a;

        public String cash;

        public double Total
        {
            get
            {
                return _total;
            }
            set
            {
                _total = value;
                OnPropertyChanged("Total");
            }
        }

        public double Inserted
        {
            get
            {
                return _inserted;
            }
            set
            {
                _inserted = value;
                OnPropertyChanged("Inserted");
            }
        }

        public double Change
        {

            get
            {
                return _change;
            }


            set
            {
                _change = value;
                OnPropertyChanged("Change");
            }
        }

        public double Store
        {
            get
            {
                return _store;
            }
            set
            {
                _store = value;
                OnPropertyChanged("Store");
            }
        }

        public void PaymentView()
        {
            Total = 0;
            Inserted = 0;
            Change = 0;
            Store = _store;
        }

        public void Insert(double money)
        {
            Inserted += money;
            Console.WriteLine(Store);
            Console.WriteLine(_store);
        }

        public void SelectedPrice(double price)
        {
            Total = price;
        }
        
        public bool Confirm()
        {
            if(Inserted >= Total)
            {
                return true;
            }
            return false;
        }

        public void Pay()
        {
            Change = Inserted - Total;
            Inserted = 0;
            Total = 0;
        }

        public void Collect()
        {
            MainWindow dashboard = new MainWindow();

            SqlConnection sqlConnection = new SqlConnection(@"Data Source=KARHU\SQLEXPRESS; Initial Catalog = LoginDB; Integrated Security=True;");
            sqlConnection.Open();
            String queryCash = "SELECT UserCash FROM TableUser";
            SqlCommand sqlCommandCash = new SqlCommand(queryCash, sqlConnection);
            using (SqlDataReader reader = sqlCommandCash.ExecuteReader())
            {
                while (reader.Read())
                {
                    cash = (reader["UserCash"].ToString());
                }
            }
            double a = Convert.ToDouble(cash);
            Store = a + Change;
                
            Change = 0;

            String queryCash2 = "UPDATE TableUser SET UserCash=@CashVal WHERE UserID=1;";
            SqlCommand sqlCommandCashBack = new SqlCommand(queryCash2, sqlConnection);
            sqlCommandCashBack.Parameters.AddWithValue("CashVal", Store);
            sqlCommandCashBack.ExecuteNonQuery();
        }
    }
}
