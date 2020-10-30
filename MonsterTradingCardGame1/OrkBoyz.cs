using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterTradingCardGame1
{
    class OrkBoys : Card
    {


        
        public OrkBoys()
        {
            _Name = "OrkBoys";
            _Description = "...";
            _Type = 1;
            _element = "Normal";
            _Race = "Ork";
            _attack = 3;
        }

        public override int cardBattle(Card enemyCard)
        {


            int CombatDMG = this._attack;
            if (enemyCard._Race == "Wizzard")
            {
                CombatDMG = 0;
            }

            return CombatDMG;
        }




    }
}
