using FinancialPlannerBack;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FinancialPlannerBackTest
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void CanCreateUserWithName()
        {
            const string testName = "test";
            const string username = "username";
            const string password = "password";
            var testUser = new User(testName, username, password);
            Assert.AreEqual(testUser.Name, testName);
        }

        [TestMethod]
        public void CanCreateUserWithCredentials()
        {
            const string name = "test";
            const string username = "username";
            const string password = "password";
            var testUser = new User(name, username, password);
            Assert.AreEqual(testUser.Name, name);
            Assert.AreEqual(testUser.Credentials.Username, username);
            Assert.AreEqual(testUser.Credentials.Password, password);
        }
    }
}
