using Lab10.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace Lab10.Data
{
    public class ProdusRepository
    {
        private readonly string _connectionString;
        public ProdusRepository()
        {
            _connectionString = DatabaseInitializer.ConnectionString;
        }
        public List<Produs> GetAll(string filtruDenumire = null)
        {
            var produse = new List<Produs>();
            string sql = @"SELECT Id, Denumire, Pret, Stoc,
Categorie, DataAdaugarii
FROM Produse";
            if (!string.IsNullOrWhiteSpace(filtruDenumire))
                sql += " WHERE Denumire LIKE @Filtru";
            sql += " ORDER BY Denumire";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (!string.IsNullOrWhiteSpace(filtruDenumire))
                    cmd.Parameters.Add("@Filtru", SqlDbType.NVarChar, 100)
                    .Value = "%" + filtruDenumire + "%";
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        produse.Add(new Produs
                        {
                            Id = reader.GetInt32(0),
                            Denumire = reader.GetString(1),
                            Pret = reader.GetDecimal(2),
                            Stoc = reader.GetInt32(3),
                            Categorie = reader.IsDBNull(4)
                        ? null : reader.GetString(4),
                            DataAdaugarii = reader.GetDateTime(5)
                        });
                    }
                }
            }
            return produse;
        }
        public int Add(Produs p)
        {
            string sql = @"INSERT INTO Produse
(Denumire, Pret, Stoc, Categorie)
OUTPUT INSERTED.Id
VALUES (@Denumire, @Pret, @Stoc, @Categorie)";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@Denumire", SqlDbType.NVarChar, 100)
                .Value = p.Denumire;
                cmd.Parameters.Add("@Pret", SqlDbType.Decimal)
                .Value = p.Pret;
                cmd.Parameters.Add("@Stoc", SqlDbType.Int).Value = p.Stoc;
                cmd.Parameters.Add("@Categorie", SqlDbType.NVarChar, 50)
                .Value = (object)p.Categorie ?? System.DBNull.Value;
                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }
        public int Update(Produs p)
        {
            string sql = @"UPDATE Produse SET
Denumire = @Denumire,
Pret = @Pret,
Stoc = @Stoc,
Categorie = @Categorie
WHERE Id = @Id";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = p.Id;
                cmd.Parameters.Add("@Denumire", SqlDbType.NVarChar, 100)
                .Value = p.Denumire;
                cmd.Parameters.Add("@Pret", SqlDbType.Decimal)
                .Value = p.Pret;
                cmd.Parameters.Add("@Stoc", SqlDbType.Int).Value = p.Stoc;
                cmd.Parameters.Add("@Categorie", SqlDbType.NVarChar, 50)
                .Value = (object)p.Categorie ?? System.DBNull.Value;
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public int Delete(int id)
        {
            string sql = "DELETE FROM Produse WHERE Id = @Id";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public decimal GetValoareTotalaStoc()
        {
            string sql =
            @"SELECT ISNULL(SUM(Pret * Stoc), 0) FROM Produse";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                return (decimal)cmd.ExecuteScalar();
            }
        }
    }
}
