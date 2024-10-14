using CalorieTracker.Models;
using Newtonsoft.Json.Linq;
using System.Numerics;

namespace CalorieTracker.Helpers
{
    public class JsonToBarcodeProductConverter
    {
        public static SingleItemInfo ConvertJson(JObject jObject)
        {
            var product = new SingleItemInfo();

            if (jObject["product"] is JObject productObj)
            {
                product.Name = productObj["product_name_en"]?.ToString() ?? "";
                product.Brand = productObj["brands"]?.ToString() ?? "";

                if (productObj["nutriments"] is JObject nutriments)
                {
                    product.Calories = TryGetDouble(nutriments, "energy-kcal_100g");
                    product.TotalFat = TryGetDouble(nutriments, "fat_100g");
                    product.SaturatedFat = TryGetDouble(nutriments, "saturated-fat_100g");
                    product.Carbohydrates = TryGetDouble(nutriments, "carbohydrates_100g");
                    product.Protein = TryGetDouble(nutriments, "proteins_100g");
                    product.Sugars = TryGetDouble(nutriments, "sugars_100g");
                    product.Fiber = TryGetDouble(nutriments, "fiber_100g");
                    product.Sodium = TryGetDouble(nutriments, "sodium_100g");
                }

                product.PhotoThumb = productObj["image_front_url"]?.ToString() ?? "";
                product.ImageNutritionUrl = productObj["image_nutrition_url"]?.ToString() ?? "";
            }

            return product;
        }

        private static double TryGetDouble(JObject obj, string propertyName)
        {
            if (obj[propertyName] != null && double.TryParse(obj[propertyName].ToString(), out double result))
            {
                return TruncateToOneDecimal(result);
            }
            return 0;
        }

        private static double TruncateToOneDecimal(double value)
        {
            return Math.Truncate(value * 10) / 10;
        }

    }
}
