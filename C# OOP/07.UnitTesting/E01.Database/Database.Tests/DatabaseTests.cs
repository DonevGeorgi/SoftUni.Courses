namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private Database myDatabase;

        [SetUp]
        public void SetUp()
        {
            myDatabase = new Database();
        }

        [TearDown]
        public void TearDown()
        {
            myDatabase = null;
        }

        [Test]
        public void OurDBIsInitializatingRight()
        {
            Assert.AreNotEqual(myDatabase, null);
        }


        [Test]
        public void CheckingIfOurCountReturnsTheRightCountOfTheDB()
        {
            for (int i = 0; i < 16; i++)
            {
                myDatabase.Add(i);
            }

            Assert.AreEqual(myDatabase.Count, 16);
        }

        [Test]
        public void IsDBAddingOnlyOneElement()
        {
            myDatabase.Add(2);

            Assert.AreEqual(1, myDatabase.Count);
        }

        [Test]
        public void IsThereExceptionForExeedingLimitOfTheDB()
        {
            for (int i = 0; i < 16; i++)
            {
                myDatabase.Add(i);
            }

            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => myDatabase.Add(17));

            Assert.AreEqual(exception.Message, "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void RemovingElementFromOurDB()
        {
            myDatabase.Add(2);

            myDatabase.Remove();

            Assert.AreEqual(myDatabase.Count, 0);
        }

        [Test]
        public void CheckingIfCountChangesWhenWeRemoveElement()
        {
            for (int i = 0; i < 5; i++)
            {
                myDatabase.Add(i);
            }

            myDatabase.Remove();

            Assert.AreEqual(myDatabase.Count, 4);
        }

        [Test]
        public void RemovingFromEmptyDB()
        {
            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => myDatabase.Remove());

            Assert.AreEqual(exception.Message, "The collection is empty!");
        }

        [Test]
        public void IsFetchingTheDBWorksFine()
        {
            for (int i = 0; i < 5; i++)
            {
                myDatabase.Add(i);
            }

            var result = myDatabase.Fetch();

            Assert.AreEqual(new int[] { 0, 1, 2, 3, 4 }, result);
        }
    }
}
