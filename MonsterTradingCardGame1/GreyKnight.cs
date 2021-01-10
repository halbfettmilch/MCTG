using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterTradingCardGame1
{
    public class GreyKnight : Card
    {


       
        public GreyKnight()
        {
            _Name = "GreyKnight";
            _Description = "...";
            _Type = 1;
            _element = "Normal";
            _Race = "Knight";
            _attack = 3;
        }

        public override int cardBattle(Card enemyCard)
        {

            int combatDMG = this._attack;
            if (enemyCard._element == "Water")
            {
                combatDMG = 0;
            }

            return combatDMG;
        }




    }
}
