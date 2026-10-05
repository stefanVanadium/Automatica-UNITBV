using Microsoft.Data.SqlClient;

namespace Lab11.Data
{
    public static class DatabaseInitializer
    {
        private const string MasterConnectionString =
        @"Data Source=(LocalDB)\MSSQLLocalDB;" +
        @"Initial Catalog=master;" +
        @"Integrated Security=True;Encrypt=False";
        public const string ConnectionString =
        @"Data Source=(LocalDB)\MSSQLLocalDB;" +
        @"Initial Catalog=ProduseDB;" + @"Integrated Security=True;Encrypt=False";
        public static void EnsureCreated()
        {
            // 1. creează baza de date dacă nu există
            using (var conn = new SqlConnection(MasterConnectionString))
            {
                conn.Open();
                string sql = @"
IF NOT EXISTS
(SELECT name FROM sys.databases
WHERE name = 'ProduseDB')
BEGIN
CREATE DATABASE ProduseDB;
END";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            // 2. creează tabela Produse dacă nu există
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string sql = @"
                IF NOT EXISTS
                (SELECT * FROM sysobjects
                WHERE name='Produse' AND xtype='U')
                BEGIN
                CREATE TABLE Produse (
                Id INT PRIMARY KEY IDENTITY(1,1),
                Denumire NVARCHAR(100) NOT NULL,
                Pret DECIMAL(10,2) NOT NULL,
                Stoc INT NOT NULL DEFAULT 0,
                Categorie NVARCHAR(50) NULL,
                DataAdaugarii DATETIME
                NOT NULL DEFAULT GETDATE()
                );
                END";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string sql = @"
                IF NOT EXISTS
                (SELECT * FROM sysobjects
                WHERE name='Vanzari' AND xtype='U')
                BEGIN
                CREATE TABLE Vanzari (
                Id INT PRIMARY KEY IDENTITY(1,1),
                ProdusId INT NOT NULL,
                Cantitate INT NOT NULL,
                PretUnitar DECIMAL(18, 2) NOT NULL,
                DataOra DATETIME NOT NULL DEFAULT GETDATE(),
                CONSTRAINT FK_Vanzari_Produse FOREIGN KEY (ProdusId) REFERENCES Produse(Id)
                );
                END";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
