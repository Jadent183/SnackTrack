//using System;
//using System.Linq;
//using System.Net.Http;
//using System.Text;
//using System.Text.Json.Serialization;
//using System.Threading.Tasks;
//using CalorieTracker.Models;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;

//public class JsonToSingleItemConverter
//{
//    public static SingleItemInfo ConvertJsonToSingleItemInfo(string jsonResponse, string weightInGrams)
//    {
//        var json = JObject.Parse(jsonResponse);
//        var food = json["foods"][0];

//        int inputWeight = int.Parse(weightInGrams);
//        double defaultWeight = (double)food["serving_weight_grams"];
//        double factor = inputWeight / defaultWeight;

//        return new SingleItemInfo
//        {
//            Name = food["food_name"].Type != JTokenType.Null ? (string)food["food_name"] : "",
//            Calories = food["nf_calories"].Type != JTokenType.Null ? TruncateToOneDecimal(factor * (double)food["nf_calories"]) : 0,
//            TotalFat = food["nf_total_fat"].Type != JTokenType.Null ? TruncateToOneDecimal(factor * (double)food["nf_total_fat"]) : 0,
//            SaturatedFat = food["nf_saturated_fat"].Type != JTokenType.Null ? TruncateToOneDecimal(factor * (double)food["nf_saturated_fat"]) : 0,
//            Cholesterol = food["nf_cholesterol"].Type != JTokenType.Null ? TruncateToOneDecimal(factor * (double)food["nf_cholesterol"]) : 0,
//            Sodium = food["nf_sodium"].Type != JTokenType.Null ? TruncateToOneDecimal(factor * (double)food["nf_sodium"]) : 0,
//            Carbohydrates = food["nf_total_carbohydrate"].Type != JTokenType.Null ? TruncateToOneDecimal(factor * (double)food["nf_total_carbohydrate"]) : 0,
//            Fiber = food["nf_dietary_fiber"].Type != JTokenType.Null ? TruncateToOneDecimal(factor * (double)food["nf_dietary_fiber"]) : 0,
//            Sugars = food["nf_sugars"].Type != JTokenType.Null ? TruncateToOneDecimal(factor * (double)food["nf_sugars"]) : 0,
//            Protein = food["nf_protein"].Type != JTokenType.Null ? TruncateToOneDecimal(factor * (double)food["nf_protein"]) : 0,
//            Potassium = food["nf_potassium"].Type != JTokenType.Null ? TruncateToOneDecimal(factor * (double)food["nf_potassium"]) : 0,
//            PhotoThumb = food["photo"]["thumb"].Type != JTokenType.Null ? (string)food["photo"]["thumb"] : ""
//        };
//    }

//    public static SingleItemInfo ConvertJsonToSingleServingInfo(string jsonResponse)
//    {
//        var json = JObject.Parse(jsonResponse);
//        var food = json["foods"][0];

//        return new SingleItemInfo
//        {
//            Name = food["food_name"].Type != JTokenType.Null ? (string)food["food_name"] : "",
//            Calories = food["nf_calories"].Type != JTokenType.Null ? TruncateToOneDecimal((double)food["nf_calories"]) : 0,
//            TotalFat = food["nf_total_fat"].Type != JTokenType.Null ? TruncateToOneDecimal((double)food["nf_total_fat"]) : 0,
//            SaturatedFat = food["nf_saturated_fat"].Type != JTokenType.Null ? TruncateToOneDecimal((double)food["nf_saturated_fat"]) : 0,
//            Cholesterol = food["nf_cholesterol"].Type != JTokenType.Null ? TruncateToOneDecimal((double)food["nf_cholesterol"]) : 0,
//            Sodium = food["nf_sodium"].Type != JTokenType.Null ? TruncateToOneDecimal((double)food["nf_sodium"]) : 0,
//            Carbohydrates = food["nf_total_carbohydrate"].Type != JTokenType.Null ? TruncateToOneDecimal((double)food["nf_total_carbohydrate"]) : 0,
//            Fiber = food["nf_dietary_fiber"].Type != JTokenType.Null ? TruncateToOneDecimal((double)food["nf_dietary_fiber"]) : 0,
//            Sugars = food["nf_sugars"].Type != JTokenType.Null ? TruncateToOneDecimal((double)food["nf_sugars"]) : 0,
//            Protein = food["nf_protein"].Type != JTokenType.Null ? TruncateToOneDecimal((double)food["nf_protein"]) : 0,
//            Potassium = food["nf_potassium"].Type != JTokenType.Null ? TruncateToOneDecimal((double)food["nf_potassium"]) : 0,
//            PhotoThumb = food["photo"]["thumb"].Type != JTokenType.Null ? (string)food["photo"]["thumb"] : "",
//            ServingSize = $"{food["serving_qty"]} {food["serving_unit"]} ({food["serving_weight_grams"]}g)"
//        };
//    }


//    private static double TruncateToOneDecimal(double value)
//    {
//        return Math.Truncate(value * 10) / 10;
//    }

//}



