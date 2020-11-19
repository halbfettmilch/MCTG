using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterTradingCardGame1
{
    public class Goblin : Card
    {


        
        public Goblin()
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
            int CombatDMG = this._attack;
            if (enemyCard._Race == "Dragon")
            {
                CombatDMG = 0;
            }

            return CombatDMG;
            
            
        }
        

       
        
    }
}
