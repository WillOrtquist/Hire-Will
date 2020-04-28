using SampleApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.DAL
{
    /// <summary>
    /// An interface for cake objects.
    /// </summary>
    public class OrderSqlDAO : IOrderDAO
    {
        private readonly string connectionString;

        
        /// <summary>
        /// Creates a new sql dao for order objects.
        /// </summary>
        /// <param name="connectionString">the database connection string</param>
        public OrderSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        
        /// <summary>
        /// Returns a list of all orders in the database
        /// </summary>
        public List<Order> GetAllOrders()
        {

            List<Order> listOfOrders = new List<Order>();

            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    string sql = $"SELECT * FROM orders ORDER BY pickup_datetime";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {

                        Order order = new Order();
                        Cake orderCake = new Cake();

                        orderCake.name = Convert.ToString(reader["cake_name"]);
                        orderCake.style = Convert.ToString(reader["style"]);
                        orderCake.size = Convert.ToString(reader["size"]);
                        orderCake.flavor = Convert.ToString(reader["flavor"]);
                        orderCake.frosting = Convert.ToString(reader["frosting"]);
                        orderCake.filling = Convert.ToString(reader["filling"]);
                        orderCake.price = (Convert.ToDouble(reader["order_total"]) / (Double)Convert.ToInt32(reader["cake_quantity"]));
                        order.cake = orderCake;

                        order.orderId = Convert.ToInt32(reader["order_id"]);
                        order.quantity = Convert.ToInt32(reader["cake_quantity"]);
                        order.orderStatus = Convert.ToString(reader["order_status"]);
                        order.customerName = Convert.ToString(reader["customer_name"]);
                        order.phoneNumber = Convert.ToString(reader["phone_number"]);
                        order.email = Convert.ToString(reader["email"]);
                        order.writingOnCake = Convert.ToString(reader["cake_message"]);
                        order.date = Convert.ToDateTime(reader["pickup_datetime"]).ToString("d");
                        order.time = Convert.ToDateTime(reader["pickup_datetime"]).ToString("hh:mm tt");

                        listOfOrders.Add(order);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return listOfOrders;
        }

        /// <summary>
        /// Saves the user to the database.
        /// </summary>
        /// <param name="cake">cake being added</param>
        public int AddOrder(Order order)
        {
            int id = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO orders (cake_name, cake_quantity, style, size, flavor, frosting, filling, cake_message, order_total, order_status, customer_name, phone_number, email, pickup_datetime) VALUES (@cakeName, @quantity, @style, @size, @flavor, @frosting, @filling, @writingOnCake, @orderTotal, @orderStatus, @customerName, @phoneNumber, @email, @pickup_datetime);", conn);

                    cmd.Parameters.AddWithValue("@cakeName", order.cake.name);
                    cmd.Parameters.AddWithValue("@quantity", order.quantity);
                    cmd.Parameters.AddWithValue("@style", order.cake.style);
                    cmd.Parameters.AddWithValue("@size", order.cake.size);
                    cmd.Parameters.AddWithValue("@flavor", order.cake.flavor);
                    cmd.Parameters.AddWithValue("@frosting", order.cake.frosting);
                    cmd.Parameters.AddWithValue("@filling", order.cake.filling);
                    cmd.Parameters.AddWithValue("@orderTotal", order.orderTotal);
                    cmd.Parameters.AddWithValue("@orderStatus", order.orderStatus);
                    cmd.Parameters.AddWithValue("@customerName", order.customerName);
                    cmd.Parameters.AddWithValue("@phoneNumber", order.phoneNumber);
                    cmd.Parameters.AddWithValue("@email", order.email);
                    cmd.Parameters.AddWithValue("@writingOnCake", order.writingOnCake);
                    cmd.Parameters.AddWithValue("@pickup_datetime", order.pickupDateTime);

                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("SELECT order_id FROM orders WHERE order_id = @@Identity;", conn);
                    id = Convert.ToInt32(cmd.ExecuteScalar());

                }
            }
            catch (SqlException ex)
            {
                
            }
            return id;
        }
        public bool UpdateOrderStatus(Order order)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE orders SET order_status = @status WHERE order_id = @id;", conn);
                    cmd.Parameters.AddWithValue("@id", order.orderId);
                    cmd.Parameters.AddWithValue("@status", order.orderStatus);

                    cmd.ExecuteNonQuery();


                }
            }
            catch (SqlException ex)
            {

                return false;
            }
            return true;
        }

        public Order GetOrder(int id)
        {
            return GetAllOrders().FirstOrDefault(o => o.orderId == id);
        }

    }
}
