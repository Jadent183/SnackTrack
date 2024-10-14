using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CalorieTracker.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class JsonToSingleItemConverter
{
    public static SingleItemInfo ConvertJsonToSingleItemInfo(string jsonResponse, string weightInGrams)
    {
        var json = JObject.Parse(jsonResponse);
        var food = json["foods"][0];

        int inputWeight = int.Parse(weightInGrams);
        double defaultWeight = (double)food["serving_weight_grams"];
        double factor = inputWeight / defaultWeight;

        return new SingleItemInfo
        {
            Name = food["food_name"].Type != JTokenType.Null ? (string)food["food_name"] : "",
            Calories = food["nf_calories"].Type != JTokenType.Null ? TruncateToOneDecimal(factor * (double)food["nf_calories"]) : 0,
            TotalFat = food["nf_total_fat"].Type != JTokenType.Null ? TruncateToOneDecimal(factor * (double)food["nf_total_fat"]) : 0,
            SaturatedFat = food["nf_saturated_fat"].Type != JTokenType.Null ? TruncateToOneDecimal(factor * (double)food["nf_saturated_fat"]) : 0,
            Cholesterol = food["nf_cholesterol"].Type != JTokenType.Null ? TruncateToOneDecimal(factor * (double)food["nf_cholesterol"]) : 0,
            Sodium = food["nf_sodium"].Type != JTokenType.Null ? TruncateToOneDecimal(factor * (double)food["nf_sodium"]) : 0,
            Carbohydrates = food["nf_total_carbohydrate"].Type != JTokenType.Null ? TruncateToOneDecimal(factor * (double)food["nf_total_carbohydrate"]) : 0,
            Fiber = food["nf_dietary_fiber"].Type != JTokenType.Null ? TruncateToOneDecimal(factor * (double)food["nf_dietary_fiber"]) : 0,
            Sugars = food["nf_sugars"].Type != JTokenType.Null ? TruncateToOneDecimal(factor * (double)food["nf_sugars"]) : 0,
            Protein = food["nf_protein"].Type != JTokenType.Null ? TruncateToOneDecimal(factor * (double)food["nf_protein"]) : 0,
            Potassium = food["nf_potassium"].Type != JTokenType.Null ? TruncateToOneDecimal(factor * (double)food["nf_potassium"]) : 0,
            PhotoThumb = food["photo"]["thumb"].Type != JTokenType.Null ? (string)food["photo"]["thumb"] : ""
        };
    }

    private static double TruncateToOneDecimal(double value)
    {
        return Math.Truncate(value * 10) / 10;
    }

}





