using MarsRover.enums;
using System;
using System.Collections.Generic;
using System.Windows;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Rover> rovers = new List<Rover>();

            DirectionEnum? direction = null;
            Console.WriteLine("Please enter a Rover position and direction.\n" +
           "First input is x coardinates (must be integer), second input is y coardinate (must be integer)\n" +
           "and last input is direction (must be One of 'N' , 'E' ,'S' and 'W')\n" +
           "Press 0 to Exit");

            bool isValidCommand;
            bool isValidPosition;
            bool isValid = true;
            string input;
            string[] inputs;
            bool hasToEnterPosition = false;
            Rover rover = new Rover(new Point(),null);
            do
            {
                input = Console.ReadLine();
                inputs = input.Split(' ');
                isValidPosition = ValidateInput.ValidatePosition(inputs);
                if (isValidPosition)
                {
                    if (inputs.Length == 3)
                        direction = GetDirectionByInput(inputs[2]);
                    else
                        direction = null;
                    rover = new Rover(new Point(Int32.Parse(inputs[0]), Int32.Parse(inputs[1])), direction);
                    if (direction == null)
                    {
                        hasToEnterPosition = true;
                        rovers.Add(rover);
                    }
                }
                else if(!input.Equals("0"))
                {
                    Console.WriteLine("Rover position is not valid. Please Enter valid Rover position \n" +
                    "Press 0 to Exit");
                }
            } while (!isValidPosition  && !input.Equals("0"));
            while (!input.Equals("0"))
            {
                if (!isValid) {
                    Console.WriteLine("Entered value is not valid!");
                }
                if (hasToEnterPosition)
                    Console.WriteLine("Please Enter new Rover position \n" +
                    "Press 0 to Exit ");
                else
                {
                    Console.WriteLine("Please Enter new Rover position or Rover Commands (Rover Command Must be one of 'R' means Rigth , 'L' means Left or 'M' means go ahead)\n" +
                        "You can enter one more than commands"
                        );
                }
                input = Console.ReadLine();
                if (hasToEnterPosition)
                {
                    inputs = input.Split(' ');
                    isValidPosition = ValidateInput.ValidatePosition(inputs);
                    if (isValidPosition)
                    {
                        if (inputs.Length == 3)
                            direction = GetDirectionByInput(inputs[2]);
                        else
                            direction = null;
                        rover = new Rover(new Point(Int32.Parse(inputs[0]), Int32.Parse(inputs[1])), direction);
                        if (direction == null)
                        {
                            rovers.Add(rover);
                            hasToEnterPosition = true;
                        }
                        else
                            hasToEnterPosition = false;
                        isValid = true;
                    }
                    else {
                        isValid = false;
                    }
                }
                else {
                    inputs = input.Split(' ');
                    isValidPosition = ValidateInput.ValidatePosition(inputs);
                    input = input.Replace(" ", string.Empty);
                    isValidCommand = ValidateInput.ValidateCommand(input);
                    if (isValidPosition)
                    {
                        if (hasToEnterPosition == false)
                            rovers.Add(rover);
                        if (inputs.Length == 3)
                            direction = GetDirectionByInput(inputs[2]);
                        else
                            direction = null;
                        rover = new Rover(new Point(Int32.Parse(inputs[0]), Int32.Parse(inputs[1])), direction);
                        if (direction == null)
                        {
                            rovers.Add(rover);
                            hasToEnterPosition = true;
                        }
                        else
                            hasToEnterPosition = false;
                        isValid = true;
                    }
                    else if (isValidCommand)
                    {
                        List<CommandEnum> commands = new List<CommandEnum>();
                        Char[] commandInputList = input.ToCharArray();
                        foreach (var commandInput in commandInputList)
                        {
                            var command = GetCommandByInput(commandInput);
                            if (command != null)
                                commands.Add((CommandEnum)command);
                        }
                        rover.TakeCommand(commands);
                        rovers.Add(rover);
                        hasToEnterPosition = true;
                        isValid = true;
                    }
                    else
                        isValid = false;
                }
            }
            ShowRoverEndPosition(rovers);
            input = Console.ReadLine();
        }
        ///<summary>
        ///get DirectionEnum by entered input
        ///<summary>
        public static DirectionEnum? GetDirectionByInput(string direction)
        {

            switch (direction)
            {
                case "N":
                case "n":
                    return DirectionEnum.North;
                case "W":
                case "w":
                    return DirectionEnum.West;
                case "S":
                case "s":
                    return DirectionEnum.South;
                case "E":
                case "e":
                    return DirectionEnum.East;
                default:
                    return null;
            }
        }

        ///<summary>
        ///get CommandEnum by entered input
        ///<summary>
        public static CommandEnum? GetCommandByInput(char command)
        {

            switch (command)
            {
                case 'L':
                case 'l':
                    return CommandEnum.Left;
                case 'R':
                case 'r':
                    return CommandEnum.Right;
                case 'M':
                case 'm':
                    return CommandEnum.Move;
                default:
                    return null;
            }
        }
        ///<summary>
        ///Show rovers endPosition if they Moves
        ///<summary>
        public static void ShowRoverEndPosition(List<Rover> rovers)
        {
            foreach (var rover in rovers) {
                if (rover.endPosition != null)
                {
                    Console.Write(rover.endPosition + " ");
                    Console.WriteLine(rover.direction);
                }
            }
        }
    }
}
