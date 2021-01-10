using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterTradingCardGame1
{
    public class FireElveShaman : Card
    {


        
        public FireElveShaman()
        {
            _Name = "FireElveShaman";
            _Description = "...";
            _Type = 1;
            _element = "Fire";
            _Race = "FireElve";
            _attack = 5;
        }

        public override int cardBattle(Card enemyCard)
        {

            int combatDMG = this._attack;
            

            return combatDMG;
        }




    }
}
