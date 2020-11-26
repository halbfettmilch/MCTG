using NUnit.Framework;
using MonsterTradingCardGame1;


namespace MonsterTradingTesting
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var goblintest = new GoblinKing();
            var dragons = new FireDragon();
            int dmg=goblintest.cardBattle(dragons);
            Assert.AreEqual(0,dmg);
        }
    }
}