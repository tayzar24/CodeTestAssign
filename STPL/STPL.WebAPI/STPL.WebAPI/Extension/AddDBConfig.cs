using Microsoft.EntityFrameworkCore;
using Npgsql;
using STPL.Entity;

namespace STPL.WebAPI.Extension
{
    public static class AddDBConfig
    {

        public static void DBConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (IsConnectionValid(connectionString))
            {
                services.AddDbContext<STPLContext>(options =>
                {
                    options.UseNpgsql(connectionString);

                });
            }
            else
            {
                throw new InvalidOperationException("Unable to establish a database connection. Please check the connection settings.");
            }
        }

        private static bool IsConnectionValid(string connectionString)
        {
            try
            {
                // Attempt to create a connection and open it
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    // If the connection opens successfully, return true
                    return true;
                }
            }
            catch (Exception ex)
            {
                // Log the exception (you can use a logging framework here)
                Console.WriteLine($"Database connection check failed: {ex.Message}");

                // Return false indicating the connection could not be established
                return false;
            }
        }
    }
}
