# SnackTrack

SnackTrack is a web application that allows users to input individual ingredients or scan barcodes to track the nutrition facts of their daily meals or specific items. Designed for those who want to keep an accurate log of their nutritional intake, SnackTrack helps users monitor calories and other key nutritional data.

## Features

- **Ingredient Input**: Users can manually input individual ingredients to receive detailed nutritional information such as calories, macros, vitamins, and more.
  
- **Barcode Scanner**: Users can scan barcodes of packaged food items to instantly retrieve and track nutrition facts.
  
- **Daily Nutrition Tracking**: Users can log meals and track their daily nutritional intake to ensure they are meeting their health goals.
  
- **Personalized Nutrition Goals**: Set personalized nutrition goals and receive feedback on how well you are adhering to them based on the data tracked.

## Tech Stack

- **Frontend**: C#, Blazor, MudBlazor (UI)
- **Ingredient API**: For retrieving nutrition data on individual ingredients
- **Barcode Scanner**: Integrated to fetch nutrition facts via barcodes
- **Database**: SQL Server for logging user data and meal histories

## Setup

### Prerequisites

- .NET 6.0 SDK
- API Access for Ingredient and Barcode services

### Installation

1. Clone this repository:

    ```bash
    git clone https://github.com/your-username/snacktrack.git
    cd snacktrack
    ```

2. Install dependencies:

    ```bash
    dotnet restore
    ```

3. Configure the API access keys for the ingredient database and barcode scanner in the app settings.

4. Run the application:

    ```bash
    dotnet run
    ```

## Usage

- **Input Ingredients**: Users can manually input the ingredients of their meals or snacks.
- **Scan Barcodes**: Scan food items via the barcode scanner to automatically retrieve and track their nutrition facts.
- **Track Nutrition**: Keep track of calories, protein, carbs, fats, and other relevant nutritional data for each meal.
- **Set Goals**: Users can set daily calorie or macronutrient goals and compare their intake against these goals.


## Future Enhancements

- Integration with grocery store APIs for automatic grocery list generation.
- Adding meal planning functionality to help users organize their daily meals in advance.
- Support for wearable devices to track real-time consumption data.
