using System;
using NUnit.Framework;

namespace MythicLegion.Tests
{
    public class Tests
    {
        private Legion legion;
        private Hero hero;

        [SetUp]
        public void Setup()
        {
            legion = new Legion();
            hero = new Hero("Kolio", "Spartan");
        }

        [Test]
        public void AddHeroValid()
        {
            legion.AddHero(hero);
            string info = legion.GetLegionInfo();
            Assert.IsTrue(info.Contains("Kolio (Spartan)"));
        }

        [Test]
        public void AddHeroThrowNullExceptionl()
        {
            Assert.Throws<ArgumentNullException>(() => legion.AddHero(null));
        }

        [Test]
        public void AddHeroThrowExceptionWithSameNameExists()
        {
            legion.AddHero(hero);
            var duplicate = new Hero("Kolio", "Vecherka");
            Assert.Throws<ArgumentException>(() => legion.AddHero(duplicate));
        }

        [Test]
        public void RemoveHeroWhenExists()
        {
            legion.AddHero(hero);
            bool result = legion.RemoveHero("Kolio");
            Assert.IsTrue(result);
            Assert.IsTrue(legion.GetLegionInfo() == "No heroes in the legion.");
        }

        [Test]
        public void RemoveHeroReturnFalseWhenHeroDoesNotExist()
        {
            bool result = legion.RemoveHero("NonExistingHero");
            Assert.IsFalse(result);
        }

        [Test]
        public void TrainIncreasePowerAndHealth()
        {
            legion.AddHero(hero);
            string result = legion.TrainHero("Kolio");
            Assert.AreEqual("Kolio has been trained.", result);
            Assert.AreEqual(30, hero.Power); 
            Assert.AreEqual(101, hero.Health); 
            Assert.IsTrue(hero.IsTrained);
        }

        [Test]
        public void TrainHeroReturnNotFoundMessage()
        {
            string result = legion.TrainHero("NonExistingHero");
            Assert.AreEqual("Hero with name NonExistingHero not found.", result);
        }

        [Test]
        public void GetLegionInfo()
        {
            var hero2 = new Hero("Spaska", "Vecherka");
            legion.AddHero(hero);
            legion.AddHero(hero2);

            string info = legion.GetLegionInfo();
            Assert.IsTrue(info.Contains("Kolio (Spartan)"));
            Assert.IsTrue(info.Contains("Spaska (Vecherka)"));
        }

        [Test]
        public void GetLegionInfoIsEmpty()
        {
            string info = legion.GetLegionInfo();
            Assert.AreEqual("No heroes in the legion.", info);
        }
    }
}