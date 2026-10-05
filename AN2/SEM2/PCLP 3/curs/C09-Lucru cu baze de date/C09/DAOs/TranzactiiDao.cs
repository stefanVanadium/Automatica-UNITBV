using C09.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C09.DAOs
{
    class TranzactiiDao
    {
        public static List<Tranzactie> findAll()
        {
            List<Tranzactie> resp = new List<Tranzactie>();

            // preluare conexiune DB
            MySqlConnection conn = DBConnector.GetConnection();

            // folosire conexiune
            string sql = "SELECT * FROM tranzactii ORDER BY tstamp DESC";

            MySqlCommand comanda = new MySqlCommand(sql, conn);

            MySqlDataReader reader = comanda.ExecuteReader();

            while (reader.Read())
            {
                Tranzactie tr = new Tranzactie();

                tr.Id = reader.GetInt64("id");
                tr.TipOperatie = reader.GetString("tip_tranzactie");
                tr.Valoare = reader.GetDouble("valoare");
                tr.Descriere = reader.GetString("descriere");
                tr.Timestamp = reader.GetDateTime("tstamp");

                resp.Add(tr);
            }

            // inchidere conexiune
            conn.Close();

            return resp;
        }

    }
}
