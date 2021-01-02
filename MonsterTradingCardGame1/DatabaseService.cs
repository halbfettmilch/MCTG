using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Metadata;
using System.Text;
using Npgsql;
using Npgsql.PostgresTypes;

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


        public static string LogInUser(string username, string password)
        {
            using (NpgsqlConnection con = GetConnection())
            {

                string query = "SELECT * FROM users WHERE username = '" + username + "' AND userpassword ='" + password + "'";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                var reader = cmd.ExecuteReader();
                string newusername = "";
                int newuserstatus = -1;
                while (reader.Read())
                {
                    newusername = reader.GetString(0);
                    newuserstatus = reader.GetInt32(2);
                }
                con.Close();
                if (newusername == "")
                {
                    return "User not found";
                }
                if (newuserstatus == 1)
                {
                    return "User already Logged in";
                }
                con.Open();
                string query1 = "UPDATE users SET userstatus = 1 WHERE username ='" + newusername + "'";
                NpgsqlCommand cmd2 = new NpgsqlCommand(query1, con);
                int n = cmd2.ExecuteNonQuery();
                Console.WriteLine(n);
                if (n != -1)
                {
                    Console.WriteLine("User Logged in");
                    con.Close();
                    return newusername + " Logged In";
                }
                return "UNKNOWN ERROR";
            }
        }

        public static string LogOutUser(string username, string password)
        {
            using (NpgsqlConnection con = GetConnection())
            {

                string query = "SELECT * FROM users WHERE username = '" + username + "' AND userpassword ='" + password + "'";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                var reader = cmd.ExecuteReader();
                string newusername = "";
                int newuserstatus = -1;
                while (reader.Read())
                {
                    newusername = reader.GetString(0);
                    newuserstatus = reader.GetInt32(2);
                }
                con.Close();
                if (newusername == "")
                {

                    return "User not found";

                }
                if (newuserstatus == 0)
                {
                    return "User currently not Logged in";
                }
                con.Open();
                string query1 = "UPDATE users SET userstatus = 0 WHERE username ='" + newusername + "'";
                NpgsqlCommand cmd2 = new NpgsqlCommand(query1, con);
                int n = cmd2.ExecuteNonQuery();
                if (n != -1)
                {
                    Console.WriteLine("User Logged out");
                    con.Close();
                    return newusername + " Logged out";
                }
                return "UNKNOWN ERROR";
            }
        }


        public static string InsertUser(string username, string password)
        {



            using (NpgsqlConnection con = GetConnection())
            {
                string query1 = "SELECT * FROM users WHERE username = '" + username + "'";
                NpgsqlCommand cmd1 = new NpgsqlCommand(query1, con);
                con.Open();
                var reader = cmd1.ExecuteReader();
                string newusername = "";
                while (reader.Read())
                {
                    newusername = reader.GetString(0);

                }
                con.Close();
                if (newusername == username)
                {
                    return "Username already exists";
                }
                string query = @"insert into public.Users(username,userpassword,userstatus,coins)values('" + username + "','" + password + "',0,20)";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                int n = cmd.ExecuteNonQuery();
                if (n != -1)
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
                if (n != -1)
                {
                    Console.WriteLine("User " + username + " deleted");
                    return "User deleted";
                }
                Console.WriteLine("User " + username + " not found");
                con.Close();
                return "ERROR User not deleted";
            }
        }
        //Änderungen nötig karte zuerst suchen VILLEICHT ID EINFÜHREN
        public static string OpenPackage(string cardname, string cardowner)
        {
            using (NpgsqlConnection con = GetConnection())
            {
                int ok = 0;
                int number=0;
                while (ok != 1)
                {
                    Random rnd = new Random();
                    number = rnd.Next(0, 10000000);
                    string query1 = "SELECT count(cardID) FROM cards WHERE cardID =" + number;
                    NpgsqlCommand cmd1 = new NpgsqlCommand(query1, con);
                    con.Open();
                    var reader = cmd1.ExecuteReader();
                    int cardcounter = 0;
                    while (reader.Read())
                    {
                        cardcounter = reader.GetInt32(0);

                    }
                    con.Close();
                    if (cardcounter == 0)
                    {
                        ok = 1;
                    }
                }
                string query = @"insert into public.cards(cardname,cardowner,cardstatus,cardID)values('" + cardname + "','" + cardowner + "',0,"+number+")";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                int n = cmd.ExecuteNonQuery();
                string response = "";
                if (n != -1)
                {
                    response = cardname + "acuired\n";
                    Console.WriteLine("card aquired");
                    return response;
                }
                con.Close();
                return "UNKNOWN ERROR";
            }
        }
        //Änderungen nötig karte zuerst suchen VILLEICHT ID EINFÜHREN
        public string MoveCardToDeck(string cardname, string cardowner)
        {
            using (NpgsqlConnection con = GetConnection())
            {
                string query = "SELECT * FROM cards WHERE cardname = '" + cardname + "' AND cardowner = '" + cardowner + "' AND cardstatus = '0' LIMIT 1";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                var reader = cmd.ExecuteReader();
                string newcardname = "";
                while (reader.Read())
                {
                    newcardname = reader.GetString(0);

                }
                if (newcardname == "")
                {

                    return "No " + newcardname + " in your stack";

                }
                con.Close();
                con.Open();
                string query1 = "UPDATE cards SET cardstatus = 1 WHERE cardname ='" + newcardname + "' AND cardowner = '" + cardowner + "' ORDER BY cardname LIMIT 1";
                NpgsqlCommand cmd1 = new NpgsqlCommand(query1, con);
                int n = cmd1.ExecuteNonQuery();
                if (n != -1)
                {
                    Console.WriteLine("User Logged out");
                    con.Close();
                    return newcardname + " added to deck";
                }
                return "UNKNOWN ERROR";
            }
        }

        public string MoveCardToStack(string cardname, string cardowner)
        {
            using (NpgsqlConnection con = GetConnection())
            {

                string query = @"insert into public.cards(cardname,cardowner,cardstatus)values('" + cardname + "','" + cardowner + "',1)";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                int n = cmd.ExecuteNonQuery();
                string response = "";
                if (n != -1)
                {
                    response = cardname + "added to Deck\n";
                    Console.WriteLine("Card added to Deck");
                    return response;

                }
                con.Close();
                return "No " + cardname + " cards found";
            }
        }


        public static string GetStackCards(string cardowner)
        {
            using (NpgsqlConnection con = GetConnection())
            {

                string query = "SELECT cardname FROM cards WHERE cardowner = '" + cardowner + "' AND cardstatus = 0";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                var reader = cmd.ExecuteReader();
                string cardlist = "";
                while (reader.Read())
                {
                    cardlist += reader.GetString(0);
                    cardlist += "\n";
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

                string query = "SELECT cardname FROM cards WHERE cardwoner = '" + cardowner + "' AND cardstatus = 1";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                var reader = cmd.ExecuteReader();
                string cardlist = "";
                while (reader.Read())
                {
                    cardlist += reader.GetString(0);
                    cardlist += "\n";
                }
                if (cardlist == "")
                {
                    con.Close();
                    return "No Cards in Deck";

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
