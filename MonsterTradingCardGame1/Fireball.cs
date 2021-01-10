﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterTradingCardGame1
{
    public class Fireball : Card
    {



        public Fireball()
        {
            _Name = "Fireball";
            _Description = "...";
            _Type = 2;
            _element = "Fire";
            _Race = "";
            _attack = 10;
        }

        public override int cardBattle(Card enemyCard)
        {


            int combatDMG = this._attack;
            if (enemyCard._Race == "Kraken")
            {
                combatDMG = 0;
            }

            return combatDMG;
        }




    }
}