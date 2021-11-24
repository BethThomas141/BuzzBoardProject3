using System;

namespace BusBoard.Models.TflModels
{
    public class ArrivalPrediction
    {
        public string LineName { get; set; }
        public DateTime ExpectedArrival { get; set; }
        public string DestinationName { get; set; }
        
    }
}