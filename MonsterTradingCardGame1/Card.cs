using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterTradingCardGame1
{
    abstract class Card
    {
        public string _Name { get; protected set;}
        public string _Description { get; protected set; }

        public string _Race { get; protected set; }
        public int _Type { get; protected set; }

        public string _element { get; protected set; }

        public int _attack { get; protected set; }

        public abstract int cardBattle(Card EnemyCard);

        
    }
}
