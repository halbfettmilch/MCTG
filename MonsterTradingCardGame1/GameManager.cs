using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Card random=cardlist[number];
            return random;

        }




        // functions to interact with private components
        public string getUser(string username)
        {
            try
            {


                for (int i = 0; i < users.Count; i++)
                {
                    if ((users[i].Username == username))
                    {
                        Console.WriteLine("USER found:  {0}", users[i].Username);
                        
                        return "User found: "+ users[i].Username;
                        
                    }
                }
                throw new Exception("ERROR; USER NOT FOUND");
                
            }
            catch (Exception exc)
            {
                Console.WriteLine("{0}",exc);
                return "User not found";
            }



        }
        public string setUser(string username, string password)
        {
            try
            {


                for (int i = 0; i < users.Count; i++)
                {
                    if ((users[i].Username == username))
                    {
                        throw new Exception("Username allready in use");
                        
                    }
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine("{0}", exc);
                return "User allready exists";

            }
            User newuser = new User(username, password);
            users.Add(newuser);
            Console.WriteLine("NEW USER CREATED");
            return "New User Created";

        }

        public string deleteUser(string username)
        {
            try
            {


                for (int i = 0; i < users.Count; i++)
                {
                    if ((users[i].Username == username))
                    {   
                        Console.WriteLine("USER DELETED:  {0}", users[i].Username);
                        users.RemoveAt(i);
                        return "User deleted";
                    }
                }
                throw new Exception("NO SUCH USER FOUND");

            }
            catch (Exception exc)
            {
                Console.WriteLine("{0}", exc);
                return "Could not find that User";
            }
        }

        public string login(string username, string password)
        {
            try
            {
                //hier function zum ausloggen oder einloggen je nach status

                for (int i = 0; i < loggedIn.Count; i++)
                {
                    if ((loggedIn[i].Username == username && loggedIn[i].Password == password))
                    {
                        Console.WriteLine("USER LOGGED OUT  {0}", loggedIn[i].Username);
                        loggedIn.RemoveAt(i);
                        return "Log out was successful";
                    }
                }

                for (int i = 0; i < users.Count; i++)
                {
                    if ((users[i].Username == username && users[i].Password==password))
                    {
                        Console.WriteLine("USER LOGGED IN  {0}", users[i].Username);
                        User newuser = new User(username, password);
                        loggedIn.Add(newuser);
                        return "Log in was successful";
                    }
                }
                throw new Exception("USERNAME OR PASSWORD WRONG");

            }
            catch (Exception exc)
            {
                Console.WriteLine("{0}", exc);
                return "The Username or Password is Wrong";
            }
        }
        public string logout(string username, string password)
        {
            try
            {
                //Hier function nur zum ausloggen

                for (int i = 0; i < loggedIn.Count; i++)
                {
                    if ((loggedIn[i].Username == username && loggedIn[i].Password == password))
                    {
                        Console.WriteLine("USER LOGGED OUT  {0}", loggedIn[i].Username);
                        
                        return "Log out was successful";
                    }
                }
                throw new Exception("USERNAME OR PASSWORD WRONG");

            }
            catch (Exception exc)
            {
                Console.WriteLine("{0}", exc);
                return "The Username or Password is Wrong or User is currently not logged in";
            }
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

            return "The card were of Equal Power";
        }

        public string acuirePackage(string username)
        {
            
           
            for (int i = 0; i < users.Count; i++)
            {
                if ((users[i].Username == username))
                {
                    Console.WriteLine("USER found:  {0}", users[i].Username);
                    Package package = new Package();
                    if (users[i].Coins < package.price)
                    {
                        return "not enough coins";
                    }

                    for (int j = 0; j < package.size; j++)
                    {
                       
                        package.package.Add(returnRandomCard());
                        // response += j + " " + randomcard._Name +"\n";
                    }
                    users[i].packages.Add(package);
                    users[i].Coins -= package.price;
                    return users[i].Username + " bought a package";


                }
            }

            return "user not found";
        }

        public string openPackage(string username)
        {
            string response = "Cards found: \n";
            for (int i = 0; i < users.Count; i++)
            {
                if ((users[i].Username == username))
                {
                    Console.WriteLine("USER found:  {0}", users[i].Username);
                    if (users[i].packages.Count > 0)
                    {
                        Package userpackage = users[i].packages[0];
                        for (int j = 0; j < userpackage.size; j++)
                        {
                            users[i].stack.Add(userpackage.package[j]);
                            response +="Card "+ (j+1) +" : " + userpackage.package[j]._Name + "\n";
                        }
                        users[i].packages.RemoveAt(0);
                        users[i].stack.Sort((x, y) => x._Name.CompareTo(y._Name));
                        return response;
                    }

                    response = "No packages left";
                    return response;
                }
            }

            response = "User " + username + " not found";
            return response;
        }

        public string showUsercards(string username)
        {
            int j = 1;
            string response="ALL Cards:\n";
            for (int i = 0; i < users.Count; i++)
            {
                if ((users[i].Username == username))
                {
                    Console.WriteLine("USER found:  {0}", users[i].Username);
                    foreach (Card card in users[i].stack)
                    {
                        response += j + " " + card._Name + "\n";
                        j++;
                    }
                    return response;
                }
            }
            response = "User " + username + " not found";
            return response;
        }
    }


       


    
}
