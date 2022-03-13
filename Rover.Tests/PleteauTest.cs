using NUnit.Framework;
using Rover.Core;
using Rover.Service;
using Rover.Service.Interface;

namespace Rover.Tests
{
    public class PleteauTest
    {
        public IPlateauService _pleteauService;
       // public IRoverService _roverService;

        public PleteauTest()
        {
            _pleteauService = new PlateauService();
           
        }


        /// <summary>
        /// Kullanıcının girdiği plato koordinatlarının doğruluğunu test eder. 
        /// </summary>
        [Test]
        public void GeneratePlateauTestMethod()
        {
            Plateau plateau = _pleteauService.GeneratePlateau("aasda 5");
            Assert.IsNull(plateau);

            plateau = _pleteauService.GeneratePlateau("5  5");
            Assert.IsNull(plateau);

            plateau = _pleteauService.GeneratePlateau("5 5");
            Assert.IsNotNull(plateau);
        }
    }
}