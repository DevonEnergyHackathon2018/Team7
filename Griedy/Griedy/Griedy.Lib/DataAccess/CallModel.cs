using Griedy.Lib.Enums;
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

        public async static Task<List<CompressorAggregatedRisk>> CalculateFullSet(List<CompressorInputLine> lines)
        {
            var retval = new List<CompressorAggregatedRisk>();
            //separate call for each unique compressor (asset name)
            var compGroups = lines.GroupBy(l => l.AssetName);

            foreach (var g in compGroups)
            {
                var result = await MakeRequest(g.ToList());
                retval.Add(new CompressorAggregatedRisk { CompressorName = g.Key, Risk = GetRisk(result) });
            }

            return retval;
        }

        private static RiskType GetRisk(double result)
        {
            if(result < 0.5)
            {
                return RiskType.LOW;
            }
            else if(result < 0.75)
            {
                return RiskType.MEDIUM;
            }
            else
            {
                return RiskType.HIGH;
            }
        }

        private static async Task<double> MakeRequest(List<CompressorInputLine> lines)
        {
            var data = new
            {
                Inputs = new {
                    input1 = new
                    {
                        ColumnNames = lines.First().Headers(),
                        //Values = new string[][] { lines.Select(line => line.Values()).First() }
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

            //get all the final probabilities
            dynamic valueSet = result.Results.output1.value.Values;

            //calculate an average of them.  this being dynamic made me do it the old-school way instead of the LINQ way.
            double aggregator = 0.0;
            long count = 0;

            foreach (var val in valueSet)
            {
                string prob = val[val.Count - 1];
                double dubVal = 0.0;

                if(double.TryParse(prob, out dubVal))
                {
                    aggregator += dubVal;
                    count++;
                }
            }
           
            if(count > 0)
            {
                return aggregator / (double)count;
            }
            else
            {
                return 0.0;
            }
        }

    }
}
