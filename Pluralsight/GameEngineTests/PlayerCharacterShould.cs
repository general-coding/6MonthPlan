using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text.RegularExpressions;

namespace GameEngine.Test
{
    [TestClass()]
    public class PlayerCharacterShould
    {
        PlayerCharacter player;

        [TestInitialize()]
        public void TestInitialize()
        {
            player = new PlayerCharacter
            {
                FirstName = "Alpha",
                LastName = "Bravo"
            };
        }

        [TestMethod()]
        [TestCategory("Player Defaults")]
        public void BeInexperiencedWhenNew()
        {
            Assert.IsTrue(player.IsNoob);
        }

        [TestMethod()]
        [TestCategory("Player Defaults")]
        public void NotHaveNickNameByDefault()
        {
            Assert.IsNull(player.Nickname);
        }

        [TestMethod()]
        [TestCategory("Player Defaults")]
        public void StartWithDefaultHealth()
        {
            Assert.AreEqual(100, player.Health);
        }

        [TestCategory("Player Health")]
        [DataTestMethod()]

        [DynamicData(nameof(ExternalHealthDamageTestData.TestData)
                    , typeof(ExternalHealthDamageTestData))]
        public void TakeDamageTest(int damage, int expectedHealth)
        {
            player.TakeDamage(damage);

            Assert.AreEqual(expectedHealth, player.Health);
        }

        [TestMethod()]
        [TestCategory("Player Health")]
        public void TakeDamageTest_NotEqual()
        {
            player.TakeDamage(1);

            Assert.AreNotEqual(100, player.Health);
        }

        [TestMethod()]
        [TestCategory("Player Health")]
        [TestCategory("Another Category")]
        public void IncreaseHealthAfterSleeping()
        {
            player.Sleep(); //Expect increase between 1 and 100 inclusive

            //Assert.IsTrue(player.Health >= 101 && player.Health <= 200);
            Assert.That.IsInRange(player.Health, 101, 200);
        }

        [TestMethod()]
        public void CalculateFullName()
        {
            Assert.AreEqual("Alpha Bravo", player.FullName);
        }

        [TestMethod()]
        public void CalculateFullName_Caps()
        {
            Assert.AreEqual("ALPHA BRAVO", player.FullName);
        }

        [TestMethod()]
        public void CalculateFullName_IgnoreCase()
        {
            Assert.AreEqual("Alpha Bravo", player.FullName, ignoreCase: true);
        }

        [TestMethod()]
        public void HaveFullNameStartingWithFirstName()
        {
            StringAssert.StartsWith(player.FullName, "Alpha");
        }

        [TestMethod()]
        public void HaveFullNameEndingWithLastName()
        {
            StringAssert.EndsWith(player.FullName, "Bravo");
        }

        [TestMethod]
        public void CalculateFullName_SubstringAssertExample()
        {
            StringAssert.Contains(player.FullName, "ha Br");
        }

        [TestMethod]
        public void CalculateFullNameWithTitleCase()
        {
            StringAssert.Matches(player.FullName, new Regex("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
        }

        [TestMethod]
        public void HaveALongBow()
        {
            CollectionAssert.Contains(player.Weapons, "Long Bow");
        }

        [TestMethod]
        public void NotHaveAStaffOfWonder()
        {
            CollectionAssert.DoesNotContain(player.Weapons, "Staff Of Wonder");
        }

        [TestMethod]
        public void HaveAllExpectedWeapons()
        {
            string[] expectedWeapons = new[]
            {
                "Long Bow",
                "Short Bow",
                "Short Sword"
            };

            //Items must be in the identical order. Or the test fails
            CollectionAssert.AreEqual(expectedWeapons, player.Weapons);
        }

        [TestMethod]
        public void HaveAllExpectedWeapons_AnyOrder()
        {
            string[] expectedWeapons = new[]
            {
                "Short Bow",
                "Long Bow",
                "Short Sword"
            };

            //Items exist in the collection. Need not be in the identical order
            CollectionAssert.AreEquivalent(expectedWeapons, player.Weapons);
        }

        [TestMethod]
        public void HaveNoDuplicateWeapons()
        {
            CollectionAssert.AllItemsAreUnique(player.Weapons);
        }

        [TestMethod]
        public void HaveAtLeastOneKindOfSword()
        {
            //Assert.IsTrue(player.Weapons.Any(weapon => weapon.Contains("Sword")));
            CollectionAssert.That.AtLeastOneItemSatisfies(player.Weapons,
                                                          weapon => weapon.Contains("Sword"));
        }

        [TestMethod]
        public void HaveNoEmptyDefaultWeapons()
        {
            //Assert.IsFalse(player.Weapons.Any(weapon => string.IsNullOrWhiteSpace(weapon)));

            //CollectionAssert.That.AllItemsNotNullOrWhitespace(player.Weapons);

            //player.Weapons.Add(" ");

            //CollectionAssert.That.AllItemsSatisfy(player.Weapons,
            //      weapon => !string.IsNullOrWhiteSpace(weapon));

            CollectionAssert.That.All(player.Weapons, weapon =>
            {
                StringAssert.That.NotNullOrWhiteSpace(weapon);
                Assert.IsTrue(weapon.Length > 5);
            });
        }
    }
}