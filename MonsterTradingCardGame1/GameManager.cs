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









        //Only a Single instance shall exist so it does not get deleted by multithreading

        public static GameManager getInstance()
        {
            if (single_instance == null)
            {
                single_instance = new GameManager();
            }
            return single_instance;
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
    }

        

       


    
}
