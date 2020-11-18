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
                i++;
                if (users.Count<i)
                {
                    Console.WriteLine("ERROR; USER NOT FOUND");
                    break;
                }
            } while (users[i]._Username != username);
           
            return users[i];
        }
        public void setUser(string username, string password)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i]._Username == username)
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
                i++;
                if (users[i] == null)
                {
                    Console.WriteLine("ERROR; USER NOT FOUND");
                    break;
                }
            } while (users[i]._Username != username);
            users.RemoveAt(i);
            Console.WriteLine("USER DELETED");
        }

        public void changePassword(string password, string username)
        {
            int i = 0;
            do
            {
                i++;
                if (users[i] == null)
                {
                    Console.WriteLine("ERROR; USER NOT FOUND");
                    break;
                }
            } while (users[i]._Username != username);

            users[i]._Password = password;
            Console.WriteLine("Password changed successfully");
        }



        /*
        public string getMSG(int id)
        {
            if (id - 1 < users.Count && id > 0)
            {
                return users[id - 1];
            }

            return "ERROR, there is no message with the id" + id;
        }

        public string getAllMessages()
        {
            if (users.Count > 0)
            {
                string messages = "";
                for (int i = 0; i < users.Count; i++)
                {
                    messages += (i + 1) + ": " + users[i] + " ";
                }
                messages += "\rn\n";
                return messages;

            }
            return "There are currently no messages";
        }

        public int addMessage(string message)
        {
            users.Add(message);
            return users.Count;
        }

        public string deleteMessage(int id)
        {

            if (id - 1 < users.Count && id > 0)
            {
                users.RemoveAt(id - 1);
                return "message " + (id) + " was deleted";
            }
            return "ERROR, there is no message with the id" + id;
        }

        public string updateMessage(int id, string message)
        {
            if (id - 1 < users.Count && id > 0)
            {
                users[id - 1] = message;
                return "message " + (id) + "was updated";
            }
            return "ERROR, there is no message with the id" + id;
        }
        */



    }
}
