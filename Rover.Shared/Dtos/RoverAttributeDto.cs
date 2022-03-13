using Rover.Shared.Enums;

namespace Rover.Shared.Dtos
{
    public class RoverAttributeDto
    {
        public int Order { get; set; }

        public int XCoordinate { get; set; }

        public int YCoordinate { get; set; }

        public Direction Direction { get; set; }

        public string Command { get; set; }
    }
}
