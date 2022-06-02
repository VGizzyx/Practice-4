using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;

namespace WcfService1
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public List<Customer> GetCustomers()
        {
           List<Customer> list = new List<Customer>();
            string str = System.Configuration.ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(str))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM CUSTOMERS", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Customer client = new Customer();
                    client.Id = (int)reader["Id"];
                    client.Name = reader["Name"].ToString();
                    client.Surname = reader["Surname"].ToString();
                    client.YearOfBirth = (int)reader["YearOfBirth"];
                    list.Add(client);
                }
            }
            return list;
        }

        public List<Order> GetOrders(int IdClient)
        {
            List<Order> list = new List<Order>();
            string str = System.Configuration.ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(str))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM ORDERS WHERE idCust=@Id", connection);
                command.Parameters.Add(new SqlParameter("@Id", IdClient));
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Order order = new Order();
                    order.Id = (int)reader["Id"];
                    order.Title = reader["Title"].ToString();
                    order.idCust = (int)reader["IdCust"];
                    order.Price = (int)reader["Price"];
                    order.Quant = (int)reader["Quant"];
                    list.Add(order);
                }
            }
            return list;
        }
    }
}
