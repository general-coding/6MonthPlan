using GameEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameEngine.Test
{
    [TestClass()]
    public class PlayerCharacterShould
    {
        [TestMethod()]
        public void BeInexperiencedWhenNew()
        {
            PlayerCharacter player = new PlayerCharacter();

            Assert.IsTrue(player.IsNoob);
        }

        [TestMethod()]
        public void NotHaveNickNameByDefault()
        {
            PlayerCharacter player = new PlayerCharacter();

            Assert.IsNull(player.Nickname);
        }

        [TestMethod()]
        public void StartWithDefaultHealth()
        {
            PlayerCharacter player = new PlayerCharacter();

            Assert.AreEqual(100, player.Health);
        }

        [TestMethod()]
        public void TakeDamageTest()
        {
            PlayerCharacter player = new PlayerCharacter();

            player.TakeDamage(1);

            Assert.AreEqual(99, player.Health);
        }

        [TestMethod()]
        public void TakeDamageTest_NotEqual()
        {
            PlayerCharacter player = new PlayerCharacter();

            player.TakeDamage(1);

            Assert.AreNotEqual(100, player.Health);
        }

        [TestMethod()]
        public void IncreaseHealthAfterSleeping()
        {
            PlayerCharacter player = new PlayerCharacter();

            player.Sleep(); //Expect increase between 1 and 100 inclusive

            Assert.IsTrue(player.Health >= 101 && player.Health <= 200);
        }
    }
}