using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CalorieTracker.Models;
using Newtonsoft.Json.Linq;

public class JsonToSingleItemConverter
{
    public static SingleItemInfo ConvertJsonToSingleItemInfo(string jsonResponse)
    {
        var json = JObject.Parse(jsonResponse);
        var food = json["foods"][0];

        return new SingleItemInfo
        {
            Name = food["food_name"].Type != JTokenType.Null ? (string)food["food_name"] : null,
            Brand = food["brand_name"].Type != JTokenType.Null ? (string)food["brand_name"] : null,
            Calories = food["nf_calories"].Type != JTokenType.Null ? TruncateToOneDecimal((double)food["nf_calories"]) : null,
            TotalFat = food["nf_total_fat"].Type != JTokenType.Null ? TruncateToOneDecimal((double)food["nf_total_fat"]) : null,
            SaturatedFat = food["nf_saturated_fat"].Type != JTokenType.Null ? TruncateToOneDecimal((double)food["nf_saturated_fat"]) : null,
            Carbohydrates = food["nf_total_carbohydrate"].Type != JTokenType.Null ? TruncateToOneDecimal((double)food["nf_total_carbohydrate"]) : null,
            Cholesterol = food["nf_cholesterol"].Type != JTokenType.Null ? TruncateToOneDecimal((double)food["nf_cholesterol"]) : null,
            Sodium = food["nf_sodium"].Type != JTokenType.Null ? TruncateToOneDecimal((double)food["nf_sodium"]) : null,
            Fiber = food["nf_dietary_fiber"].Type != JTokenType.Null ? TruncateToOneDecimal((double)food["nf_dietary_fiber"]) : null,
            Sugars = food["nf_sugars"].Type != JTokenType.Null ? TruncateToOneDecimal((double)food["nf_sugars"]) : null,
            Protein = food["nf_protein"].Type != JTokenType.Null ? TruncateToOneDecimal((double)food["nf_protein"]) : null,
            Potassium = food["nf_potassium"].Type != JTokenType.Null ? TruncateToOneDecimal((double)food["nf_potassium"]) : null,
            PhotoThumb = food["photo"]["thumb"].Type != JTokenType.Null ? (string)food["photo"]["thumb"] : null,
            ImageNutritionUrl = food["photo"]["highres"].Type != JTokenType.Null ? (string)food["photo"]["highres"] : null,
            ServingSize = $"{food["serving_qty"]} {food["serving_unit"]} ({food["serving_weight_grams"]}g)",
            JsonResponse = jsonResponse
        };
    }

    public static SingleItemInfo CalculateNutritionInfo(SingleItemInfo baseItem, int weightInGrams)
    {

        //int inputWeight = int.Parse(weightInGrams);
        double baseWeight = ExtractWeightFromServingSize(baseItem.ServingSize);
        double factor = weightInGrams / baseWeight;

        return new SingleItemInfo
        {
            Name = baseItem.Name,
            Brand = baseItem.Brand,
            Calories = baseItem.Calories.HasValue ? TruncateToOneDecimal(factor * baseItem.Calories.Value) : null,
            TotalFat = baseItem.TotalFat.HasValue ? TruncateToOneDecimal(factor * baseItem.TotalFat.Value) : null,
            SaturatedFat = baseItem.SaturatedFat.HasValue ? TruncateToOneDecimal(factor * baseItem.SaturatedFat.Value) : null,
            Carbohydrates = baseItem.Carbohydrates.HasValue ? TruncateToOneDecimal(factor * baseItem.Carbohydrates.Value) : null,
            Cholesterol = baseItem.Cholesterol.HasValue ? TruncateToOneDecimal(factor * baseItem.Cholesterol.Value) : null,
            Sodium = baseItem.Sodium.HasValue ? TruncateToOneDecimal(factor * baseItem.Sodium.Value) : null,
            Fiber = baseItem.Fiber.HasValue ? TruncateToOneDecimal(factor * baseItem.Fiber.Value) : null,
            Sugars = baseItem.Sugars.HasValue ? TruncateToOneDecimal(factor * baseItem.Sugars.Value) : null,
            Protein = baseItem.Protein.HasValue ? TruncateToOneDecimal(factor * baseItem.Protein.Value) : null,
            Potassium = baseItem.Potassium.HasValue ? TruncateToOneDecimal(factor * baseItem.Potassium.Value) : null,
            PhotoThumb = baseItem.PhotoThumb,
            ImageNutritionUrl = baseItem.ImageNutritionUrl,
            ServingSize = $"{TruncateToOneDecimal(weightInGrams)}g",
            JsonResponse = baseItem.JsonResponse
        };
    }

    private static double TruncateToOneDecimal(double value)
    {
        return Math.Truncate(value * 10) / 10;
    }

    private static double ExtractWeightFromServingSize(string servingSize)
    {
        int startIndex = servingSize.LastIndexOf('(') + 1;
        int endIndex = servingSize.LastIndexOf('g');
        string weightString = servingSize.Substring(startIndex, endIndex - startIndex);
        return double.Parse(weightString);
    }
}