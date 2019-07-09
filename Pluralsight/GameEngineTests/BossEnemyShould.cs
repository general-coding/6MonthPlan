using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameEngine.Test
{
    [TestClass]
    public class BossEnemyShould
    {
        [TestMethod]
        public void HaveCorrectSpecialAttackPower()
        {
            BossEnemy boss = new BossEnemy();

            //The 0.07 is the delta. It the accuracy required when
            //performing the assert
            //This assert will fail, only if the result is more than
            //the specified delta
            Assert.AreEqual(166.6, boss.SpecialAttackPower, 0.07);
        }
    }
}
