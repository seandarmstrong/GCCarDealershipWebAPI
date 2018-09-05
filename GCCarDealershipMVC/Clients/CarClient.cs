using System.Collections.Generic;
using GCCarDealership.Domain.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Configuration;
using System.Threading.Tasks;

namespace GCCarDealershipMVC.Clients
{
    public class CarClient
    {
        private readonly IRestClient _client;

        public CarClient()
        {
            _client = new RestClient(ConfigurationManager.AppSettings["GCCarApiBaseUrl"]);
        }

        public async Task<IEnumerable<CarModel>> GetCars()
        {
            var request = new RestRequest("api/Cars", Method.GET);
            var response = await _client.ExecuteTaskAsync(request);
            return JsonConvert.DeserializeObject<IEnumerable<CarModel>>(response.Content);
        }

    }
}