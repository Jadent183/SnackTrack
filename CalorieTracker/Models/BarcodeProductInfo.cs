namespace CalorieTracker.Models
{
    public class BarcodeProductInfo
    {
        public string? Name { get; set; }
        public string? Brand { get; set; }
        public double? Calories { get; set; }
        public double? TotalFat { get; set; }
        public double? SaturatedFat { get; set; }
        public double? Carbohydrates { get; set; }
        public double? Protein { get; set; }
        public double? Sugars { get; set; }
        public double? Fiber { get; set; }
        public double? Sodium { get; set; }
        public string? ImageFrontUrl { get; set; }
        public string? ImageNutritionUrl { get; set; }
    }

}
