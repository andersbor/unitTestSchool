using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using School;

namespace SchoolTest
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void TestConstructor()
        {
            Student student = new Student("Anders", 40);
            try
            {
                new Student(null, 1);
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("name is null or empty", ex.Message);
            }
            try
            {
                new Student("", 1);
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
            new Student(null, 1);
        }

        [TestMethod]
        public void TestName()
        {
            Student student = new Student("Anders", 40);
            Assert.AreEqual("Anders", student.Name);
            student.Name = "John";
            Assert.AreEqual("John", student.Name);
            try
            {
                student.Name = null;
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("name is null or empty", ex.Message);
            }
        }

        [TestMethod]
        public void TestAge()
        {
            Student student = new Student("Anders", 40);
            Assert.AreEqual(40, student.Semester);
            student.Semester = 0;
            Assert.AreEqual(0, student.Semester);
            try
            {
                student.Semester = -1;
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("age is less than zero", ex.Message);
            }
        }

        [TestMethod]
        public void TestToString()
        {
            Student student = new Student("Anders", 40);
            Assert.AreEqual("Student: Anders, 40", student.ToString());
        }

        [TestMethod]
        public void TestEquals()
        {
            Student student = new Student("Anders", 40);
            Assert.AreEqual(student, student);
            Student similarStudent = new Student("Anders", 40);
            Assert.AreEqual(student, similarStudent);

            Student studentDifferentName = new Student("John", 40);
            Assert.AreNotEqual(student, studentDifferentName);

            Student studentDifferentAge = new Student("Anders", 30);
            Assert.AreNotEqual(student, studentDifferentAge);

            Assert.AreNotEqual(student, "Anders");
            Student other = null;
            Assert.IsFalse(student.Equals(other));

            String str = null;
            Assert.IsFalse(student.Equals(str));        
        }

        [TestMethod]
        public void TestHashCode()
        {
            Student student = new Student("Anders", 40);
            Student similarStudent = new Student("Anders", 40);

            Assert.AreEqual(student.GetHashCode(), similarStudent.GetHashCode());
        }


    }
}
