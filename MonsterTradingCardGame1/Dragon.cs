using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterTradingCardGame1
{
    public class Dragon : Card
    {


        
        public Dragon()
        {
            _Name = "FireDragon";
            _Description = "...";
            _Type = 1;
            _element = "Fire";
            _Race = "Dragon";
            _attack = 4;
        }

        public override int cardBattle(Card enemyCard)
        {

            return 3;
        }




    }
}
