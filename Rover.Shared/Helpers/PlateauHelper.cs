using Rover.Shared.Helpers.Interfaces;
using System;

namespace Rover.Shared.Helpers
{
    public class PlateauHelper : IPlateauHelper
    {
        public bool PlateauCoordinateCalculate(string value, ref int xCoordinate, ref int yCoordinate)
        {
            bool result = false;

            try
            {
                if (!string.IsNullOrEmpty(value))
                {
                    string[] plateaAttributes = value.Trim().Split(' ');
                    /*
                     * Split edildikten sonra 2 koordinate bilgisi olmasi bekleniyor
                     * Eger 2 den farkli ise false donuluyor
                     */
                    if (plateaAttributes.Length == 2)
                    {
                        bool xCoordinateResult = int.TryParse(plateaAttributes[0], out xCoordinate);
                        bool yCoordinateResult = int.TryParse(plateaAttributes[1], out yCoordinate);

                        if (xCoordinateResult && yCoordinateResult)
                        {
                            result = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log ex
            }

            return result;
        }
    }
}
