using NUnit.Framework;
using WpfApp.src;

namespace NUnitTestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void LogInTest1()
        {
            LogTest newLogTest = new LogTest();
            Assert.AreEqual(true, newLogTest.Login("admin", "admin"), "Incorrect");
        }

        [Test]
        public void LogInTest2()
        {
            LogTest newLogTest = new LogTest();
            Assert.AreEqual(true, newLogTest.Login("user", "12345"), "Correct");
        }
    }
}