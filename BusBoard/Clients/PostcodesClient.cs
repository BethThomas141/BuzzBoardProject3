using BusBoard.Models.Postcodes;
using RestSharp;

namespace BusBoard.Clients
{
    public class PostcodesClient
    {
        public PostcodeResult GetPostcodeCoords(string Postcode)
        {
            var client = new RestClient("https://api.postcodes.io");
            var request = new RestRequest($"postcodes/{Postcode}", DataFormat.Json);
            var response = client.Get<PostcodeResponse>(request);
            return response.Data.Result;
        }
    }
}