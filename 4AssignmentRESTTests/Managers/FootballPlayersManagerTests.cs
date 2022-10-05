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
        FootballPlayersManager manager = new FootballPlayersManager();

        [TestMethod()]
        public void GetAllTest()
        {
            List<FootballPlayer> testList = manager.GetAll();

            Assert.AreEqual(5, testList.Count);
        }

        [TestMethod()]
        public void AddTest()
        {
            var newPlayer = new FootballPlayer() { Age = 25, Name = "Rudo", ShirtNumber = 25 };

            var createdResponse = manager.Add(newPlayer);

            Assert.AreEqual(6, createdResponse.Id);
            Assert.AreEqual(6, manager.GetAll().Count);
        }

        [TestMethod()]
        public void GetById()
        {
            var createdResponse = manager.GetById(2);
            var nullResponse = manager.GetById(25);

            Assert.AreEqual("Pele", createdResponse?.Name);
            Assert.IsNull(nullResponse);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            var updates = new FootballPlayer() { Age = 25, Name = "Rudo", ShirtNumber = 25 };
            var createdResponse = manager.Update(2, updates);

            Assert.AreEqual("Rudo", createdResponse?.Name);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            var createdResponse = manager.Delete(1);
            
            Assert.IsNull(manager.GetById(1));
        }
    }
}