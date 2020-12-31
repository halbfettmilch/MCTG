using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Npgsql;

namespace MonsterTradingCardGame1
{
    public class DatabaseService
    {
        public static void TestConnection()
        {
            using (NpgsqlConnection con = GetConnection())
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    Console.WriteLine("connected to DB");
                }
                else Console.WriteLine("Not connected to DB");
                con.Close();
            }
        }

        
        public static string LogInUser(string username,string password)
        {
            using (NpgsqlConnection con = GetConnection())
            {

                string query = "SELECT * FROM users WHERE username = '"+username+"' AND userpassword ='"+password+"' AND userstatus = 0";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                var reader = cmd.ExecuteReader();
                string newusername="";
                while (reader.Read())
                {
                    newusername = reader.GetString(0);
                }
                if (newusername == "")
                {
                    con.Close();
                    return "User not found";
                }
                string query1 = "UPDATE users SET userstatus = 1 WHERE username ='" + newusername + "'";
                con.Close();
                return newusername + " Logged In";
            }
        }

        public static string LogOutUser(string username, string password)
        {
            using (NpgsqlConnection con = GetConnection())
            {

                string query = "SELECT * FROM users WHERE username = '" + username + "' AND userpassword ='" + password + "' AND userstatus = 1";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                var reader = cmd.ExecuteReader();
                string newusername = "";
                while (reader.Read())
                {
                    newusername = reader.GetString(0);
                }
                
                if (newusername == "")
                {
                    con.Close();
                    return "User not found";

                }
                string query1 = "UPDATE users SET userstatus = 0 WHERE username ='"+newusername+"'";
                con.Close();
                return newusername + " logged Out";
            }
        }


        public static string InsertUser(string username, string password)
        {
            using (NpgsqlConnection con = GetConnection())
            {

                string query = @"insert into public.Users(username,userpassword,userstatus,coins)values('" + username + "','" + password + "',0,20)";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                int n = cmd.ExecuteNonQuery();
                if (n == 1)
                {
                    Console.WriteLine("User Created");
                    return "New User Created";
                }

                Console.WriteLine("User not Created");
                con.Close();
                return "User allready exists";

            }
        }



        public static string DeleteUser(string username)
        {
            using (NpgsqlConnection con = GetConnection())
            {
                string query = @"delete from public.Users where Username='vollmilch'";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                int n = cmd.ExecuteNonQuery();
                if (n == 1)
                {
                    Console.WriteLine("User " + username + " deleted");
                    return "User deleted";
                }
                Console.WriteLine("User " + username + " not found");
                con.Close();
                return "ERROR User not deleted";
            }
        }
        //Änderungen nötig karte zuerst suchen
        public static void InsertCardStack(string cardname, string cardowner)
        {
            using (NpgsqlConnection con = GetConnection())
            {

                string query = @"insert into public.cards(cardname,cardowner,cardstatus)values('" + cardname + "','" + cardowner + "',0)";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                int n = cmd.ExecuteNonQuery();
                if (n == 1)
                {
                    Console.WriteLine("Card added to Stack");
                }
                else Console.WriteLine("ERROR");
                con.Close();
            }
        }
        //Änderungen nötig karte zuerst suchen
        public static void InsertCardDeck(string cardname, string cardowner)
        {
            using (NpgsqlConnection con = GetConnection())
            {

                string query = @"insert into public.cards(cardname,cardowner,cardstatus)values('" + cardname + "','" + cardowner + "',1)";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                int n = cmd.ExecuteNonQuery();
                if (n == 1)
                {
                    Console.WriteLine("Card added to stack");
                }
                else Console.WriteLine("ERROR");
                con.Close();
            }
        }


        public static string GetStackCards(string cardowner)
        {
            using (NpgsqlConnection con = GetConnection())
            {

                string query = "SELECT cardname FROM cards WHERE username = '" + cardowner + "' AND cardstatus = 0";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                var reader = cmd.ExecuteReader();
                string cardlist = "";
                while (reader.Read())
                {
                    cardlist += reader.GetString(0);
                }
                if (cardlist == "")
                {
                    con.Close();
                    return "No Cards in Stack";

                }
                con.Close();
                return cardlist;
            }
        }

        public static string GetDeckCards(string cardowner)
        {
            using (NpgsqlConnection con = GetConnection())
            {

                string query = "SELECT cardname FROM cards WHERE username = '" + cardowner + "' AND cardstatus = 1";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                var reader = cmd.ExecuteReader();
                string cardlist = "";
                while (reader.Read())
                {
                    cardlist += reader.GetString(0);
                }
                if (cardlist == "")
                {
                    con.Close();
                    return "No Cards in Stack";

                }
                con.Close();
                return cardlist;
            }
        }



        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(@"Server=localhost;Port=5433;User Id=postgres;Password=postgres;Database=mctg");
        }

    }
}
