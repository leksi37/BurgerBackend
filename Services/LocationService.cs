using Microsoft.Net.Http.Headers;
using WebApi.Models.Location;

namespace WebApi.Services
{

    /**
     * An interface for the LocationService to add level of abstraction and have access only to relative information
     */
    public interface ILocationService
    {
        Task<List<LocationResponse>> GetNearbyBurgerPlaces(LocationRequest model);
        
    }
    public class LocationService : ILocationService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient httpClient;

        public LocationService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            httpClient = _httpClientFactory.CreateClient();
        }

        /**
         * Not finished, but the plan is to pass Latitude and Longitude and make a GET request using the goolge maps api
         */
        public async Task<List<LocationResponse>> GetNearbyBurgerPlaces(LocationRequest model)
        {
            //Send a get request to retrieve all nearby places with keyword = burger within 1500 range
            //Also save key securely and find a way to hide it, so others won't use it (Connected with billing)
            var httpRequestMessage = new HttpRequestMessage(
               HttpMethod.Get,
               $"https://maps.googleapis.com/maps/api/place/nearbysearch/json?location={model.Longitude}%2C{model.Latitude}&keyword=burger&radius=1500&key=");
            await httpClient.SendAsync(httpRequestMessage);
            //Here the data from the repsponse should be read and properly mapped to a LocationResponse object (Mapper should be created)
            var locationResponse = new LocationResponse { Name = "A", Address = "A", OpeningHours = "A" };
            var list = new List<LocationResponse>();
            list.Add(locationResponse);
            return list;
        }
    }
    }
