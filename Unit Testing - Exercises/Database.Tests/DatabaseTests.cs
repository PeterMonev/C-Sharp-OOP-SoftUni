namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private Database db;

        [SetUp]

        public void SetUp()
        {
            db = new Database(1, 2);
        }

        [Test]
        public void CreatingDatabaseIsCorrect()
        {
            Assert.That(db.Count, Is.EqualTo(2));
        }

        [Test]

        public void CreatingDatabaseIsNull()
        {
            Assert.IsNotNull(db);
        }

        [Test]

        public void StoringCapacityIs16()
        {
            Database database = new Database();

            for (int i = 0; i < 16; i++)
            {
                database.Add(i);
            }

            Assert.That(database.Count, Is.EqualTo(16));
        }

        [Test]
        public void StoringCapacityIsGreater()
        {
            Database database = new Database();

            Assert.Throws<InvalidOperationException>(() =>
            {
                for (int i = 0; i < 17; i++)
                {
                    database.Add(i);
                }

            }, "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void DatabaseCountShouldWorkCorrectly()
        {
            int expectedResult = 2;

            Assert.AreEqual(expectedResult, db.Count);
        }

        [TestCase(10)]
        [TestCase(-5)]
        public void DatabaseAddMethodShouldIncreaseCount(int number)
        {
            int expResult = 3;

            db.Add(number);

            Assert.AreEqual(expResult, db.Count);
        }

        [Test]

        public void RemoveCorrectly()
        {
            Database database = new Database(1);

            database.Remove();

            Assert.AreEqual(0, database.Count);
        }

        [Test]

        public void RemoveIsntWork()
        {
            Database database = new Database();

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            }, "The collection is empty!");
        }

        [Test]

        public void FetchIsWorking()
        {
            int[] expected = new int[] { 1, 2, };

            int[] result = db.Fetch();

            Assert.AreEqual(expected, result);
        }

        [Test]

        public void FetchIsNotWorking()
        {
            int[] expected = new int[] { 1, 2, };

        }
    }
}
