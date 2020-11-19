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

        public string response { get; set; }

        



        //Only a Single instance shall exist so it does not get deleted by multithreading

        public static GameManager getInstance()
        {
            if (single_instance == null)
            {
                single_instance = new GameManager();
            }
            return single_instance;
        }

       public void setLoad(GameManager manager)
        {
            manager.response = this.response;
        }


        // functions to interact with private components
        public User getUser(string username)
        {
            try
            {


                for (int i = 0; i < users.Count; i++)
                {
                    if ((users[i].Username == username))
                    {
                        Console.WriteLine("USER found:  {0}", users[i].Username);
                        this.response = "USER found:  {0}" + users[i].Username;
                        return users[i];
                        
                    }
                }
                throw new Exception("ERROR; USER NOT FOUND");
                
            }
            catch (Exception exc)
            {
                Console.WriteLine("{0}",exc);
                return new User("","");
            }



        }
        public void setUser(string username, string password)
        {
            try
            {


                for (int i = 0; i < users.Count; i++)
                {
                    if ((users[i].Username == username))
                    {
                        throw new Exception("ERROR; USER ALLREADY EXISTS");
                      
                    }
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine("{0}", exc);
                return;

            }
            User newuser = new User(username, password);
            users.Add(newuser);
            Console.WriteLine("USER SET");

        }

        public void deleteUser(string username)
        {
            try
            {


                for (int i = 0; i < users.Count; i++)
                {
                    if ((users[i].Username == username))
                    {   
                        Console.WriteLine("USER DELETED:  {0}", users[i].Username);
                        users.RemoveAt(i);
                        return;
                    }
                }
                throw new Exception("NO SUCH USER FOUND");

            }
            catch (Exception exc)
            {
                Console.WriteLine("{0}", exc);
            }
        }

       


    }
}
