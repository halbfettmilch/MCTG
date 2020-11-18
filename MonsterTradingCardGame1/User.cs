using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterTradingCardGame1
{

    public class User
    {
        public string _Username { get;  set; }
        public string _Password { get;  set; }
       

        public int _Coins { get;  set; }


        public List<Card> stack = new List<Card>();

        public List<Card> deck = new List<Card>();




        public User(string username, string password)
        {
            this._Username = username;
            this._Password = password;
           
            this._Coins = 20;
            
        }

        
    }
}
