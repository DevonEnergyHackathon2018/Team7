using Griedy.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Griedy.Lib.DataAccess
{
    public static class CallModel
    {

        private static HttpClient _client;

        static CallModel()
        {
            _client = new HttpClient();
            //_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "yqIvuKjLPAh/kpOsAX2tb55hQkrqzZpKCzRTBk3/2r3Xo225sCNxk8VdOG5X5I2qpm9dv7LwTj0zcEh5S/fXMg==");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "4Iju/5oz74gaNGcb6cewFo9LazMUXZP99gSiW88cbItwOBFJxVUqjm0bMV4HdBYWZIkysHHZrJLpYET18tJHuA==");
        }

        public static async Task<double?> MakeRequest(List<CompressorInputLine> lines)
        {
            var data = new
            {
                Inputs = new {
                    input1 = new
                    {
                        ColumnNames = lines.First().Headers(),
                        Values = lines.Select(line => line.Values()).ToArray()
                        //Values = new string[][]
                        //{
                        //    new string[]{ "value", "", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "value", "0", "0", "0", "0", "value", "0", "0", "0", "0", "0", "0", "value", "0", "value", "0", "0", "0", "0", "0", "value" },  
                        //    new string[] { "value", "", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "value", "0", "0", "0", "0", "value", "0", "0", "0", "0", "0", "0", "value", "0", "value", "0", "0", "0", "0", "0", "value" }
                        //}
                    }
                },
                GlobalParameters = new Dictionary<string, string>()
            };
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            //var baseUri = new Uri("https://ussouthcentral.services.azureml.net/workspaces/732d4419dcd94688b8d2701c48678ca5/services/649dfea7053b4232956810cff89d03ce/execute?api-version=2.0&format=swagger");
            var baseUri = new Uri("https://ussouthcentral.services.azureml.net/workspaces/732d4419dcd94688b8d2701c48678ca5/services/9be3e68c9b5146b0917b38f1dea22c9a/execute?api-version=2.0&details=true");
            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(baseUri, ""),
                Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json")
            };

            
            var response = await _client.SendAsync(request);
            string responseBody = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();

            dynamic result = Newtonsoft.Json.JsonConvert.DeserializeObject(responseBody);
            dynamic x = result.Results.output1.value.Values[0];

            string scoredLabels = x[x.Count-2];
            string scoredProbabilities = x[x.Count - 1];

            double value;
            return double.TryParse(scoredProbabilities, out value) ? (double?)value : null;
        }

    }
}
