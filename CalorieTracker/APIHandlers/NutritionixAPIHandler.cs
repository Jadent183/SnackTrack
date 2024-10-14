using CalorieTracker.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Text;

namespace CalorieTracker.APIHandlers
{
    public class NutritionixAPIHandler
    {

        private const string AppId = "9885650a";
        private const string AppKey = "c9580be26fee88d7792b5b4bc76458e4";

        public static async Task<NutritionixSearchResult> SearchFoodAsync(string query, IHttpClientFactory clientFactory, CancellationToken cancellationToken)
        {
            using (var client = clientFactory.CreateClient("NutritionixApi"))
            {
                string url = $"https://trackapi.nutritionix.com/v2/search/instant?query={Uri.EscapeDataString(query)}";
                client.DefaultRequestHeaders.Add("x-app-id", AppId);
                client.DefaultRequestHeaders.Add("x-app-key", AppKey);

                HttpResponseMessage response = await client.GetAsync(url, cancellationToken);
                string jsonResponse = await response.Content.ReadAsStringAsync(cancellationToken);

                var result = JsonConvert.DeserializeObject<NutritionixSearchResult>(jsonResponse);
                return result;
            }
        }

        public static async Task<string> GetNutritionFactsAsync(string item)
        {
            //if (string.IsNullOrEmpty(item) || string.IsNullOrEmpty(weight)) return null;
            //weight = weight.Replace(" g", "").Trim();
            using (HttpClient client = new HttpClient())
            {
                string url = "https://trackapi.nutritionix.com/v2/natural/nutrients";
                client.DefaultRequestHeaders.Add("x-app-id", AppId);
                client.DefaultRequestHeaders.Add("x-app-key", AppKey);
                var jsonBody = new { query = item };
                var json = JsonConvert.SerializeObject(jsonBody);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);
                string jsonResponse = await response.Content.ReadAsStringAsync();
                return jsonResponse;
                //return JsonToSingleItemConverter.ConvertJsonToSingleItemInfo(jsonResponse, weight);
            }
        }



        public class NutritionixSearchResult
        {
            [JsonPropertyName("common")]
            public List<CommonFood> Common { get; set; }

            [JsonPropertyName("branded")]
            public List<BrandedFood> Branded { get; set; }
        }

        public class CommonFood
        {
            [JsonProperty("food_name")]
            public string FoodName { get; set; }

            [JsonProperty("serving_unit")]
            public string ServingUnit { get; set; }

            [JsonProperty("tag_name")]
            public string TagName { get; set; }

            [JsonProperty("serving_qty")]
            public double ServingQty { get; set; }

            [JsonProperty("common_type")]
            public object CommonType { get; set; }

            [JsonProperty("tag_id")]
            public string TagId { get; set; }

            [JsonProperty("photo")]
            public Photo Photo { get; set; }

            [JsonProperty("locale")]
            public string Locale { get; set; }
        }

        public class BrandedFood
        {
            [JsonProperty("food_name")]
            public string FoodName { get; set; }

            [JsonProperty("serving_unit")]
            public string ServingUnit { get; set; }

            [JsonProperty("nix_brand_id")]
            public string NixBrandId { get; set; }

            [JsonProperty("brand_name_item_name")]
            public string BrandNameItemName { get; set; }

            [JsonProperty("serving_qty")]
            public double ServingQty { get; set; }

            [JsonProperty("nf_calories")]
            public double? NfCalories { get; set; }

            [JsonProperty("photo")]
            public Photo Photo { get; set; }

            [JsonProperty("brand_name")]
            public string BrandName { get; set; }

            [JsonProperty("region")]
            public int Region { get; set; }

            [JsonProperty("brand_type")]
            public int BrandType { get; set; }

            [JsonProperty("nix_item_id")]
            public string NixItemId { get; set; }

            [JsonProperty("locale")]
            public string Locale { get; set; }
        }

        public class Photo
        {
            [JsonProperty("thumb")]
            public string Thumb { get; set; }
        }

    }

}



