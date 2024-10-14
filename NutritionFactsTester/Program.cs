using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    private static readonly HttpClient client = new HttpClient();

    static async Task Main(string[] args)
    {
        client.DefaultRequestHeaders.Add("User-Agent", "HealthyFoodChoices - Windows - Version 1.0");

        var sodaBarcodes = new List<string>
        {
            "01223004",     // Pepsico Pepsi Cola Soda
            "04963406",     // Coca-Cola Classic Coke Soft Drink
            "069000019832", // Diet Pepsi
            "5000112519945" // Coca-Cola Zero
        };

        foreach (var barcode in sodaBarcodes)
        {
            var sodaInfo = await GetSodaInfo(barcode);
            if (sodaInfo != null)
            {
                ProductInfo product = new ProductInfo();
                product = JsonConverter.ConvertJson(sodaInfo.ToString());
                PrintSodaInfo(sodaInfo);
            }
        }
    }

    static async Task<JObject> GetSodaInfo(string barcode)
    {
        string url = $"https://us.openfoodfacts.org/api/v0/product/{barcode}";

        try
        {
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return JObject.Parse(responseBody);
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Error fetching data for barcode {barcode}: {e.Message}");
            return null;
        }
    }

    static void PrintSodaInfo(JObject sodaInfo)
    {
        var product = sodaInfo["product"];

        Console.WriteLine($"Soda: {product["product_name"]}");
        Console.WriteLine($"Additives: {string.Join(", ", product["additives_tags"] ?? new JArray())}");
        Console.WriteLine($"Sugars: {product["nutriments"]?["sugars"] ?? "N/A"}");
        Console.WriteLine($"Nutriscore: {product["nutriscore_grade"] ?? "N/A"}");
        Console.WriteLine("---");
    }
}



public class ProductInfo
{
    public string ProductName { get; set; }
    public string Brand { get; set; }
    public int? Kcal { get; set; }
    public double? Fat { get; set; }
    public double? SaturatedFat { get; set; }
    public double? Carbohydrates { get; set; }
    public double? Protein { get; set; }
    public double? Sugars { get; set; }
    public double? Fiber { get; set; }
    public double? Sodium { get; set; }
    public string ImageFrontUrl { get; set; }
    public string ImageIngredientsUrl { get; set; }
    public string ImageNutritionUrl { get; set; }
}

public class JsonConverter
{
    public static ProductInfo ConvertJson(string json)
    {
        var jObject = JObject.Parse(json);

        // Create the ProductInfo object and extract values, ensuring to handle null cases
        var product = new ProductInfo
        {
            ProductName = jObject["product"]?["product_name"]?.ToString(),
            Brand = jObject["product"]?["brands"]?.ToString(),
            Kcal = (int?)jObject["product"]?["nutriments"]?["energy-kcal_value"],
            Fat = (double?)jObject["product"]?["nutriments"]?["fat_100g"],
            SaturatedFat = (double?)jObject["product"]?["nutriments"]?["saturated-fat_100g"],
            Carbohydrates = (double?)jObject["product"]?["nutriments"]?["carbohydrates_100g"],
            Protein = (double?)jObject["product"]?["nutriments"]?["proteins_100g"],
            Sugars = (double?)jObject["product"]?["nutriments"]?["sugars_100g"],
            Fiber = (double?)jObject["product"]?["nutriments"]?["fiber_100g"],
            Sodium = (double?)jObject["product"]?["nutriments"]?["sodium_100g"],
            ImageFrontUrl = jObject["product"]?["selected_images"]?["front"]?["display"]?["en"]?.ToString(),
            ImageIngredientsUrl = jObject["product"]?["selected_images"]?["ingredients"]?["display"]?["en"]?.ToString(),
            ImageNutritionUrl = jObject["product"]?["selected_images"]?["nutrition"]?["display"]?["en"]?.ToString()
        };

        return product;
    }
}
