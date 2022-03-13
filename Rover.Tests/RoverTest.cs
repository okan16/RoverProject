using NUnit.Framework;
using Rover.Core;
using Rover.Service;
using Rover.Service.Interface;

namespace Rover.Tests
{
    public class RoverTest
    {
        public IRoverService _roverService;
        public IPlateauService _pleteauService;

        public RoverTest()
        {
            _roverService = new RoverService();
            _pleteauService = new PlateauService();
        }


        /// <summary>
        /// Kullanıcının girdiği rover bilgilerinin doğruluğunu test eder. 
        /// </summary>
        [Test]
        public void GenerateRoverTestMethod()
        {
            Plateau plateauEntity = _pleteauService.GeneratePlateau("5 5");

            Rovers rovers = _roverService.GenerateRover("1  2 N","LMLMLMLMM", plateauEntity);
            Assert.IsNull(rovers);

            rovers = _roverService.GenerateRover("1 2 N", "LML12MLMLMM", plateauEntity);
            Assert.IsNull(rovers);

            rovers = _roverService.GenerateRover("1 2 N", "LMLMLMLMM", plateauEntity);
            Assert.IsNotNull(rovers);
        }

        /// <summary>
        /// Kullanıcının girdiği komutların doğruluğunu  test eder. 
        /// </summary>
        [Test]
        public void ExecuteRoverCommandTestMethod()
        {
            Plateau plateauEntity = _pleteauService.GeneratePlateau("5 5"); 

            Rovers rovers = _roverService.GenerateRover("1 2 N", "L2MLMLMLMM1", plateauEntity);

            rovers = _roverService.ExecuteRoverCommand(rovers);
            Assert.IsNull(rovers);

            rovers = _roverService.GenerateRover("1 2  N", "LMLMLMLMM", plateauEntity);
            rovers = _roverService.ExecuteRoverCommand(rovers);
            Assert.IsNull(rovers);

            rovers = _roverService.GenerateRover("1 2 N", "LMLMLMLMM", plateauEntity);
            rovers = _roverService.ExecuteRoverCommand(rovers);
            Assert.IsNotNull(rovers);
        }
    }
}
