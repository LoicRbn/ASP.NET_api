using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace ASP.NET_api.Models
{
    public class DatabaseContext: DbContext
    {
        private readonly string _connectionString;
        public DatabaseContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        private MySqlConnection GetConnection()
        {
            Console.WriteLine(_connectionString);
            return new MySqlConnection(_connectionString);
        }

        public List<Conso> getConso()
        {
            List<Conso> conso = new List<Conso>();
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("select * from conso", connection);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        conso.Add(new Conso()
                        {
                            Id = reader.GetInt32("id"),
                            Nom = reader.GetString("nom")
                        });
                    }
                }
            }
            return conso;
        }

        public int insertConso(string nom)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Conso VALUES(0, @nom)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nom", nom);
                return cmd.ExecuteNonQuery();
            }
        }
        public int insertConso(int idconso)
        {
            using(MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Conso VALUES(0, @nom)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@iditem", idItem);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
