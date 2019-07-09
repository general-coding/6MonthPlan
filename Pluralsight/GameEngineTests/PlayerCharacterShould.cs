using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text.RegularExpressions;

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

        [TestMethod()]
        public void CalculateFullName()
        {
            PlayerCharacter player = new PlayerCharacter
            {
                FirstName = "Alpha",
                LastName = "Bravo"
            };

            Assert.AreEqual("Alpha Bravo", player.FullName);
        }

        [TestMethod()]
        public void CalculateFullName_Caps()
        {
            PlayerCharacter player = new PlayerCharacter
            {
                FirstName = "Alpha",
                LastName = "Bravo"
            };

            Assert.AreEqual("ALPHA BRAVO", player.FullName);
        }

        [TestMethod()]
        public void CalculateFullName_IgnoreCase()
        {
            PlayerCharacter player = new PlayerCharacter
            {
                FirstName = "Alpha",
                LastName = "Bravo"
            };

            Assert.AreEqual("Alpha Bravo", player.FullName, ignoreCase: true);
        }

        [TestMethod()]
        public void HaveFullNameStartingWithFirstName()
        {
            PlayerCharacter player = new PlayerCharacter
            {
                FirstName = "Alpha",
                LastName = "Bravo"
            };

            //Assert.IsTrue(player.FullName.StartsWith("Alpha"));

            StringAssert.StartsWith(player.FullName, "Alpha");
        }

        [TestMethod()]
        public void HaveFullNameEndingWithLastName()
        {
            PlayerCharacter player = new PlayerCharacter
            {
                FirstName = "Alpha",
                LastName = "Bravo"
            };

            //Assert.IsTrue(player.FullName.EndsWith("Bravo"));

            StringAssert.EndsWith(player.FullName, "Bravo");
        }

        [TestMethod]
        public void CalculateFullName_SubstringAssertExample()
        {
            PlayerCharacter player = new PlayerCharacter
            {
                FirstName = "Alpha",
                LastName = "Bravo"
            };

            StringAssert.Contains(player.FullName, "ha Br");
        }

        [TestMethod]
        public void CalculateFullNameWithTitleCase()
        {
            PlayerCharacter player = new PlayerCharacter
            {
                FirstName = "Alpha",
                LastName = "Bravo"
            };

            StringAssert.Matches(player.FullName, new Regex("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
            //StringAssert.DoesNotMatch(player.FullName, new Regex("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
        }

        [TestMethod]
        public void HaveALongBow()
        {
            PlayerCharacter player = new PlayerCharacter();

            CollectionAssert.Contains(player.Weapons, "Long Bow");
        }

        [TestMethod]
        public void NotHaveAStaffOfWonder()
        {
            PlayerCharacter player = new PlayerCharacter();

            CollectionAssert.DoesNotContain(player.Weapons, "Staff Of Wonder");
        }

        [TestMethod]
        public void HaveAllExpectedWeapons()
        {
            PlayerCharacter player = new PlayerCharacter();

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
            PlayerCharacter player = new PlayerCharacter();

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
            PlayerCharacter player = new PlayerCharacter();

            //player.Weapons.Add("Short Bow");

            CollectionAssert.AllItemsAreUnique(player.Weapons);
        }

        [TestMethod]
        public void HaveAtLeastOneKindOfSword()
        {
            PlayerCharacter player = new PlayerCharacter();

            Assert.IsTrue(player.Weapons.Any(weapon => weapon.Contains("Sword")));
        }

        [TestMethod]
        public void HaveNoEmptyDefaultWeapons()
        {
            PlayerCharacter player = new PlayerCharacter();

            Assert.IsFalse(player.Weapons.Any(weapon => string.IsNullOrWhiteSpace(weapon)));
        }
    }
}