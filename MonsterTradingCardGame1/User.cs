using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterTradingCardGame1
{

    public class User
    {
        public string Username { get;  set; }
        public string Password { get;  set; }
       

        public int Coins { get;  set; }


        public List<Card> stack = new List<Card>();

        public List<Card> deck = new List<Card>();




        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
           
            this.Coins = 20;
            
        }

        
    }
}
