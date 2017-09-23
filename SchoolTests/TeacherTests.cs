using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace School.Tests
{
    [TestClass]
    public class TeacherTests
    {
        private Teacher _teacher = new Teacher("Anders", "Roskilde", Gender.Male, 0);

        [TestMethod]
        public void SalaryTest()
        {
            Assert.AreEqual(0, _teacher.Salary);
            _teacher.Salary = 1;
            Assert.AreEqual(1, _teacher.Salary);
            try
            {
                _teacher.Salary = -1;
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException) { }
        }

        [TestMethod]
        public void ToStringTest()
        {
            Assert.AreEqual("Anders, Roskilde, Male, 0", _teacher.ToString());
        }
    }
}