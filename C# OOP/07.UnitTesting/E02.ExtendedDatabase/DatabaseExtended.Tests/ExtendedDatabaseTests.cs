namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
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
        public void IsOurDBInitializingWhenIsCreated()
        {
            Assert.IsNotNull(myDatabase);
        }

        [Test]
        public void IsPersonsAttributesInitializingRight()
        {
            Person currPerson = new(2, "Domingo");
            myDatabase = new(currPerson);

            Assert.AreEqual(currPerson.Id, 2);
            Assert.AreEqual(currPerson.UserName, "Domingo");
            Assert.AreEqual(myDatabase.Count, 1);
        }

        [Test]
        public void IsAddingRangeAddingRight()
        {
            Person currPersonOne = new(2, "Domingo");
            Person currPersonTwo = new(3, "Misho");

            myDatabase.Add(currPersonOne);
            myDatabase.Add(currPersonTwo);

            Assert.AreEqual(myDatabase.Count, 2);
        }

        [Test]
        public void IsAddPesonWhitTheSameNameThrowException()
        {
            Person currPersonOne = new(2, "Domingo");
            Person currPersonTwo = new(3, "Domingo");

            myDatabase.Add(currPersonOne);

            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => myDatabase.Add(currPersonTwo));

            Assert.AreEqual(exception.Message, "There is already user with this username!");
        }

        [Test]
        public void IsAddPesonWhitTheSameIdThrowException()
        {
            Person currPersonOne = new(2, "Domingo");
            Person currPersonTwo = new(2, "Misho");

            myDatabase.Add(currPersonOne);

            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => myDatabase.Add(currPersonTwo));

            Assert.AreEqual(exception.Message, "There is already user with this Id!");
        }

        [Test]
        public void IsAddMethodThrowExceptionWhenExceedCount()
        {
            Person[] persons = new Person[16];

            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new Person(i, i.ToString());
            }

            myDatabase = new Database(persons);


            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => myDatabase.Add(new Person(2222, "Nikol")));

            Assert.AreEqual(exception.Message, "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void RemovingPersonFromOurDB()
        {
            Person currPerson = new(2, "Misho");

            myDatabase.Add(currPerson);

            myDatabase.Remove();

            Assert.AreEqual(0, myDatabase.Count);
        }

        [Test]
        public void IsRemovingMethodThrowsExceptionIsRemoveFromEmptyDB()
        {
            Assert.Throws<InvalidOperationException>(() => myDatabase.Remove());
        }

        [Test]
        public void IsFindingByUsernameFindsRight()
        {
            Person currPerson = new(2, "Nina");
            myDatabase = new Database(currPerson);

            Person foundPerson = myDatabase.FindByUsername("Nina");

            Assert.AreEqual(foundPerson.UserName, "Nina");
        }

        [Test]
        public void IfUsernameIsEmpty()
        {
            ArgumentNullException exception =
               Assert.Throws<ArgumentNullException>(() => myDatabase.FindByUsername(""));
            Assert.AreEqual(exception.ParamName, "Username parameter is null!");

            ArgumentNullException exceptionEmpty =
               Assert.Throws<ArgumentNullException>(() => myDatabase.FindByUsername(string.Empty));
            Assert.AreEqual(exceptionEmpty.ParamName, "Username parameter is null!");
        }

        [Test]
        public void FindByUsenameIfThereIsNoSuchUsename()
        {
            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => myDatabase.FindByUsername("Nina"));
            Assert.AreEqual(exception.Message, "No user is present by this username!");
        }


        [Test]
        public void IsFindingByIdFindsRight()
        {
            Person currPerson = new(2, "Nina");
            myDatabase = new Database(currPerson);

            Person foundPerson = myDatabase.FindById(2);

            Assert.AreEqual(foundPerson.Id, 2);
        }

        [Test]
        public void IfIdIsNegativeNumber()
        {
            ArgumentOutOfRangeException exception =
                Assert.Throws<ArgumentOutOfRangeException>(() => myDatabase.FindById(-1));
            Assert.AreEqual(exception.ParamName, "Id should be a positive number!");
        }

        [Test]
        public void FindByIdIfThereIsNoSuchId()
        {
            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => myDatabase.FindById(2));
            Assert.AreEqual(exception.Message, "No user is present by this ID!");
        }
    }
}