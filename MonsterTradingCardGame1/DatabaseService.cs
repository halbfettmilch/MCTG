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

        public static string InsertUser(string username, string password)
        {
            using (NpgsqlConnection con = GetConnection())
            {

                string query = @"insert into public.Users(username,userpassword,coins)values('" + username + "','" + password + "',20)";
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

        public static void InsertCardStack(string cardname, string cardowner)
        {
            using (NpgsqlConnection con = GetConnection())
            {

                string query = @"insert into public.cards(cardname,cardowner,cardstatus)values('" + cardname + "','" + cardowner + "',1)";
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

        public static void InsertCardDeck(string cardname, string cardowner)
        {
            using (NpgsqlConnection con = GetConnection())
            {

                string query = @"insert into public.cards(cardname,cardowner,cardstatus)values('" + cardname + "','" + cardowner + "',2)";
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



        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(@"Server=localhost;Port=5433;User Id=postgres;Password=postgres;Database=mctg");
        }

    }
}
