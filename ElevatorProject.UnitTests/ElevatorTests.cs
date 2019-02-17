using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ElevatorProject.UnitTests
{
    [TestClass]
    public class ElevatorTests
    {
        [TestMethod]
        public void CheckMaxWeightAllowedReached_EmptyElevator_ReturnFalse()
        {
            // Arrange
            var myElevator = new Elevator(100);

            // Act
            var result = myElevator.CheckMaxWeightAllowedReached();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckMaxWeightAllowedReached_80MaxWeightWith80WeightEmployer_ReturnTrue()
        {
            // Arrange
            var myElevator = new Elevator(80);
            // employee 1
            var Programmer = new Employee();
            Programmer.Weight = 80;
            
            // Act
            //adding employees to the elevator
            myElevator.InUser(Programmer);          
            var result = myElevator.CheckMaxWeightAllowedReached();

            // Assert            
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckMaxWeightAllowedReached_100MaxWeightWithSeveralEmployees_ReturnTrue()
        {
            // Arrange
            var myElevator = new Elevator(100);
            // employee 1
            var Director = new Employee();
            Director.Weight = 75;
            Director.IsExecutive = true;
            // employee 2
            var Producer = new Employee();
            Producer.Weight = 85;

            // Act
            //adding employees to the elevator
            myElevator.InUser(Director);
            myElevator.InUser(Producer);
            var result = myElevator.CheckMaxWeightAllowedReached();

            // Assert            
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckMaxWeightAllowedReached_100MaxWeightWithSeveralEmployeesButSubtractingOne_ReturnFalse()
        {
            // Arrange
            var myElevator = new Elevator(100);
            // employee 1
            var Director = new Employee();
            Director.Weight = 75;
            Director.IsExecutive = true;
            // employee 2
            var Producer = new Employee();
            Producer.Weight = 85;

            // Act
            //adding employees to the elevator
            myElevator.InUser(Director);
            myElevator.InUser(Producer);
            // removing one
            myElevator.OutUser(Producer);
            var result = myElevator.CheckMaxWeightAllowedReached();

            // Assert            
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void OutUser_SubtractingSeveralEmployeeWhoAreNotInTheElevator_CurrentWeightResult0()
        {
            // Arrange
            var myElevator = new Elevator(100);
            // employee 1
            var Artist = new Employee();
            Artist.Weight = 75;            
            // employee 2
            var GameDesigner = new Employee();
            GameDesigner.Weight = 85;

            // Act
            // removing employees who aren't inside the elevator
            myElevator.OutUser(Artist);
            myElevator.OutUser(GameDesigner);
          
            // Assert            
            Assert.AreEqual(myElevator.CurrentWeight, 0);
        }

        [TestMethod]
        public void GoToVipSection_EmployeeWithVipPass_ReturnTrue()
        {
            // Arrange
            var myElevator = new Elevator(100);
            // employee 
            var CEO = new Employee();
            CEO.Weight = 90;
            CEO.IsExecutive = true;

            // Act
            // adding employee inside the elvator, and go to vip section
            myElevator.InUser(CEO);
            var result = myElevator.GoToVipSection(CEO);            

            // Assert            
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GoToVipSection_EmployeeWithoutVipPass_ReturnFalse()
        {
            // Arrange
            var myElevator = new Elevator(100);
            // employee 
            var Guard = new Employee();
            Guard.Weight = 90;            

            // Act
            // adding employee inside the elvator, and go to vip section
            myElevator.InUser(Guard);
            var result = myElevator.GoToVipSection(Guard);

            // Assert            
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GoToVipSection_ThereAreNotEmployeesInTheElevator_ReturnFalse()
        {
            // Arrange
            var myElevator = new Elevator(100);
           
            // Act
            // go to vip section            
            var result = myElevator.GoToVipSection(new Employee());

            // Assert            
            Assert.IsFalse(result);
        }

    }
}
