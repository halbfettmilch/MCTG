﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using Npgsql;
using Npgsql.PostgresTypes;

namespace MonsterTradingCardGame1
{   
    public class DatabaseService
    {
        static private bool working = false;
        static private string winner = null;
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
                string query = @"insert into public.Users(username,userpassword,userstatus,coins,userbio,userimage,gamesplayed,wins,losses)values('" + username + "','" + password + "',0,20,'','',0,0,0)";
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

        public static string UpdateUser(string username, string userbio, string userimage)
        {

            using (NpgsqlConnection con = GetConnection())
            {
                string query1 = "SELECT * FROM users WHERE username = '" + username + "'";
                NpgsqlCommand cmd1 = new NpgsqlCommand(query1, con);
                con.Open();
                var reader = cmd1.ExecuteReader();
                string newusername ="";
                while (reader.Read())
                {
                    newusername = reader.GetString(0);

                }
                con.Close();
                if (newusername =="")
                {
                    return "No user with that name found";
                }
                string query = @"Update users SET userbio='"+userbio+"', userimage='"+userimage+"' WHERE username='"+username+"'";
                Console.WriteLine(newusername);
                Console.WriteLine(userbio);
                Console.WriteLine(userimage);
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                int n = cmd.ExecuteNonQuery();
                if (n != -1)
                {
                    Console.WriteLine("User Updated");
                    return "User updated";
                }

                Console.WriteLine("ERROR");
                con.Close();
                return "UNKNOWN ERROR";

            }
        }
        public static string GetUser(string username)
        {

            using (NpgsqlConnection con = GetConnection())
            {
                string query1 = "SELECT username,coins,userbio,userimage FROM users WHERE username = '" + username + "'";
                NpgsqlCommand cmd1 = new NpgsqlCommand(query1, con);
                con.Open();
                var reader = cmd1.ExecuteReader();
                string response = "username  |  coins  |  userbio  |  userimage\n";
                string newusername = "";
                while (reader.Read())
                {
                    newusername = reader.GetString(0);
                    response += newusername;
                    response += "  |  ";
                    response += reader.GetInt32(1);
                    response += "  |  ";
                    response += reader.GetString(2);
                    response += "  |  ";
                    response += reader.GetString(3);
                    response += "\n";

                }
                con.Close();
                if (newusername=="")
                {
                    return "User Not found";
                }
                
                return response;

            }
        }

