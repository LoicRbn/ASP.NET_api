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

        public List<Contenir> getContenir()
        {
            List<Contenir> contenir = new List<Contenir>();
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("select * from contenir", connection);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        contenir.Add(new Contenir()
                        {
                            Idcommande = reader.GetInt32("id"),
                            Idconso = reader.GetInt32("id_1"),
                            Etat = reader.GetString("etat")
                        });
                    }
                }
            }
            return contenir;
        }

        public List<Commande> getCommande()
        {
            List<Commande> commande = new List<Commande>();
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("select * from commande", connection);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        commande.Add(new Commande()
                        {
                            Id = reader.GetInt32("id")
                        });
                    }
                }
            }
            return commande;
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
        public int initializeNewCommande()
        {
            using(MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Commande VALUES(0)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                return cmd.ExecuteNonQuery();
            }
        }

        public int createCommande(int idcommande, int idconso, string etat)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO contenir VALUES(@idcommande, @idconso, @etat)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idcommande", idcommande);
                cmd.Parameters.AddWithValue("@idconso", idconso);
                cmd.Parameters.AddWithValue("@etat", etat);
                return cmd.ExecuteNonQuery();
            }
        }

        public int updateCommandState(int idcommande, int idconso, string etat)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "UPDATE contenir set etat = @etat WHERE id = @idcommande and id_1 = @idconso)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idcommande", idcommande);
                cmd.Parameters.AddWithValue("@idconso", idconso);
                cmd.Parameters.AddWithValue("@etat", etat);
                return cmd.ExecuteNonQuery();
            }
        }


        /* public List<Commande>*/
    }
}
