using Microsoft.VisualStudio.TestTools.UnitTesting;
using _4AssignmentREST.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _4AssignmentREST.Models;
using Microsoft.AspNetCore.Mvc;

namespace _4AssignmentREST.Managers.Tests
{
    [TestClass()]
    public class FootballPlayersManagerTests
    {
        [TestMethod()]
        public void GetAllTest()
        {
            var manager = new FootballPlayersManager();
            List<FootballPlayer> testList = manager.GetAll();

            Assert.AreEqual(testList.Count, 5);
        }

        [TestMethod()]
        public void AddTest()
        {
            var manager = new FootballPlayersManager();
            var newPlayer = new FootballPlayer() { Age = 25, Name = "Rudo", ShirtNumber = 25 };

            var createdResponse = manager.Add(newPlayer);

            Assert.AreEqual(createdResponse.Id, 6);
            Assert.AreEqual(createdResponse.Age, 25);
            Assert.AreEqual(createdResponse.Name, "Rudo");
            Assert.AreEqual(createdResponse.ShirtNumber, 25);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            var manager = new FootballPlayersManager();
            var updates = new FootballPlayer() { Age = 25, Name = "Rudo", ShirtNumber = 25 };

            var createdResponse = manager.Update(2, updates);
            Assert.AreEqual(createdResponse.Name, updates.Name);
        }
    }
}