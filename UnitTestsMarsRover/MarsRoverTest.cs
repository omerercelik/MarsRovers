using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MarsRover;
using System.Windows;
using System.Collections.Generic;
using MarsRover.enums;

namespace UnitTestsMarsRover
{
    ///<summary>
    ///for test  final rover endPosition and direction when take command
    ///<summary>
    [TestClass]
    public class MarsRoverTest
    {

        ///<summary>
        ///for test one rover take (5,5) start position and dont't take direction expected endPosition is null and expected directon is null
        ///<summary>
        [TestMethod]
        public void TestMethod1()
        {
            Point startPosition = new Point(5, 5);
            Rover rover = new Rover(startPosition,null);
            Assert.AreEqual(null, rover.endPosition);
            Assert.AreEqual(null, rover.direction);
        }

        ///<summary>
        ///for test one rover take (1,2) start position and take North direction,  expected endPosition is (1,3) and expected directon is North
        ///<summary>
        [TestMethod]
        public void TestMethod2()
        {
            Point startPosition = new Point(1, 2);
            Point endPosition = new Point(1, 3);
            DirectionEnum endDirection = DirectionEnum.North;
            Rover rover = new Rover(startPosition, DirectionEnum.North);
            List<CommandEnum> commandList = new List<CommandEnum>();
            commandList.Add(CommandEnum.Left);
            commandList.Add(CommandEnum.Move);
            commandList.Add(CommandEnum.Left);
            commandList.Add(CommandEnum.Move);
            commandList.Add(CommandEnum.Left);
            commandList.Add(CommandEnum.Move);
            commandList.Add(CommandEnum.Left);
            commandList.Add(CommandEnum.Move);
            commandList.Add(CommandEnum.Move);
            rover.TakeCommand(commandList);
            Assert.AreEqual(endPosition, rover.endPosition);
            Assert.AreEqual(endDirection, rover.direction);
        }
        ///<summary>
        ///for test one rover take (3,3) start position and take East direction,  expected endPosition is (5,1) and expected directon is East
        ///<summary>
        [TestMethod]
        public void TestMethod3()
        {
            Point startPosition = new Point(3, 3);
            Point endPosition = new Point(5, 1);
            DirectionEnum endDirection = DirectionEnum.East;
            Rover rover = new Rover(startPosition, DirectionEnum.East);
            List<CommandEnum> commandList = new List<CommandEnum>();
            commandList.Add(CommandEnum.Move);
            commandList.Add(CommandEnum.Move);
            commandList.Add(CommandEnum.Right);
            commandList.Add(CommandEnum.Move);
            commandList.Add(CommandEnum.Move);
            commandList.Add(CommandEnum.Right);
            commandList.Add(CommandEnum.Move);
            commandList.Add(CommandEnum.Right);
            commandList.Add(CommandEnum.Right);
            commandList.Add(CommandEnum.Move);
            rover.TakeCommand(commandList);
            Assert.AreEqual(endPosition, rover.endPosition);
            Assert.AreEqual(endDirection, rover.direction);
        }
    }
}
