using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterTradingCardGame1
{

    class User
    {
        public string _Username { get; protected set; }
        public string _Password { get; protected set; }
        public string _Email { get; protected set; }

        public int _Coins { get; protected set; }


        public List<Card> stack = new List<Card>();

        public List<Card> deck = new List<Card>();




        public User(string username, string password, string email)
        {
            this._Username = username;
            this._Password = password;
            this._Email = email;
            this._Coins = 20;
            
        }

        
    }
}