        public static string GetUserStats(string username)
        {

            using (NpgsqlConnection con = GetConnection())
            {
                string query1 = "SELECT username,gamesplayed,wins,losses FROM users WHERE username = '" + username + "'";
                NpgsqlCommand cmd1 = new NpgsqlCommand(query1, con);
                con.Open();
                var reader = cmd1.ExecuteReader();
                string response = "username  |  gamesplayed  |  wins  |  losses\n";
                string newusername = "";
                while (reader.Read())
                {
                    newusername = reader.GetString(0);
                    response += newusername;
                    response += "  |  ";
                    response += reader.GetInt32(1);
                    response += "  |  ";
                    response += reader.GetInt32(2);
                    response += "  |  ";
                    response += reader.GetInt32(3);
                    response += "\n";

                }
                con.Close();
                if (newusername == "")
                {
                    return "User Not found";
                }

                return response;

            }
        }
        public static string GetScoreboard()
        {

            using (NpgsqlConnection con = GetConnection())
            {
                string query1 = "SELECT username,gamesplayed,wins,losses FROM users ORDER BY gamesplayed";
                NpgsqlCommand cmd1 = new NpgsqlCommand(query1, con);
                con.Open();
                var reader = cmd1.ExecuteReader();
                string response = "username  |  gamesplayed  |  wins  |  losses\n";
                string newusername = "";
                while (reader.Read())
                {
                    newusername = reader.GetString(0);
                    response += newusername;
                    response += "  |  ";
                    response += reader.GetInt32(1);
                    response += "  |  ";
                    response += reader.GetInt32(2);
                    response += "  |  ";
                    response += reader.GetInt32(3);
                    response += "\n";

                }
                con.Close();
                if (newusername == "")
                {
                    return "No Users in Database";
                }

                return response;

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

       


        public static string OpenPackage(string cardowner, Package package)
        {
            using (NpgsqlConnection con = GetConnection())
            {
                string query2 = "SELECT coins FROM users WHERE username = '" + cardowner+ "'";
                NpgsqlCommand cmd2 = new NpgsqlCommand(query2, con);
                con.Open();
                var reader1 = cmd2.ExecuteReader();
                int usercoins = 0;
                while (reader1.Read())
                {
                    
                    usercoins = reader1.GetInt32(0);

                }
                if (usercoins < (package.price))
                {
                    return "Not enought coins ";

                }
                con.Close();
               
                string query3 = @"UPDATE users SET coins = coins - "+package.price+" WHERE username = '"+cardowner+"'";
                NpgsqlCommand cmd3 = new NpgsqlCommand(query3, con);
                con.Open();
                int n1 = cmd3.ExecuteNonQuery();
                string response = "";
                if (n1 != -1)
                {
                    response = "Bought Package for "+package.price+" coins \n";
                    Console.WriteLine("Package bought");
                    
                }
                con.Close();
                
                for (int j = 0; j < package.size; j++)
                {
                    int ok = 0;
                    int number = 0;
                    while (ok != 1)
                    {
                        Random rnd = new Random();
                        number = rnd.Next(1, 10000000);
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
                    string query = @"insert into public.cards(cardname,cardowner,cardstatus,cardID)values('" + package.package[j]._Name + "','" + cardowner + "',0," + number + ")";
                    NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                    con.Open();
                    int n = cmd.ExecuteNonQuery();
                    con.Close();
                    if (n != -1)
                    {
                        response += package.package[j]._Name + " acuired\n";
                        Console.WriteLine(" card aquired");
                        if (j == (package.size-1))
                        {
                            return response;
                        }
                    }
                }
                return "UNKNOWN ERROR";
            }
        }
        

       
        public static string MoveCardToDeck(int cardID, string cardowner)
        {
            using (NpgsqlConnection con = GetConnection())
            {

                string query2 = "SELECT count(cardname) FROM cards WHERE cardowner = '" + cardowner + "' AND cardstatus = 1";
                NpgsqlCommand cmd2 = new NpgsqlCommand(query2, con);
                con.Open();
                var reader2 = cmd2.ExecuteReader();
                int cardsInDeck = 0;
                while (reader2.Read())
                {
                    cardsInDeck = reader2.GetInt32(0);

                }
                if ( cardsInDeck == 4)
                {

                    return "Already 4 Cards in your Deck";

                }
                con.Close();
                string query = "SELECT * FROM cards WHERE cardid = " + cardID + " AND cardstatus = 0 LIMIT 1";
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

                    return "Card not found";

                }
                con.Close();
                con.Open();
                string query1 = "UPDATE cards SET cardstatus = 1 WHERE cardID =" + cardID;
                NpgsqlCommand cmd1 = new NpgsqlCommand(query1, con);
                int n = cmd1.ExecuteNonQuery();
                if (n == 1)
                {
                    Console.WriteLine("Card Moved to Deck");
                    con.Close();
                    return newcardname + " added to deck";
                }
                return "UNKNOWN ERROR";
            }
        }
       
        public static string MoveCardToStack(int cardID, string cardowner)
        {
            using (NpgsqlConnection con = GetConnection())
            {
                string query = "SELECT * FROM cards WHERE cardid = " + cardID + " AND cardstatus = 1 LIMIT 1";
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

                    return "Card not found";

                }
                con.Close();
                con.Open();
                string query1 = "UPDATE cards SET cardstatus = 0 WHERE cardID =" + cardID;
                NpgsqlCommand cmd1 = new NpgsqlCommand(query1, con);
                int n = cmd1.ExecuteNonQuery();
                if (n == 1)
                {
                    Console.WriteLine("Card Moved to Stack");
                    con.Close();
                    return newcardname + " removed from Deck";
                }
                return "UNKNOWN ERROR";
            }
        }

        public static string GetAllCards(string cardowner)
        {
            using (NpgsqlConnection con = GetConnection())
            {

                string query = "SELECT cardname FROM cards WHERE cardowner = '" + cardowner + "' ORDER BY cardname";
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
                    return "You own no Cards";

                }
                con.Close();
                return cardlist;
            }
        }


