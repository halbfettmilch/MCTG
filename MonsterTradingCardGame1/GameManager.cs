using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace MonsterTradingCardGame1
{
    public class GameManager
    {
        private static GameManager single_instance = null;

        private List<User> users = new List<User>();

        



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
        public User getUser(string username)
        {
            int i=0;
            do
            {
               
                if (users.Count<i)
                {
                    Console.WriteLine("ERROR; USER NOT FOUND");
                    break;
                }
                i++;
            } while (users[i].Username != username);
           
            return users[i];
        }
        public void setUser(string username, string password)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Username == username)
                {   
                    Console.WriteLine("ERROR; USER ALLREADY EXISTS");
                    break;
                }
            }
            User newuser = new User(username, password);
            users.Add(newuser);
            Console.WriteLine("USER SET");

        }

        public void deleteUser(string username)
        {
            int i = 0;
            do
            {
                
                if (users[i] == null)
                {
                    Console.WriteLine("ERROR; USER NOT FOUND");
                    break;
                }
                i++;
            } while (users[i].Username != username);
            users.RemoveAt(i);
            Console.WriteLine("USER DELETED");
        }

        /*public void changePassword(string password, string username)
        {
            int i = 0;
            do
            {
                
                if (users[i] == null)
                {
                    Console.WriteLine("ERROR; USER NOT FOUND");
                    break;
                }
                i++;
            } while (users[i].Username != username);

            users[i].Password = password;
            Console.WriteLine("Password changed successfully");
        }
        */



    }
}
