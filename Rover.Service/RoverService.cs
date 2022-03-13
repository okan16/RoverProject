using Rover.Core;
using Rover.Service.Interface;
using Rover.Shared.Enums;
using Rover.Shared.Helpers;
using Rover.Shared.Helpers.Interfaces;
using System;

namespace Rover.Service
{
    public class RoverService : IRoverService
    {
        public IRoverHelper _roverHelper;

        public Rovers GenerateRover(string roverCoordinate, string roverCommand, Plateau plateau)
        {
            _roverHelper = new RoverHelper();

            Rovers entity = null;

            int xCoordinate = -1;
            int yCoordinate = -1;
            Direction direction = Direction.Undefined;

            bool result = _roverHelper.CalculateCoordinates(roverCoordinate, ref xCoordinate, ref yCoordinate, ref direction);

            if (result)
            {
                entity = new Rovers()
                {
                    XCoordinate = xCoordinate,
                    YCoordinate = yCoordinate,
                    Direction = direction
                };

                bool pointResult = _roverHelper.CalculateRoverPoint(plateau, entity);

                if (pointResult)
                {
                    bool roverCommandResult = _roverHelper.CalculateCommands(roverCommand);

                    if (roverCommandResult)
                    {
                        entity.Command = roverCommand;
                    }
                    else
                    {
                        Console.WriteLine("Girilen komutlar rover icin gecerli degildir! Sadece L,R veya M giriniz.");
                        return null;
                    }
                }
                else
                {
                    Console.WriteLine("Gezilecek alan ile rover koordinatı arasında uyumsuzluk vardır.");
                    return null;
                    
                }
            }
            else
            {
                Console.WriteLine("Rover icin girilen yer yon bilgisi yanlistir. Örnek: 1 2 N");
                return null;
            }

            return entity;
        }

        public Rovers ExecuteRoverCommand(Rovers entity)
        {
            if(entity != null)
            {
                foreach (var item in entity.Command)
                {
                    if (item == 'L')
                    {
                        _roverHelper.TurnLeft(entity);
                    }
                    else if (item == 'R')
                    {
                        _roverHelper.TurnRight(entity);
                    }
                    else if (item == 'M')
                    {
                        _roverHelper.Move(entity);
                    }
                }

            }
           

            return entity;
        }
    }
}
