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
    }
}