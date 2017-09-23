using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using School;

namespace SchoolTest
{
    [TestClass]
    public class StudentTest
    {
        private Student _student = new Student("Anders", "Roskilde", 1, Gender.Male);

        [TestMethod]
        public void TestConstructor()
        {
            try
            {
                new Student(null, "Roskilde", 1, Gender.Male);
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("name is null or empty", ex.Message);
            }
            try
            {
                new Student("", "Roskilde", 1, Gender.Male);
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("name is null or empty", ex.Message);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConstructorException()
        {
            new Student(null, "Roskilde", 1, Gender.Male);
        }

        [TestMethod]
        public void TestName()
        {
            Assert.AreEqual("Anders", _student.Name);
            _student.Name = "John";
            Assert.AreEqual("John", _student.Name);
            try
            {
                _student.Name = null;
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("name is null or empty", ex.Message);
            }
        }

        [TestMethod]
        public void TestAddress()
        {
            Assert.AreEqual("Roskilde", _student.Address);
            try
            {
                _student.Address = null;
                Assert.Fail();
            } catch (ArgumentNullException) { }
        }

        [TestMethod]
        public void TestSemester()
        {
            Assert.AreEqual(1, _student.Semester);
            _student.Semester = 2;
            Assert.AreEqual(2, _student.Semester);
            try
            {
                _student.Semester = 0;
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException) { }
            _student.Semester = 7;
            Assert.AreEqual(7, _student.Semester);
            _student.Semester = 8;
            Assert.AreEqual(8, _student.Semester);
            try
            {
                _student.Semester = 9;
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException) { }
        }

        [TestMethod]
        public void TestToString()
        {
            Assert.AreEqual("Anders, Roskilde, Male, 1", _student.ToString());
        }

        [TestMethod]
        public void TestEquals()
        {
            Assert.AreEqual(_student, _student);
            Student similarStudent = new Student("Anders", "Roskilde", 1, Gender.Male);
            Assert.AreEqual(_student, similarStudent);

            Student studentDifferentName = new Student("John", "Roskilde", 1, Gender.Male);
            Assert.AreNotEqual(_student, studentDifferentName);

            Student studentDifferentSemester = new Student("Anders", "Roskilde", 3, Gender.Male);
            Assert.AreNotEqual(_student, studentDifferentSemester);

            Assert.AreNotEqual(_student, "Anders");
            Student other = null;
            Assert.IsFalse(_student.Equals(other));

            String str = null;
            Assert.IsFalse(_student.Equals(str));
        }

        [TestMethod]
        public void TestHashCode()
        {
            Student similarStudent = new Student("Anders", "Roskilde", 1, Gender.Male);

            Assert.AreEqual(_student.GetHashCode(), similarStudent.GetHashCode());
        }
    }
}
