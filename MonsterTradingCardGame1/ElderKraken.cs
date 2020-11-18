using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace MonsterTradingCardGame1
{
    public class ElderKraken : Card
    {


        
        public ElderKraken()
        {
            _Name = "ElderKraken";
            _Description = "...";
            _Type = 1;
            _element = "Water";
            _Race = "Kraken";
            _attack = 8;
        }

        public override int cardBattle(Card enemyCard)
        {

            int CombatDMG = this._attack;
            if (enemyCard._Type == 2)
            {
                CombatDMG = 0;
            }

            

            return CombatDMG;
        }




    }
}
