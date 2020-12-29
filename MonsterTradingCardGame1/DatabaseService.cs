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
            {   con.Open();
                if (con.State == ConnectionState.Open)
                {
                    Console.WriteLine("connected to DB");
                }
                else Console.WriteLine("Not connected to DB");
                con.Close();
            }
        }

        public static void InsertRecord(string username, string password)
        {
            using (NpgsqlConnection con = GetConnection())
            {
               
                string query=@"insert into public.Users(username,password)values('"+username+"','"+password+"')";
                NpgsqlCommand cmd = new NpgsqlCommand(query,con);
                con.Open();
                int n = cmd.ExecuteNonQuery();
               if (n==1)
                {
                    Console.WriteLine("Value inserted");
                }
                else Console.WriteLine("Value not inserted");
               con.Close();
            }
        }

        public static void DeleteRecord(string username)
        {
            using (NpgsqlConnection con = GetConnection())
            {
                string query = @"delete from public.Users where Username='vollmilch'";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                int n = cmd.ExecuteNonQuery();
                if (n == 1)
                {
                    Console.WriteLine("User");
                }
                else Console.WriteLine("Value not inserted");
                con.Close();
            }
        }
        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(@"Server=localhost;Port=5433;User Id=postgres;Password=postgres;Database=mctg");
        }

    }
}
