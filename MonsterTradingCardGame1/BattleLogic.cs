using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterTradingCardGame1
{
    public class BattleLogic
    {
        GameManager Gamebuffer = GameManager.getInstance();
        public List<Card> CreatebattleDecks(string[] pcards)
        {   
            List<Card> playerdeck = new List<Card>();
            for (int j = 0; j < pcards.Length; j++)
            {
                for (int i = 0; i < Gamebuffer.cardlist.Count; i++)
                {
                    if (Gamebuffer.cardlist[i]._Name == pcards[j])
                    {   //Console.WriteLine(Gamebuffer.cardlist[i]._Name);
                        playerdeck.Add(Gamebuffer.cardlist[i]);
                    }
                }
            }
            return playerdeck;
        }
        public string battle(string user1, string user2, string[] p1cards, string[] p2cards)
        {
            string battleLog = "Battle has started \n";
            List<Card> player1deck = CreatebattleDecks(p1cards);
            List<Card> player2deck = CreatebattleDecks(p2cards);
            for (int i = 0; i < 100; i++)
            {
                battleLog += "Round " + i + ":\n";
                Card p1card = Gamebuffer.returnRandomCard(player1deck);
                Card p2card = Gamebuffer.returnRandomCard(player2deck);
                battleLog += user1+" played: " + p1card._Name + "\n";
                battleLog += user2+" played: " + p2card._Name + "\n";
                if (CardBattle(p1card, p2card) == 1)
                {
                    battleLog += p1card._Name+ "Won the " + i + "st round\n -------------------------\n";
                    player1deck.Add(p2card);
                    player2deck.Remove(p2card);
                }
                else if (CardBattle(p1card, p2card) == 2)
                {
                    battleLog += p2card._Name + "Won the "+i+"st round\n -------------------------\n";
                    player2deck.Add(p1card);
                    player1deck.Remove(p1card);
                }
                else
                {
                    battleLog += "The " + i + "st round was a Tie\n -------------------------\n";
                }

                if (player2deck.Count == 0)
                {
                    battleLog +="|||"+user1+" won|||";
                    return battleLog;
                }
                if (player1deck.Count == 0)
                {
                    battleLog +="|||"+user2+" won|||";
                    return battleLog;
                }
                Console.WriteLine(battleLog);

            }

            battleLog += "|||The Game ENDED After 100 Rounds|||";
            return battleLog;
        }


        public int CardBattle(Card card1, Card card2)
        {
            if (card1.cardBattle(card2) > card2.cardBattle(card1))
            {
                return 1;
            }
            if (card1.cardBattle(card2) < card2.cardBattle(card1))
            {
                return 2;
            }

            return 0;
        }
    }
}
