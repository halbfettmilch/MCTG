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
        public void CombatTestsCards()
        {
            var goblinking = new GoblinKing();
            var fireDragon = new FireDragon();
            var wizzardNovice= new WizzardNovice();
            var elderKraken = new ElderKraken();
            var greyKnight = new GreyKnight();
            var orkBoyz = new OrkBoys();
            var fireElveShaman = new FireElveShaman();
            var fireball = new Fireball();
            var giantWave = new GiantWave();


            int dmg=goblinking.cardBattle(fireDragon);
            Assert.AreEqual(0,dmg);
            dmg = goblinking.cardBattle(wizzardNovice);
            Assert.AreEqual(5, dmg);
            dmg = goblinking.cardBattle(elderKraken);
            Assert.AreEqual(5, dmg);
            dmg = elderKraken.cardBattle(elderKraken);
            Assert.AreEqual(8, dmg);
            dmg = goblinking.cardBattle(fireDragon);
            Assert.AreEqual(0, dmg);
            dmg = fireDragon.cardBattle(fireDragon);
            Assert.AreEqual(4, dmg);
            dmg = fireElveShaman.cardBattle(fireDragon);
            Assert.AreEqual(5, dmg);
            dmg = wizzardNovice.cardBattle(fireDragon);
            Assert.AreEqual(2, dmg);
            dmg = greyKnight.cardBattle(fireDragon);
            Assert.AreEqual(3, dmg);
            dmg = greyKnight.cardBattle(giantWave);
            Assert.AreEqual(0, dmg);
            dmg = elderKraken.cardBattle(fireball);
            Assert.AreEqual(8, dmg);
            dmg = fireball.cardBattle(elderKraken);
            Assert.AreEqual(0, dmg);
            dmg = giantWave.cardBattle(elderKraken);
            Assert.AreEqual(0, dmg);
            dmg = orkBoyz.cardBattle(wizzardNovice);
            Assert.AreEqual(0, dmg);
            dmg = elderKraken.cardBattle(fireDragon);
            Assert.AreEqual(8, dmg);
            dmg = greyKnight.cardBattle(elderKraken);
            Assert.AreEqual(0, dmg);
            dmg = greyKnight.cardBattle(fireball);
            Assert.AreEqual(3, dmg);
            dmg = orkBoyz.cardBattle(fireDragon);
            Assert.AreEqual(3, dmg);
            dmg = orkBoyz.cardBattle(wizzardNovice);
            Assert.AreEqual(0, dmg);
            dmg = elderKraken.cardBattle(fireDragon);
            Assert.AreEqual(8, dmg);
            dmg = elderKraken.cardBattle(fireball);
            Assert.AreEqual(8, dmg);
            dmg = fireball.cardBattle(elderKraken);
            Assert.AreEqual(0, dmg);
            dmg = giantWave.cardBattle(elderKraken);
            Assert.AreEqual(0, dmg);
            dmg = orkBoyz.cardBattle(wizzardNovice);
            Assert.AreEqual(0, dmg);
            dmg = elderKraken.cardBattle(fireDragon);
            Assert.AreEqual(8, dmg);
            dmg = elderKraken.cardBattle(fireball);
            Assert.AreEqual(8, dmg);
            dmg = goblinking.cardBattle(wizzardNovice);
            Assert.AreEqual(5, dmg);
            dmg = greyKnight.cardBattle(fireball);
            Assert.AreEqual(3, dmg);
            dmg = orkBoyz.cardBattle(fireDragon);
            Assert.AreEqual(3, dmg);
            dmg = goblinking.cardBattle(elderKraken);
            Assert.AreEqual(5, dmg);
            dmg = goblinking.cardBattle(goblinking);
            Assert.AreEqual(5, dmg);
            dmg = goblinking.cardBattle(fireDragon);
            Assert.AreEqual(0, dmg);
            dmg = fireDragon.cardBattle(fireDragon);
            Assert.AreEqual(4, dmg);
            dmg = greyKnight.cardBattle(fireball);
            Assert.AreEqual(3, dmg);
            dmg = orkBoyz.cardBattle(fireDragon);
            Assert.AreEqual(3, dmg);


        }
        
    }
}