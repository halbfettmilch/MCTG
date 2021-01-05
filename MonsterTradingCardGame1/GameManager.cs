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
                
            }
            return package;
        }

        // Interaction with Database
       
        public string setUser(string username, string password)
        {
            return DatabaseService.InsertUser(username, password);
        }

        public string deleteUser(string username)
        {
            return DatabaseService.DeleteUser(username);
        }

        public string GetUser(string username)
        {
            return DatabaseService.GetUser(username);
        }
         public string UpdateUser(string username, string userbio, string userimage)
        {
            return DatabaseService.UpdateUser(username,userbio,userimage);
        }
        public string GetUserStats(string username)
        {
            return DatabaseService.GetUserStats(username);
        }
        public string GetScoreboard()
        {
            return DatabaseService.GetScoreboard();
        }
        public string login(string username, string password)
        {
            return DatabaseService.LogInUser(username, password);
        }
        public string logout(string username, string password)
        {
            return DatabaseService.LogOutUser(username, password);
        }

        public string acuirePackage(string username)
        {
            Package package = createPackage();
            return DatabaseService.OpenPackage(username, package);
        }

        public string ShowAllCards(string username)
        {
            return DatabaseService.GetAllCards(username);
        }

        public string ShowUserStackcards(string username)
        {
            return DatabaseService.GetStackCards(username);
        }

        public string ShowDeckCards(string username)
        {
            return DatabaseService.GetDeckCards(username);
        }

        public string MoveCardToDeck(int cardID, string cardowner)
        {
            return DatabaseService.MoveCardToDeck(cardID, cardowner);
        }

        public string MoveCardToStack(int cardID, string cardowner)
        {
            return DatabaseService.MoveCardToStack(cardID, cardowner);
        }

        public string ShowAllTradings()
        {
            return DatabaseService.ShowALLCardsForSAle();
        }

        public string ShowTradesForUser(string username)
        {
            return DatabaseService.ShowALLCardsForSAleForUSer(username);
        }

        public string PutCardToTrade(string cardowner, int cardID, int price)
        {
            return DatabaseService.CreateTradeDeal(cardowner, price, cardID);
        }

        public string DeleteTradeDeal(string cardowner, int cardID)
        {
            return DatabaseService.DeleteTradeDeal(cardowner, cardID);
        }

        public string BuyCard(string newcardowner, int cardID)
        {
            return DatabaseService.BuyACard(newcardowner,cardID);
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

    }






}
