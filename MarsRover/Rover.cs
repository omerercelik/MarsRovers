using EntityFramework.Reflection;
using MarsRover.enums;
using System;
using System.Collections.Generic;
using System.Windows;

namespace MarsRover
{
    ///<summary>
    ///define rover properties and methods
    ///<summary>
    public class Rover
    {
        private Point StartPosition;
        public Point startPosition
        {
            get
            {
                return StartPosition;
            }
            private set
            {
                startPosition = value;
            }
        }
        private Point? EndPosition;

        public Point? endPosition
        {
            get
            {
                return EndPosition;
            }
            private set
            {
                EndPosition = value;
            }
        }

        private DirectionEnum? Direction;
        public DirectionEnum? direction
        {
            get
            {
                return Direction;
            }
            private set
            {
                Direction = value;
            }
        }

        ///<summary>
        ///Rover Constructor
        ///<summary>
        ///<param name="startPosition" name ="direction" >take start position and direction</param>
        public Rover(Point startPosition, DirectionEnum? direction) {
            StartPosition = startPosition;
            Direction = direction;
        }

        ///<summary>
        ///GetCommand 
        ///<summary>
        ///<param name="commands">command list for move or turn rover</param>
        /// <returns> None </returns>
        public void TakeCommand(List<CommandEnum> commands){
            commands.ForEach(x =>
            {
                if (x == CommandEnum.Left)
                {
                    TurnLeft();
                }
                else if (x == CommandEnum.Right)
                {
                    TurnRight();
                }
                else if (x == CommandEnum.Move) {
                    Move();
                }
            });
        }


        ///<summary>
        ///Turn Rover Left  and change direction
        ///<summary>
        private void TurnLeft() {
            switch(Direction){
                case DirectionEnum.North:
                    Direction = DirectionEnum.West;
                    break;
                case DirectionEnum.East:
                    Direction = DirectionEnum.North;
                    break;
                case DirectionEnum.South:
                    Direction = DirectionEnum.East;
                    break;
                case DirectionEnum.West:
                    Direction = DirectionEnum.South;
                    break;
                default:
                    break;
            }
        }

        ///<summary>
        ///Turn Rover Right  and change direction
        ///<summary>
        private void TurnRight() {
            switch (Direction)
            {
                case DirectionEnum.North:
                    Direction = DirectionEnum.East;
                    break;
                case DirectionEnum.East:
                    Direction = DirectionEnum.South;
                    break;
                case DirectionEnum.South:
                    Direction = DirectionEnum.West;
                    break;
                case DirectionEnum.West:
                    Direction = DirectionEnum.North;
                    break;
                default:
                    break;
            }
        }

        ///<summary>
        ///Move Rover  and change EndPosition
        ///<summary>
        private void Move()
        {
            Point tempEndPosition;
            if (endPosition == null)
                tempEndPosition = ObjectCopier.Clone(startPosition);
            else
                tempEndPosition = ObjectCopier.Clone((Point)endPosition);
            switch (Direction)
            {
                case DirectionEnum.North:
                    EndPosition = new Point(tempEndPosition.X, tempEndPosition.Y+1);
                    break;
                case DirectionEnum.East:
                    EndPosition = new Point(tempEndPosition.X + 1, tempEndPosition.Y);
                    break;
                case DirectionEnum.South:
                    EndPosition = new Point(tempEndPosition.X, tempEndPosition.Y - 1);
                    break;
                case DirectionEnum.West:
                    EndPosition = new Point(tempEndPosition.X - 1, tempEndPosition.Y);
                    break;
                default:
                    break;
            }

        }

    }
}
