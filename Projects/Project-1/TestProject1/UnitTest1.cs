using Business_Logic;

namespace TestProject1
{
    public class Tests
    {
        RegexValidation regex;

        [SetUp]
        public void Setup()
        {
            regex = new RegexValidation();
        }

        [Test]
        [TestCase("srinu@gmail.com", true)]
        [TestCase("srinugmail.com", true)]
        public void TestEmail(string? email, bool result)
        {
            bool actualResult;
            try
            {
                actualResult = regex.ValidateEmail(email);
            }
            catch(Exception)
            {
                actualResult= false;
            }
            Assert.AreEqual(actualResult, result);
        }


        [Test]
        [TestCase("Password@123", true)]
        [TestCase("srinugm", true)]
        public void TestPassword(string? pwd, bool result)
        {
            bool actualResult;
            try
            {
                actualResult = regex.ValidatePassword(pwd);
            }
            catch (Exception)
            {
                actualResult = false;
            }
            Assert.AreEqual(actualResult, result);
        }
    }
}