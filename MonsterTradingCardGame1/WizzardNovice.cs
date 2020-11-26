using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterTradingCardGame1
{
   public class WizzardNovice : Card
    {


       
        public WizzardNovice()
        {
            _Name = "WizzardNovice";
            _Description = "...";
            _Type = 1;
            _element = "Normal";
            _Race = "Wizzard";
            _attack = 2;
        }

        public override int cardBattle(Card enemyCard)
        {

            return 3;
        }




    }
}
