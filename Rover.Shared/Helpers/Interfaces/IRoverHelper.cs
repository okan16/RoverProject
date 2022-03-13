using Rover.Core;
using Rover.Shared.Dtos;
using Rover.Shared.Enums;

namespace Rover.Shared.Helpers.Interfaces
{
    public interface IRoverHelper
    {
        bool CalculateCoordinates(string value, ref int xCoordinateLength, ref int yCoordinateLength, ref Direction direction);

        bool CalculateRoverPoint(Plateau plateau, Rovers rover);

        bool CalculateCommands(string value);

        Rovers TurnLeft(Rovers input);

        Rovers TurnRight(Rovers input);

        Rovers Move(Rovers input);
    }
}
