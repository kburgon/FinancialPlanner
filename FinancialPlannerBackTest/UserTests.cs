using FinancialPlannerBack;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FinancialPlannerBackTest
{
    [TestClass]
    public class UserTests
    {
        private const string Name = "test";
        private const string Username = "username";
        private const string Password = "password";

        [TestMethod]
        public void CanCreateUser()
        {
            User testUser = CreateUser();
            Assert.AreEqual(testUser.Name, Name);
            Assert.AreEqual(testUser.Username, Username);
            Assert.AreEqual(testUser.Password, Password);
        }

        [TestMethod]
        public void CanUpdatePassword()
        {
            const string newPassword = "newPassword";
            var testUser = CreateUser();
            Assert.AreEqual(Password, testUser.Password);
            testUser.Password = newPassword;
            Assert.AreNotEqual(testUser.Password, Password);
            Assert.AreEqual(testUser.Password, newPassword);
        }

        [TestMethod]
        public void CanUpdateUsername()
        {
            const string newUsername = "newuser";
            var testUser = CreateUser();
            Assert.AreEqual(Username, testUser.Username);
            testUser.Username = newUsername;
            Assert.AreNotEqual(testUser.Username, Username);
            Assert.AreEqual(testUser.Username, newUsername);
        }

        [TestMethod]
        public void CanUpdateName()
        {
            const string newName = "new";
            var user = CreateUser();
            Assert.AreEqual(Name, user.Name);
            user.Name = newName;
            Assert.AreNotEqual(Name, user.Name);
            Assert.AreEqual(newName, user.Name);
        }

        private static User CreateUser()
        {
            return new User(Name, Username, Password);
        }
    }
}
