using BusinessLogic;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SampleTestsFwk
{
    [TestClass]
    public class PersonsBLTests
    {
        //UNIT TEST
        [TestMethod]
        public void FoodAmountForPets_WithValidAmount_ReturnsAmount()
        {
            // Arrange
            int cantPets = 2;
            int expected = 10;

            // Act
            int cantFood = PersonsBL.FoodAmountForPets(cantPets);

            // Assert
            Assert.AreEqual(expected, cantFood);
        }

        //INTEGRATION TEST
        [TestMethod]
        public void CreatePerson_WithValidPerson_AddsItToDB()
        {
            //Arrange
            Person toAdd = new Person
            {
                Name = "name",
                LastName = "lastName",
                Email = "email@asd.com",
                Phone = "12345678",
            };

            //Act
            int id = PersonsBL.Create(toAdd.Name, toAdd.LastName, toAdd.Email, toAdd.Phone);

            //Assert
            Person toCheck = PersonsBL.GetById(id);
            Assert.AreEqual(toCheck.Name, toAdd.Name);
            Assert.AreEqual(toCheck.LastName, toAdd.LastName);
            Assert.AreEqual(toCheck.Email, toAdd.Email);
            Assert.AreEqual(toCheck.Phone, toAdd.Phone);
        }

        [TestMethod]
        public void IDoSomething_ValidData_Returns10()
        {
            // Arrange
            int expected = 10;
            string data = "valid";

            // Act
            int response = PersonsBL.IDoSomething(data);

            // Assert

            Assert.AreEqual(expected, response);
        }

        [TestMethod]
        public void IDoSomething_IncorrectData_Returns0()
        {
            // Arrange
            int expected = 0;
            string data = "invalid_data";

            // Act
            int response = PersonsBL.IDoSomething(data);

            // Assert

            Assert.AreEqual(expected, response);
        }
    }
}
