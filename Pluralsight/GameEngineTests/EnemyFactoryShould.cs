using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GameEngine.Tests
{
    [TestClass]
    [TestCategory("Enemy Creation")]
    public class EnemyFactoryShould
    {
        [TestMethod]
        public void NotAllowNullName()
        {
            Console.WriteLine("Creating EnemyFactory");
            EnemyFactory factory = new EnemyFactory();

            Console.WriteLine("Calling Create method");
            Assert.ThrowsException<ArgumentNullException>
            (
                () => factory.Create(null)
            );
        }

        [TestMethod]
        public void OnlyAllowKingOrQueenBossEnemies()
        {
            EnemyFactory factory = new EnemyFactory();

            EnemyCreationException ex = Assert.ThrowsException<EnemyCreationException>
                                        (
                                            () => factory.Create("Zombie", true)
                                        );

            Assert.AreEqual("Zombie", ex.RequestedEnemyName);
        }

        [TestMethod]
        public void CreateNormalEnemyByDefault()
        {
            EnemyFactory factory = new EnemyFactory();

            Enemy enemy = factory.Create("Zombie");

            Assert.IsInstanceOfType(enemy, typeof(NormalEnemy));
        }

        //[TestMethod]
        //public void CreateNormalEnemyByDefault_NotTypeExample()
        //{
        //    EnemyFactory factory = new EnemyFactory();

        //    Enemy enemy = factory.Create("Zombie");

        //    Assert.IsNotInstanceOfType(enemy, typeof(NormalEnemy));
        //}

        [TestMethod]
        public void CreateBossEnemy()
        {
            EnemyFactory factory = new EnemyFactory();

            Enemy enemy = factory.Create("Zombie King", true);

            Assert.IsInstanceOfType(enemy, typeof(BossEnemy));
        }

        [TestMethod]
        public void CreateSeparateInstances()
        {
            EnemyFactory factory = new EnemyFactory();

            Enemy enemy1 = factory.Create("Zombie");
            Enemy enemy2 = factory.Create("Zombie");

            Assert.AreNotSame(enemy1, enemy2);
        }
    }
}
