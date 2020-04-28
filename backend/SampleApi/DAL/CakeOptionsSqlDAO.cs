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
    public class CakeOptionsSqlDAO : ICakeOptionsDAO
    {
        private readonly string connectionString;

        
        /// <summary>
        /// Creates a new sql dao for cake options.
        /// </summary>
        /// <param name="connectionString">the database connection string</param>
        public CakeOptionsSqlDAO(string connectionString)

        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Returns a list of all Cake Styles
        /// </summary>
        public List<Styles> GetAllCakeStyles()
        {

            List<Styles> listOfStyles = new List<Styles>();

            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    string sql = $"SELECT * FROM styles";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {
                    
                        Styles style = new Styles();
                        style.id = Convert.ToInt32(reader["id"]);
                        style.style = Convert.ToString(reader["style"]);
                        style.price = Convert.ToDouble(reader["price"]);
                        style.isAvailable = Convert.ToBoolean(reader["available"]);

                        listOfStyles.Add(style);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return listOfStyles;
        }

        /// <summary>
        /// Adds a style option to our database so that a customer can order it from the drop down menu
        /// </summary>
        /// <param name="newStyle">the style being added is passed in</param>
        /// <returns></returns>
        public bool AddStyleOption(Styles newStyle)
        {
            int newStyleId = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO styles (available, style, price) VALUES (@available, @style, @price);", conn);

            
                    cmd.Parameters.AddWithValue("@available", newStyle.isAvailable);
                    cmd.Parameters.AddWithValue("@style", newStyle.style);
                    cmd.Parameters.AddWithValue("@price", newStyle.price);
                
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("SELECT id FROM styles WHERE id = @@Identity;", conn);
                    newStyleId = Convert.ToInt32(cmd.ExecuteScalar());

                    SqlCommand cmd2 = new SqlCommand("INSERT INTO style_size (style_id, size_id) VALUES (@id, @sizeId);", conn);

                    cmd2.Parameters.AddWithValue("@id", newStyleId);
                    cmd2.Parameters.AddWithValue("@sizeId", newStyle.sizeId);
                    

                    cmd2.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {

                return false;
            }
            return true;
        }

        public bool UpdateStyleAvailability(Styles updatedStyle)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE styles SET available = @available WHERE id = @id;", conn);
                    cmd.Parameters.AddWithValue("@id", updatedStyle.id);
                    cmd.Parameters.AddWithValue("@available", updatedStyle.isAvailable);

                    cmd.ExecuteNonQuery();


                }
            }
            catch (SqlException ex)
            {

                return false;
            }
            return true;
        }

        /// <summary>
        /// Following three methods are for getting, adding, updating size options
        /// </summary>
        /// <returns></returns>
        public List<Sizes> GetAllCakeSizes()
        {

            List<Sizes> listOfSizes = new List<Sizes>();

            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    string sql = $"SELECT sizes.id, size, ISNULL(base_price,0) AS base_price, ISNULL(sizes.available,0) AS available, ISNULL(style_id,0) AS style_id from sizes LEFT JOIN style_size ON sizes.id = style_size.size_id LEFT JOIN styles ON styles.id = style_size.style_id";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {

                        Sizes size = new Sizes();
                        size.id = Convert.ToInt32(reader["id"]);
                        size.size = Convert.ToString(reader["size"]);
                        size.basePrice = Convert.ToDouble(reader["base_price"]);
                        size.isAvailable = Convert.ToBoolean(reader["available"]);
                        size.styleId = Convert.ToInt32(reader["style_id"]);

                        listOfSizes.Add(size);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return listOfSizes;
        }

        public List<Sizes> GetAllCakeSizesFiltered(int styId)
        {

            List<Sizes> listOfSizes = new List<Sizes>();

            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();
                    
                    string sql = $"SELECT sizes.id, size, ISNULL(base_price,0) AS base_price, ISNULL(sizes.available,0) AS available, ISNULL(style_id,0) AS style_id from sizes LEFT JOIN style_size ON sizes.id = style_size.size_id AND style_size.style_id=@styId LEFT JOIN styles ON styles.id = style_size.style_id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@styId", styId);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {

                        Sizes size = new Sizes();
                        size.id = Convert.ToInt32(reader["id"]);
                        size.size = Convert.ToString(reader["size"]);
                        size.basePrice = Convert.ToDouble(reader["base_price"]);
                        size.isAvailable = Convert.ToBoolean(reader["available"]);
                        size.styleId = Convert.ToInt32(reader["style_id"]);

                        listOfSizes.Add(size);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return listOfSizes;
        }

        public bool AddSizeOption(Sizes newSize)
        {
            int newId = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO sizes (available, size, base_price) VALUES (@available, @size, @base_price);", conn);

                    cmd.Parameters.AddWithValue("@available", newSize.isAvailable);
                    cmd.Parameters.AddWithValue("@size", newSize.size);
                    cmd.Parameters.AddWithValue("@base_price", newSize.basePrice);

                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("SELECT id FROM sizes WHERE id = @@Identity;", conn);
                    newId = Convert.ToInt32(cmd.ExecuteScalar());

                    SqlCommand cmd2 = new SqlCommand("INSERT INTO style_size (style_id, size_id) VALUES (@styleId, @id);", conn);

                    cmd2.Parameters.AddWithValue("@styleId", newSize.styleId); 
                    cmd2.Parameters.AddWithValue("@id", newId);
                    
                    cmd2.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                return false;
            }
            return true;
        }

        public bool UpdateSizeAvailability(Sizes updatedSize)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE sizes SET available = @available WHERE id = @id;", conn);
                    cmd.Parameters.AddWithValue("@id", updatedSize.id);
                    cmd.Parameters.AddWithValue("@available", updatedSize.isAvailable);

                    cmd.ExecuteNonQuery();


                }
            }
            catch (SqlException ex)
            {

                return false;
            }
            return true;
        }

        public bool SizeRemove(Styles sizeRemove)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM style_size WHERE style_id = @styleId AND size_id = @sizeId;", conn);
                    cmd.Parameters.AddWithValue("@styleId", sizeRemove.id);
                    cmd.Parameters.AddWithValue("@sizeId", sizeRemove.sizeId);

                    cmd.ExecuteNonQuery();


                }
            }
            catch (SqlException ex)
            {

                return false;
            }
            return true;
        }

        public bool SizeAdd(Styles sizeAdd)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO style_size (style_id, size_id) VALUES (@styleId, @sizeId);", conn);
                    cmd.Parameters.AddWithValue("@styleId", sizeAdd.id);
                    cmd.Parameters.AddWithValue("@sizeId", sizeAdd.sizeId);

                    cmd.ExecuteNonQuery();


                }
            }
            catch (SqlException ex)
            {

                return false;
            }
            return true;
        }

        /// <summary>
        /// Following 3 methods are used for getting, adding, updating frosting options
        /// </summary>
        /// <returns></returns>
        public List<Frostings> GetAllCakeFrostings()
        {

            List<Frostings> listOfFrostings = new List<Frostings>();

            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    string sql = $"SELECT * FROM frostings";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {

                        Frostings frosting = new Frostings();
                        frosting.id = Convert.ToInt32(reader["id"]);
                        frosting.frosting = Convert.ToString(reader["frosting"]);
                        frosting.isAvailable = Convert.ToBoolean(reader["available"]);

                        listOfFrostings.Add(frosting);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return listOfFrostings;
        }


        public bool AddFrostingOption(Frostings newFrosting)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO frostings (available, frosting) VALUES (@available, @frosting);", conn);

                    cmd.Parameters.AddWithValue("@available", newFrosting.isAvailable);
                    cmd.Parameters.AddWithValue("@frosting", newFrosting.frosting);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                return false;
            }
            return true;
        }

        public bool UpdateFrostingAvailability(Frostings updatedFrosting)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE frostings SET available = @available WHERE id = @id;", conn);
                    cmd.Parameters.AddWithValue("@id", updatedFrosting.id);
                    cmd.Parameters.AddWithValue("@available", updatedFrosting.isAvailable);

                    cmd.ExecuteNonQuery();


                }
            }
            catch (SqlException ex)
            {

                return false;
            }
            return true;
        }

        /// <summary>
        /// Following 3 methods are used for adding, updating, getting flavor options
        /// </summary>
        /// <param name="updatedFlavor"></param>
        /// <returns></returns>
        public bool UpdateFlavorAvailability(Flavors updatedFlavor)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE flavors SET available = @available WHERE id = @id;", conn);
                    cmd.Parameters.AddWithValue("@id", updatedFlavor.id);
                    cmd.Parameters.AddWithValue("@available", updatedFlavor.isAvailable);

                    cmd.ExecuteNonQuery();


                }
            }
            catch (SqlException ex)
            {

                return false;
            }
            return true;
        }

        public List<Flavors> GetAllCakeFlavors()
        {

            List<Flavors> listOfFlavors = new List<Flavors>();

            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    string sql = $"SELECT * FROM flavors";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {

                        Flavors flavor = new Flavors();
                        flavor.id = Convert.ToInt32(reader["id"]);
                        flavor.flavor = Convert.ToString(reader["flavor"]);
                        flavor.isAvailable = Convert.ToBoolean(reader["available"]);

                        listOfFlavors.Add(flavor);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return listOfFlavors;
        }
        public bool AddFlavorOption(Flavors newFlavor)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO flavors (available, flavor) VALUES (@available, @flavor);", conn);

                    cmd.Parameters.AddWithValue("@available", newFlavor.isAvailable);
                    cmd.Parameters.AddWithValue("@flavor", newFlavor.flavor);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Following 3 methods are used for for adding, udpating, getting filling options
        /// </summary>
        /// <param name="newFilling"></param>
        /// <returns></returns>
        public bool AddFillingOption(Fillings newFilling)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO fillings (available, filling) VALUES (@available, @filling);", conn);

                    cmd.Parameters.AddWithValue("@available", newFilling.isAvailable);
                    cmd.Parameters.AddWithValue("@filling", newFilling.filling);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                return false;
            }
            return true;
        }

        public bool UpdateFillingAvailability(Fillings updatedFilling)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE fillings SET available = @available WHERE id = @id;", conn);
                    cmd.Parameters.AddWithValue("@id", updatedFilling.id);
                    cmd.Parameters.AddWithValue("@available", updatedFilling.isAvailable);

                    cmd.ExecuteNonQuery();


                }
            }
            catch (SqlException ex)
            {

                return false;
            }
            return true;
        }
        public List<Fillings> GetAllCakeFillings()
        {

            List<Fillings> listOfFillings = new List<Fillings>();

            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    string sql = $"SELECT * FROM fillings";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {

                        Fillings filling = new Fillings();
                        filling.id = Convert.ToInt32(reader["id"]);
                        filling.filling = Convert.ToString(reader["filling"]);
                        filling.isAvailable = Convert.ToBoolean(reader["available"]);

                        listOfFillings.Add(filling);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return listOfFillings;
        }


    }
}
