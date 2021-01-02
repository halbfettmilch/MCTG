using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace MonsterTradingCardGame1
{
    public class GameManager
    {
        private static GameManager single_instance = null;

        private List<User> users = new List<User>();

        private List<User> loggedIn = new List<User>();

        private List<Card> cardlist = new List<Card>();

        public static GameManager getInstance()
        {
            if (single_instance == null)
            {
                single_instance = new GameManager();
            }
            single_instance.cardlist.Add(new GoblinKing());
            single_instance.cardlist.Add(new ElderKraken());
            single_instance.cardlist.Add(new OrkBoys());
            single_instance.cardlist.Add(new FireDragon());
            single_instance.cardlist.Add(new FireElveShaman());
            single_instance.cardlist.Add(new GreyKnight());
            single_instance.cardlist.Add(new WizzardNovice());
            return single_instance;
        }






        // help functions

        public Card returnRandomCard()
        {
            Random rnd = new Random();
            int number = rnd.Next(0, cardlist.Count);
            Card random = cardlist[number];
            return random;

        }
        private Package createPackage()
        {
            Package package = new Package();
            for (int j = 0; j < package.size; j++)
            {
                package.package.Add(returnRandomCard());
                // response += j + " " + randomcard._Name +"\n";
            }

            return package;

        }



        // Interaction with Database
        public string getUser(string username)
        {
            try
            {


                for (int i = 0; i < users.Count; i++)
                {
                    if ((users[i].Username == username))
                    {
                        Console.WriteLine("USER found:  {0}", users[i].Username);

                        return "User found: " + users[i].Username;

                    }
                }
                throw new Exception("ERROR; USER NOT FOUND");

            }
            catch (Exception exc)
            {
                Console.WriteLine("{0}", exc);
                return "User not found";
            }



        }
        public string setUser(string username, string password)
        {

            return DatabaseService.InsertUser(username, password);



        }

        public string deleteUser(string username)
        {

            return DatabaseService.DeleteUser(username);


        }

        public string login(string username, string password)
        {
            return DatabaseService.LogInUser(username, password);
        }
        public string logout(string username, string password)
        {
            return DatabaseService.LogOutUser(username, password);
        }

        //Card battle logic
        public string battleLogic(Card card1, Card card2)
        {
            if (card1.cardBattle(card2) > card2.cardBattle(card1))
            {
                return "The card " + card1._Name + "of player 1 won";
            }
            else if (card1.cardBattle(card2) < card2.cardBattle(card1))
            {
                return "The card " + card2._Name + "of player 2 won";
            }

            return "The cards were of Equal Power";
        }


        public string acuirePackage(string username)
        {
            string response = "";
            Package package = createPackage();
            for (int i = 0; i < package.size; i++)
            {
                response += DatabaseService.OpenPackage(package.package[i]._Name, username);
            }
            return response;
        }

       

        public string showUsercards(string username)
        {
            return DatabaseService.GetStackCards(username);
        }
    }






}
