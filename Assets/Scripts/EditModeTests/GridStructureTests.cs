using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class GridStructureTests
    {
        private GridStructure structure;

        [OneTimeSetUp]
        public void Init()
        {
            structure = new GridStructure(3, 100, 100);
        }

        #region Grid Position Tests
        [Test]
        public void CalculateGridPositionPasses()
        {
            // Arrange
            Vector3 position = new Vector3(0, 0, 0); ;

            //Act
            Vector3 returnPosition = structure.CalculateGridPosition(position);

            //Assert
            Assert.AreEqual(Vector3.zero, returnPosition);
        }

        [Test]
        public void CalculateGridPositionFloatsPasses()
        {
            // Arrange
            Vector3 position = new Vector3(2.9f, 0, 2.9f); ;

            //Act
            Vector3 returnPosition = structure.CalculateGridPosition(position);

            //Assert
            Assert.AreEqual(Vector3.zero, returnPosition);
        }

        [Test]
        public void CalculateGridPositionFloatsFails()
        {
            // Arrange
            Vector3 position = new Vector3(3.1f, 0, 0); ;

            //Act
            Vector3 returnPosition = structure.CalculateGridPosition(position);

            //Assert
            Assert.AreNotEqual(Vector3.zero, returnPosition);
        }
        #endregion

        #region Grid Index Tests

        [Test]
        public void PlaceStructure303AndCheckIsTakenPasses()
        {
            Vector3 pos = new Vector3(3,0,3);
            
            //Act
            Vector3 retPos = structure.CalculateGridPosition(pos);
            var testGameObj = new GameObject("TestGameObject");
            structure.PlaceStructureOnGrid(testGameObj, pos);

            //Assert
            Assert.IsTrue(structure.IsCellTaken(pos).isTaken);
        }

        [Test]
        public void PlaceStructureMINAndCheckIsTakenPasses()
        {
            Vector3 pos = new Vector3(0, 0, 0);

            //Act
            Vector3 retPos = structure.CalculateGridPosition(pos);
            var testGameObj = new GameObject("TestGameObject");
            structure.PlaceStructureOnGrid(testGameObj, pos);

            //Assert
            Assert.IsTrue(structure.IsCellTaken(pos).isTaken);
        }

        [Test]
        public void PlaceStructureMAXAndCheckIsTakenPasses()
        {
            Vector3 pos = new Vector3(297, 0, 297);

            //Act
            Vector3 retPos = structure.CalculateGridPosition(pos);
            var testGameObj = new GameObject("TestGameObject");
            structure.PlaceStructureOnGrid(testGameObj, pos);

            //Assert
            Assert.IsTrue(structure.IsCellTaken(pos).isTaken);
        }

        [Test]
        public void PlaceStructure303AndCheckIsTakenNullObjectShouldFail()
        {
            Vector3 pos = new Vector3(3, 0, 3);

            //Act
            Vector3 retPos = structure.CalculateGridPosition(pos);
            GameObject testGameObj = null;
            structure.PlaceStructureOnGrid(testGameObj, pos);

            //Assert
            Assert.IsFalse(structure.IsCellTaken(pos).isTaken);
        }

        [Test]
        public void PlaceStructure303AndCheckIsTakenIndexOutOfBoundsFail()
        {
            Vector3 pos = new Vector3(303, 0, 303);

            //Act
            
            //Assert
            Assert.Throws<IndexOutOfRangeException>(() => structure.IsCellTaken(pos));
        }
        #endregion
    }
}
