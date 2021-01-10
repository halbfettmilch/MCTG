using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterTradingCardGame1
{
    public class GoblinKing : Card
    {


        
        public GoblinKing()
        {
            _Name = "GoblinKing";
            _Description = "...";
            _Type = 1;
            _element = "Normal";
            _Race = "Goblin";
            _attack = 5;
        }

        public override int cardBattle(Card enemyCard)
        {
            int combatDMG = this._attack;
            if (enemyCard._Race == "Dragon")
            {
                combatDMG = 0;
            }

            return combatDMG;
            
            
        }
        

       
        
    }
}
