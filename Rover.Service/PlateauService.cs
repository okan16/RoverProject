using Rover.Core;
using Rover.Service.Interface;
using Rover.Shared.Helpers;
using Rover.Shared.Helpers.Interfaces;

namespace Rover.Service
{
    public class PlateauService : IPlateauService
    {
        public IPlateauHelper _pleteauHelper;

        public Plateau GeneratePlateau(string value)
        {
            Plateau entity = null;

            _pleteauHelper = new PlateauHelper();

            int xCoordinate = -1, yCoordinate = -1;

            // Koorinat hesaplanmasi icin gidiliyor
            bool result = _pleteauHelper.PlateauCoordinateCalculate(value, ref xCoordinate, ref yCoordinate);
            if (result)
            {
                // Beklenen koordinat bilgisi
                entity = new Plateau()
                {
                    XCoordinateLength = xCoordinate,
                    YCoordinateLength = yCoordinate
                };
            }

            return entity;
        }
    }
}
