using Rover.Core;
using Rover.Service;
using Rover.Service.Interface;
using System;
using System.Collections.Generic;

namespace Rover.App
{
    class Program
    {
        public static IPlateauService _pleteauService;
        public static IRoverService _roverService;

        static void Main(string[] args)
        {
            _pleteauService = new PlateauService();
            _roverService = new RoverService();

            Plateau plateauEntity = null;
            List<Rovers> roverList = new List<Rovers>();

            // Plato koordinat kotrolleri yapiliyor
            // Koorinatlara uymayan bir veri geldiginde tekrar girilmesi isteniyor
            while (true)
            {
                Console.Write("Boyutları giriniz: ");
                string plateauWidthHeight = Console.ReadLine();

                plateauEntity = _pleteauService.GeneratePlateau(plateauWidthHeight);

                if (plateauEntity != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Kurallara uygun alan tanımı yapınız. Örnek: 5 5");
                }
            }

            int roverCount = 1;

            //default 2 tane rover olduğu varsayıldı. Daha fazlası olması gerekirse kullanıcıdan rover sayısı istenerek dinamik hale getirilebilir.
            while (roverCount < 3)
            {
                try
                {
                    Console.Write("{0}. Rover yer yön: ", roverCount);
                    string roverCoordinate = Console.ReadLine();

                    Console.Write("{0}. Rover komutlari: ", roverCount);
                    string roverCommand = Console.ReadLine();

                    Rovers roverEntity = _roverService.GenerateRover(roverCoordinate, roverCommand, plateauEntity);

                    if (roverEntity != null)
                    {
                        roverEntity.Order = roverCount;
                        roverCount += 1;

                        roverList.Add(roverEntity);
                    }
                    else
                    {
                        Console.WriteLine("Beklenmedik bir hata oluştu.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (Rovers roverItem in roverList)
            {
                Rovers item = _roverService.ExecuteRoverCommand(roverItem);

                Console.WriteLine(item.XCoordinate + " " + item.YCoordinate + " " + item.Direction);
            }
        }
    }
}
