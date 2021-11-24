using System;
using System.Linq;
using BusBoard.Clients;

namespace BusBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
            Console.WriteLine("Enter a postcode to find the next 5 buses arriving at your four nearest bus stops");
            string PostcodeInput = Console.ReadLine();
            PostcodesClient postcodesClient = new PostcodesClient();
            var postcodeResult = postcodesClient.GetPostcodeCoords(PostcodeInput);
            TflClient tflClient = new TflClient();

            var nearestStopPoints = tflClient
                .GetNearestStopPoints(postcodeResult.Longitude, postcodeResult.Latitude)
                .OrderBy(a => a.Distance)
                .Take(4);
              
            foreach (var stopPoint in nearestStopPoints)
            {
                Console.Out.WriteLine(stopPoint.CommonName);
                var arrivalsAtStop = tflClient
                    .GetArrivals(stopPoint.NaptanId)
                    .OrderBy(a => a.ExpectedArrival)
                    .Take(5)
                    .ToList();
                foreach (var arrivalPrediction in arrivalsAtStop)
                {
                    Console.WriteLine($"Bus {arrivalPrediction.LineName} arriving at {arrivalPrediction.ExpectedArrival.ToShortTimeString()} heading towards {arrivalPrediction.DestinationName}");
                }
 
                Console.WriteLine();
            }
            
       
            

            
        }
    }
}