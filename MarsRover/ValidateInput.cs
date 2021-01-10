using MarsRover.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover
{
    static class ValidateInput
    {


        ///<summary>
        ///Validate Rover Position 
        ///<summary>
        public static   bool ValidatePosition(string[] inputs) { 
            string[] directions = Enum.GetNames(typeof(DirectionEnum)).ToArray();
            for (int i =0; i < directions.Length; i++) {
                directions[i] = directions[i].Substring(0, 1); 
            }
            if (inputs == null || !(inputs.Length == 3 || inputs.Length ==2))
            {
                return false;
            }
            else if (!int.TryParse(inputs[0], out int firstInput) || !int.TryParse(inputs[1], out int secondInput)) {
                return false;
            }
            else if (inputs.Length != 2 && !directions.Contains(inputs[2], StringComparer.OrdinalIgnoreCase)) {
                return false;
            }
            else
                return true;
        }

        ///<summary>
        ///Validate Rover command 
        ///<summary>
        public static bool ValidateCommand(string input)
        {
            bool isValid = true;
            var inputs = input.ToCharArray();
            string[] commands = Enum.GetNames(typeof(CommandEnum)).ToArray();
            for (int i = 0; i < commands.Length; i++)
            {
                commands[i] = commands[i].Substring(0, 1);
            }
            foreach (var command in inputs) {
                if (!commands.Contains(command.ToString(), StringComparer.OrdinalIgnoreCase)) {
                    isValid = false;
                    break;
                }
            }
            return isValid;
        }

    }
}
