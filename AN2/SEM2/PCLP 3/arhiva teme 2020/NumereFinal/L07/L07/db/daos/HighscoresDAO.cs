using L07.db.models;
using L07.db.utils;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L07.db.daos
{
    class HighscoresDAO
    {
        public static List<Highscore> findAll()
        {
            List<Highscore> rez = new List<Highscore>();

            // preia conexiune de la db

            MySqlConnection con = DBConnection.getConnection();

            if (con==null)
            {
                throw new Exception("Conexiunea la baza de date nu s-a realizat.");
            }

            // executa query pentru preluare date + transfer in lista

            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM highscores ORDER BY id DESC";

            MySqlDataReader data = cmd.ExecuteReader();

            while (data.Read())
            {
                Highscore hs = new Highscore();
                hs.Id = long.Parse(data["id"].ToString());
                hs.Gamer = data["gamer"].ToString();
                hs.Hscore = int.Parse(data["highscore"].ToString());

                rez.Add(hs);
            }

            // inchide conexiune + cleanup
            data.Close();
            con.Close();

            return rez;
        }

        public static void insert(Highscore hs)
        {
            MySqlConnection con = DBConnection.getConnection();

            if (con == null)
            {
                throw new Exception("Conexiunea la baza de date nu s-a realizat.");
            }

            MySqlCommand cmd = con.CreateCommand();

            cmd.CommandText = "INSERT INTO highscores(gamer, highscore) VALUES(@gamer, @hscore)";
            cmd.Parameters.AddWithValue("@gamer", hs.Gamer);
            cmd.Parameters.AddWithValue("@hscore", hs.Hscore);

            if (cmd.ExecuteNonQuery()!=1)
            {
                throw new Exception("Inserarea nu s-a putut face.");
            }

            con.Close();
        }

        public static void remove(Highscore hs)
        {
            MySqlConnection con = DBConnection.getConnection();

            if (con == null)
            {
                throw new Exception("Conexiunea la baza de date nu s-a realizat.");
            }

            MySqlCommand cmd1 = con.CreateCommand();
            MySqlCommand cmd2 = con.CreateCommand();
            MySqlCommand cmd3 = con.CreateCommand();

            cmd1.CommandText = "DELETE FROM `highscores` WHERE `highscores`.`id` = @Id;";
            cmd2.CommandText = "UPDATE `highscores` SET id=id-1 WHERE id>@Id;";
            cmd3.CommandText = "ALTER TABLE highscores AUTO_INCREMENT = 1;";
            cmd1.Parameters.AddWithValue("@Id", hs.Id);
            cmd2.Parameters.AddWithValue("@Id", hs.Id);

            
            if (cmd1.ExecuteNonQuery() != 1)
            {
                throw new Exception("Stergerea nu s-a putut realiza.");
            }
            else
            {
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
            }

            con.Close();
        }

        public static void modify(Highscore hs)
        {
            MySqlConnection con = DBConnection.getConnection();

            if (con == null)
            {
                throw new Exception("Conexiunea la baza de date nu s-a realizat.");
            }

            MySqlCommand cmd1 = con.CreateCommand();
            MySqlCommand cmd2 = con.CreateCommand();

            cmd1.CommandText = "UPDATE `highscores` SET gamer=@gamer WHERE id=@Id;";
            cmd1.Parameters.AddWithValue("@gamer", hs.Gamer);
            cmd1.Parameters.AddWithValue("@Id", hs.Id);
            cmd2.CommandText = "UPDATE `highscores` SET highscore=@hscore WHERE id=@Id;";
            cmd2.Parameters.AddWithValue("@Id", hs.Id);
            cmd2.Parameters.AddWithValue("@hscore", hs.Hscore);

            cmd1.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            
            //if (cmd.ExecuteNonQuery() != 1 && cmd1.ExecuteNonQuery()!=1)
            //{
            //    throw new Exception("Modificarea nu s-a putut face.");
            //}


            con.Close();
        }
    }
}
