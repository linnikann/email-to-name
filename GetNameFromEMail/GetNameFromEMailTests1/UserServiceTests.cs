using Microsoft.VisualStudio.TestTools.UnitTesting;
using GetNameFromEMail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetNameFromEMail.Tests
{
    [TestClass()]
    public class UserServiceTests
    {
        [TestMethod()]
        public void GetFirstNameTest_Simple()
        {
            string email = "firstname.lastname@domain.com";
            var userService = new UserService();
            
            string expected = "Firstname";
            string actual = userService.GetLastName(email);
            
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetFirstNameTest_Complicated()
        {
            string email = "firstname34.lastname-234@domain.com";
            var userService = new UserService();
            
            string expected = "Firstname";
            string actual = userService.GetFirstName(email);
            
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetLastNameTest_Simple()
        {
            string email = "firstname.lastname@domain.com";
            var userService = new UserService();
            
            string expected = "Lastname";
            string actual = userService.GetLastName(email);
            
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetLastNameTest_Complicated()
        {
            string email = "firstname34.lastname-234@domain.com";
            var userService = new UserService();
            
            string expected = "Lastname";
            string actual = userService.GetLastName(email);
            
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetCleanLocalPartTest_Simple()
        {
            //Arrange
            string email = "firstname.lastname@domain.com";
            var userService = new UserService();
            //Act
            string expected = "firstname.lastname";
            string actual = UserService.GetCleanLocalPart(email);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetCleanLocalPartTest_Complicated()
        {
            //Arrange
            string email = "firstname34.lastname-234@domain.com";
            var userService = new UserService();
            //Act
            string expected = "firstname.lastname";
            string actual = UserService.GetCleanLocalPart(email);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetNamesTest_NoSecondName_SplitAtAllDelimiters()
        {
            //Arrange
            string localpart = "firstname.lastname";
            var userService = new UserService();
            //Act

            string[] expected = { "firstname", "lastname" };
            string[] actual = UserService.GetNames(localpart);
            //Assert
            Assert.AreEqual(expected, actual); 
        }
        [TestMethod()]
        public void GetNamesTest_SecondFirstName_DontSplitAtMinus()
        {
            //Arrange
            string localpart = "firstname-secondname.lastname";
            var userService = new UserService();
            //Act
            string[] expected = { "firstname-secondname", "lastname" };
            string[] actual = UserService.GetNames(localpart);
            //Assert
            Assert.Equals(actual, expected);
        }
        [TestMethod()]
        public void GetNamesTest_SecondLastName_DontSplitAtMinus()
        {
            //Arrange
            string localpart = "firstname.lastname-secondname";
            var userService = new UserService();
            //Act
            string[] expected = { "firstname", "lastname-secondname" };
            string[] actual = UserService.GetNames(localpart);
            //Assert
            Assert.Equals(actual, expected);
        }

        [TestMethod()]
        public void GetCapitalizedNamesTest_WithMinus_CapitalizeAllNames()
        {
            //Arrange
            var userService = new UserService();
            string[] input = { "forename-secondname", "lastname" };
            //Act
            string[] expected = { "Forename-Secondname", "Lastname" };
            string [] actual = userService.GetCapitalizedNames(input);
            //Assert
            Assert.Equals(actual, expected);
        }
        public void GetCapitalizedNamesTest_WithoutMinus_CapitalizeFirstNameAndLastName()
        {
            //Arrange
            var userService = new UserService();
            string[] input = { "forename", "lastname" };
            //Act
            string[] expected = { "Forename", "Lastname" };
            string[] actual = userService.GetCapitalizedNames(input);
            //Assert
            Assert.Equals(actual, expected);
        }
    }
}