﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterTradingCardGame1
{
    public class OrkBoys : Card
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


            int combatDMG = this._attack;
            if (enemyCard._Race == "Wizzard")
            {
                combatDMG = 0;
            }

            return combatDMG;
        }




    }
}
