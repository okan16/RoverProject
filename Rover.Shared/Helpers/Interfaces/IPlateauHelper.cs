namespace Rover.Shared.Helpers.Interfaces
{
    public interface IPlateauHelper
    {
        bool PlateauCoordinateCalculate(string value, ref int xCoordinateLength, ref int yCoordinateLength);
    }
}
