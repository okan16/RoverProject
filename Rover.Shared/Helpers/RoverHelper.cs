﻿using Rover.Core;
using Rover.Shared.Dtos;
using Rover.Shared.Enums;
using Rover.Shared.Helpers.Interfaces;
using System;

namespace Rover.Shared.Helpers
{
    public class RoverHelper : IRoverHelper
    {
        private IEnumHelper _enumHelper;

        public bool CalculateCoordinates(string value, ref int xCoordinateLength, ref int yCoordinateLength, ref Direction direction)
        {
            bool result = false;

            _enumHelper = new EnumHelper();

            if (!string.IsNullOrEmpty(value))
            {
                string[] plateaAttributes = value.Trim().Split(' ');

                if (plateaAttributes.Length == 3)
                {
                    bool xCoordinateResult = int.TryParse(plateaAttributes[0], out xCoordinateLength);
                    bool yCoordinateResult = int.TryParse(plateaAttributes[1], out yCoordinateLength);

                    if (xCoordinateResult && yCoordinateResult)
                    {
                        if (!string.IsNullOrEmpty(plateaAttributes[2]))
                        {
                            bool isDefined = _enumHelper.DirectionIsDefined(plateaAttributes[2]);

                            if (isDefined)
                            {
                                direction = Enum.Parse<Direction>(plateaAttributes[2]);

                                result = true;
                            }
                        }
                    }
                }
            }

            return result;
        }

        public bool CalculateRoverPoint(Plateau plateau, Rovers rover)
        {
            bool result = false;

            if (plateau.XCoordinateLength >= rover.XCoordinate && plateau.YCoordinateLength >= rover.YCoordinate)
            {
                result = true;
            }

            return result;
        }

        public bool CalculateCommands(string value)
        {
            _enumHelper = new EnumHelper();

            bool result = false;

            if (!string.IsNullOrEmpty(value))
            {
                foreach (char item in value)
                {
                    result = _enumHelper.CommandIsDefined(item.ToString());

                    if (!result)
                    {
                        break;
                    }
                }
            }

            return result;
        }

        public Rovers TurnLeft(Rovers input)
        {
            input.Direction = (Direction)Enum.ToObject(typeof(Direction), (Convert.ToInt32(input.Direction) + 1) % 4);

            return input;
        }

        public Rovers TurnRight(Rovers input)
        {
            input.Direction = (Direction)Enum.ToObject(typeof(Direction), (Convert.ToInt32(input.Direction) + 3) % 4);

            return input;
        }

        public Rovers Move(Rovers input)
        {
            if (input.Direction == Direction.E)
            {
                input.XCoordinate += 1;
            }
            else if (input.Direction == Direction.W)
            {
                input.XCoordinate -= 1;
            }
            else if (input.Direction == Direction.S)
            {
                input.YCoordinate -= 1;
            }
            else if (input.Direction == Direction.N)
            {
                input.YCoordinate += 1;
            }

            return input;
        }
    }
}
