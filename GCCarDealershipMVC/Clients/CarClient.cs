using GCCarDealership.Domain.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
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

        public async Task<IEnumerable<CarModel>> SearchCars(string make = null, string model = null, int? year = null, string color = null)
        {
            var request = new RestRequest("api/Cars/Search");
            request.Parameters.Add(new Parameter()
            {
                Name = "make",
                Type = ParameterType.QueryString,
                Value = make
            });
        }

    }
}