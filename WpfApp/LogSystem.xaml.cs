using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp.src;

namespace WpfApp
{

    public partial class LogSystem : Window
    {
        public String cash;
        public LogSystem()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=KARHU\SQLEXPRESS; Initial Catalog = LoginDB; Integrated Security=True;");
            try
            {
                if(sqlConnection.State == System.Data.ConnectionState.Closed)
                {
                    sqlConnection.Open();
                    String query = "SELECT COUNT(1) FROM TableUser WHERE UserName=@UserName AND Password=@Password";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.Parameters.AddWithValue("@UserName", txtUsername.Text);
                    sqlCommand.Parameters.AddWithValue("@Password", txtPassword.Password);
                    int count = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    if(count == 1)
                    {
                        String queryCash = "SELECT UserCash FROM TableUser";
                        SqlCommand sqlCommandCash = new SqlCommand(queryCash, sqlConnection);
                        using (SqlDataReader reader = sqlCommandCash.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cash = (reader["UserCash"].ToString());
                            }
                        }

                        MainWindow dashboard = new MainWindow();
                        Payment payment = new Payment();
                        payment._store = Convert.ToDouble(cash);
                        dashboard.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Username or Passwrord is incorrect");
                    }
                }
            }
            catch (Exception exeption)
            {
                MessageBox.Show(exeption.Message);
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }

        }
    }
}
