using System;
using System.Net.Http;
using System.Threading.Tasks;
using CalorieTracker.Helpers;
using CalorieTracker.Models;
using Newtonsoft.Json.Linq;

namespace CalorieTracker.APIHandlers
{
    public class OpenFoodFactsAPIHandler
    {
        private static readonly HttpClient client = new HttpClient();
        private const string BaseUrl = "https://us.openfoodfacts.net/api/v0/product/";

        public static async Task<SingleItemInfo> GetInfoFromBarcode(string barcode)
        {
            string url = $"{BaseUrl}{barcode}";

            try
            {
                using (var request = new HttpRequestMessage(HttpMethod.Get, url))
                {
                    request.Headers.Add("User-Agent", "HealthyFoodChoices - Windows - Version 1.0");

                    HttpResponseMessage response = await client.SendAsync(request);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return JsonToBarcodeProductConverter.ConvertJson(JObject.Parse(responseBody));
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Error fetching data for barcode {barcode}: {e.Message}");
                return null;
            }
        }
    }
}