using Ado.net.Constants;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.net.Services
{
    internal static class CountryService
    {
        public static void GetAllCountries()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStrings.Default))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Countries", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["Id"]);
                        string name = Convert.ToString(reader["Name"]);
                        string area = Convert.ToString(reader["Area"]);

                        Console.WriteLine($"{id}, {name}, {area}");
                    }
                }
                connection.Close();
            }
        }
        public static void AddCountry()
        {
            Messages.InputMessage("country name");
            string name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
            {
                Messages.InputMessage("country area");
                string areaInput = Console.ReadLine();
                decimal area;
                bool isSucceded = decimal.TryParse(areaInput, out area);
                if (isSucceded)
                {

                    using (SqlConnection connection = new SqlConnection(ConnectionStrings.Default))
                    {
                        connection.Open();

                        var command = new SqlCommand("INSERT INTO Countries VALUES(@name, @area)", connection);
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@area", area);

                        try
                        {
                            var affectedRows = command.ExecuteNonQuery();
                            if (affectedRows > 0)
                            {
                                Messages.SuccessMessage();
                            }
                            else
                            {
                                Messages.ErrorOcuredMessage();
                            }
                        }

                        catch (Exception e)
                        {
                            Messages.ErrorOcuredMessage();
                        }
                    }
                }
                else
                    Messages.InvalidInputMessage("Country area");
            }
            else
            {
                Messages.InvalidInputMessage("Country Name");
            }


        }

        public static void UpdateCountry()
        {
            Messages.InputMessage("country ID");
            int id;
            if (int.TryParse(Console.ReadLine(), out id))
            {
                Messages.InputMessage("new country name");
                string name = Console.ReadLine();
                Messages.InputMessage("new country area");
                string areaInput = Console.ReadLine();
                decimal area;
                if (!string.IsNullOrWhiteSpace(name) && decimal.TryParse(areaInput, out area))
                {
                    using (SqlConnection connection = new SqlConnection(ConnectionStrings.Default))
                    {
                        connection.Open();
                        var command = new SqlCommand("UPDATE Countries SET Name = @name, Area = @area WHERE Id = @id", connection);
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@area", area);

                        try
                        {
                            var affectedRows = command.ExecuteNonQuery();
                            if (affectedRows > 0)
                            {
                                Messages.SuccessMessage();
                            }
                            else
                            {
                                Messages.ErrorOcuredMessage();
                            }
                        }
                        catch (Exception e)
                        {
                            Messages.ErrorOcuredMessage();
                        }
                    }
                }
                else
                {
                    Messages.InvalidInputMessage("Country name or area");
                }
            }
            else
            {
                Messages.InvalidInputMessage("Country ID");
            }
        }
        public static void DeleteCountry()
        {
            Messages.InputMessage("country ID");
            int id;
            if (int.TryParse(Console.ReadLine(), out id))
            {
                using (SqlConnection connection = new SqlConnection(ConnectionStrings.Default))
                {
                    connection.Open();
                    var command = new SqlCommand("DELETE FROM Countries WHERE Id = @id", connection);
                    command.Parameters.AddWithValue("@id", id);

                    try
                    {
                        var affectedRows = command.ExecuteNonQuery();
                        if (affectedRows > 0)
                        {
                            Messages.SuccessMessage();
                        }
                        else
                        {
                            Messages.ErrorOcuredMessage();
                        }
                    }
                    catch (Exception e)
                    {
                        Messages.ErrorOcuredMessage();
                    }
                }
            }
            else
            {
                Messages.InvalidInputMessage("Country ID");
            }
        }

        public static void GetCountryDetails()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStrings.Default))
            {
                connection.Open();
                Messages.InputMessage("country ID");
                int id;
                if (int.TryParse(Console.ReadLine(), out id))
                {
                    var command = new SqlCommand("SELECT * FROM Countries WHERE Id = @id", connection);
                    command.Parameters.AddWithValue("@id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string name = Convert.ToString(reader["Name"]);
                            string area = Convert.ToString(reader["Area"]);
                            Console.WriteLine($"ID: {id}, Name: {name}, Area: {area}");
                        }
                        else
                        {
                            Messages.ErrorOcuredMessage();
                        }
                    }
                    connection.Close();
                }
                else
                    Messages.InvalidInputMessage("id");
            }
        }
    }
}