        public static string GetStackCards(string cardowner)
        {
            using (NpgsqlConnection con = GetConnection())
            {

                string query = "SELECT cardname FROM cards WHERE cardowner = '" + cardowner + "' AND cardstatus = 0 ORDER BY cardname";
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

                string query = "SELECT cardname FROM cards WHERE cardowner = '" + cardowner + "' AND cardstatus = 1 ORDER BY cardname";
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
        public static string ShowALLCardsForSAle()
        {
            using (NpgsqlConnection con = GetConnection())
            {

                string query = "SELECT cardname,cardowner,cardprice FROM cards WHERE cardstatus = 2 ORDER BY cardprice";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                var reader = cmd.ExecuteReader();
                string cardlist = "cardname  | cardowner  |  cardprice  \n";
                while (reader.Read())
                {   
                    cardlist += reader.GetString(0);
                    cardlist += " | ";
                    cardlist += reader.GetString(1);
                    cardlist += " | ";
                    cardlist += reader.GetInt32(2);
                    cardlist += "\n";
                }
                if (cardlist == "cardname  | cardowner  |  cardprice  \n")
                {
                    con.Close();
                    return "No Cards for Sale";

                }
                con.Close();
                return cardlist;
            }
        }

        public static string ShowALLCardsForSAleForUSer(string cardowner)
        {
            using (NpgsqlConnection con = GetConnection())
            {

                string query = "SELECT cardname,cardowner,cardprice FROM cards WHERE cardstatus = 2 AND cardowner='"+cardowner+"' ORDER BY cardprice";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                var reader = cmd.ExecuteReader();
                string cardlist = "cardname  | cardowner  |  cardprice  \n";
                while (reader.Read())
                {
                    cardlist += reader.GetString(0);
                    cardlist += " | ";
                    cardlist += reader.GetString(1);
                    cardlist += " | ";
                    cardlist += reader.GetInt32(2);
                    cardlist += "\n";
                }
                if (cardlist == "cardname  | cardowner  |  cardprice  \n")
                {
                    con.Close();
                    return "No Cards for Sale For that user";

                }
                con.Close();
                return cardlist;
            }
        }

        public static string DeleteTradeDeal(string cardowner, int cardID)
        {
            using (NpgsqlConnection con = GetConnection())
            {

                string query = "SELECT * FROM cards WHERE cardowner = '" + cardowner + "' AND cardstatus = 2 AND cardID = "+cardID;
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

                    return "Card not found";

                }
                con.Close();
                con.Open();
                string query1 = "UPDATE cards SET cardstatus = 0, cardprice= NULL WHERE cardID =" + cardID;
                NpgsqlCommand cmd1 = new NpgsqlCommand(query1, con);
                int n = cmd1.ExecuteNonQuery();
                if (n == 1)
                {
                    Console.WriteLine("Card set for Sale");
                    con.Close();
                    return newcardname + " returned to your stack coins";
                }
                return "UNKNOWN ERROR";
                
            }
        }

        public static string CreateTradeDeal(string cardowner, int price, int cardID)
        {
            using (NpgsqlConnection con = GetConnection())
            {

                string query = "SELECT * FROM cards WHERE cardowner = '" + cardowner + "' AND cardstatus = 0 AND cardID = " + cardID + " LIMIT 1";
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

                    return "Card not found";

                }
                con.Close();
                con.Open();
                string query1 = "UPDATE cards SET cardstatus = 2, cardprice= " + price + " WHERE cardID =" + cardID;
                NpgsqlCommand cmd1 = new NpgsqlCommand(query1, con);
                int n = cmd1.ExecuteNonQuery();
                if (n == 1)
                {
                    Console.WriteLine("Card set for Sale");
                    con.Close();
                    return newcardname + " Set for Sale for " + price + " coins";
                }
                return "UNKNOWN ERROR";

            }
        }
        public static string BuyACard(string newcardowner, int cardID)
        {
            using (NpgsqlConnection con = GetConnection())
            {

                string query = "SELECT * FROM cards WHERE cardID = " + cardID + "AND cardstatus = 2";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                var reader = cmd.ExecuteReader();
                string oldcardname = "";
                string oldcardowner = "";
                int oldcardstatus = 0;
                int oldcardid = 0;
                int oldcardprice = 0;
                string response = "";
                while (reader.Read())
                {
                    oldcardname = reader.GetString(0);
                    oldcardowner = reader.GetString(1);
                    oldcardstatus = reader.GetInt32(2);
                    oldcardid = reader.GetInt32(3);
                    oldcardprice = reader.GetInt32(4);

                }
                if (oldcardname == "" || oldcardowner =="" || oldcardid == 0 || oldcardstatus != 2 || oldcardprice<0)
                {
                    con.Close();
                    return "No such card to buy found";

                }

                if (oldcardowner == newcardowner)
                {
                    con.Close();
                    return "You cannot buy your own card";
                }
                con.Close();
                con.Open();
                string query2 = "SELECT coins FROM users WHERE username = '" + newcardowner +"'";
                NpgsqlCommand cmd2 = new NpgsqlCommand(query2, con);
                var reader2 = cmd2.ExecuteReader();
                int usercoins = 0;
                while (reader2.Read())
                {
                    usercoins = reader2.GetInt32(0);
                    
                }
                if (usercoins < oldcardprice)
                {
                    Console.WriteLine(usercoins);
                    Console.WriteLine(oldcardprice);
                    con.Close();
                    return "Not enought coins";

                }
                con.Close();
                con.Open();
                string query1 = "UPDATE cards SET cardstatus = 0, cardprice= NULL , cardowner = '"+newcardowner+"' WHERE cardID =" + cardID;
                NpgsqlCommand cmd1 = new NpgsqlCommand(query1, con);
                int n = cmd1.ExecuteNonQuery();
                if (n == 1)
                {
                    
                    response = "Card " + oldcardname + " bought for ";
                    con.Close();
                    
                }

                con.Close();
                con.Open();
                string query3 = "UPDATE users SET coins = coins + "+oldcardprice+" WHERE username ='" + oldcardowner+ "';UPDATE users SET coins = coins - " + oldcardprice + "WHERE username ='" + newcardowner+"'";
                NpgsqlCommand cmd3 = new NpgsqlCommand(query3, con);
                int m = cmd3.ExecuteNonQuery();
                if (m == 2)
                {
                    response += oldcardprice+ " coins";
                    con.Close();
                    return response;

                }

                con.Close();
                return "UNKNOWN ERROR";

            }
        }
        public static string SearchForBattle(string username)
        {
            using (NpgsqlConnection con = GetConnection())
            {   
                string query3 = "SELECT cardname FROM cards WHERE cardstatus = 1 AND cardowner='" + username + "'";
                NpgsqlCommand cmd3 = new NpgsqlCommand(query3, con);
                con.Open();
                var reader3 = cmd3.ExecuteReader();
                string[] cardsP1 = new string[4];
                int j = 0;
                while (reader3.Read())
                {
                    cardsP1[j] = reader3.GetString(0);
                    j++;
                   
                }
                if (cardsP1.Length != 4)
                {
                    con.Close();
                    return "You have no valid Deck";
                }
                con.Close();
                string query = "SELECT username FROM users WHERE userstatus = 2";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                var reader = cmd.ExecuteReader();
                string newusername = "";
                while (reader.Read())
                {
                    newusername = reader.GetString(0);

                }
                con.Close();
                if (newusername == username)
                {
                    return "Already searching for battle";
                }

                if (newusername == "")
                {
                    con.Open();
                    string query1 = "UPDATE users SET userstatus = 2 WHERE username ='" + username + "'";
                    NpgsqlCommand cmd1 = new NpgsqlCommand(query1, con);
                    int n = cmd1.ExecuteNonQuery();
                    if (n == 1)
                    {   
                        working = true;
                        winner = null;
                        con.Close();
                        while (working)
                        {
                            
                        }
                        return winner;
                    }

                }
                con.Close();
                string query2 = "SELECT cardname FROM cards WHERE cardstatus = 1 AND cardowner='"+newusername+"'";
                NpgsqlCommand cmd2 = new NpgsqlCommand(query2, con);
                con.Open();
                var reader2 = cmd2.ExecuteReader();
                string[] cardsP2 = new string[4];
                int i = 0;
                while (reader2.Read())
                {
                    cardsP2[i] = reader2.GetString(0);
                    i++;
                }
                if (cardsP2.Length!=4)
                {
                    con.Close();
                    return "Enemy has no valid Deck";
                }
                con.Close();
                //start Battle
                BattleLogic battlebuffer= new BattleLogic();
                winner = battlebuffer.battle(username,newusername,cardsP1,cardsP2);
                working = false;
                var lastLine = winner.Split('\n').Last();
                if (lastLine == "|||" + username + " won|||")
                {
                    con.Open();
                    string query1 = "UPDATE users SET wins = wins+1,gamesplayed=gamesplayed+1,userstatus=1 WHERE username ='" + username + "';UPDATE users SET losses = losses+1,gamesplayed=gamesplayed+1,userstatus=1 WHERE username ='" + newusername + "'";
                    NpgsqlCommand cmd1 = new NpgsqlCommand(query1, con);
                    int n = cmd1.ExecuteNonQuery();
                    if (n == 2)
                    {
                        con.Close();
                        return winner;
                    }
                }
                else if (lastLine == "|||" + newusername + " won|||")
                {
                    con.Open();
                    string query1 = "UPDATE users SET wins = wins+1,gamesplayed=gamesplayed+1,userstatus=1 WHERE username ='" + newusername + "';UPDATE users SET losses = losses+1,gamesplayed=gamesplayed+1,userstatus=1 WHERE username ='" + username + "'";
                    NpgsqlCommand cmd1 = new NpgsqlCommand(query1, con);
                    int n = cmd1.ExecuteNonQuery();
                    if (n == 2)
                    {
                        con.Close();
                        return winner;
                    }
                }
                else if (lastLine == "|||The Game ENDED After 100 Rounds|||")
                {
                    con.Open();
                    string query1 = "UPDATE users SET gamesplayed=gamesplayed+1,userstatus=1 WHERE username ='" + newusername + "';UPDATE users SET gamesplayed=gamesplayed+1,userstatus=1 WHERE username ='" + username + "'";
                    NpgsqlCommand cmd1 = new NpgsqlCommand(query1, con);
                    int n = cmd1.ExecuteNonQuery();
                    if (n == 2)
                    {
                        con.Close();
                        return winner;
                    }
                }
                con.Close();
                return "UNKNOWN ERROR";

            }
        }
       
        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(@"Server=localhost;Port=5433;User Id=postgres;Password=postgres;Database=mctg");
        }

    }
}
