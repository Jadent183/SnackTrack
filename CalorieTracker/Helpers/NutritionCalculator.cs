using CalorieTracker.Models;
using System.ComponentModel;

namespace CalorieTracker.Helpers
{
    public class NutritionCalculator : INotifyPropertyChanged
    {
        private List<SingleItemInfo> _items = new List<SingleItemInfo>();
        public List<SingleItemInfo>? Items
        {
            get => _items;
            set
            {
                if (_items != value)
                {
                    _items = value;
                    OnPropertyChanged(nameof(Items));
                    CalculateNutritionFromSingleItemList();
                }
            }
        }
        public NutritionFacts NutritionFact { get; private set; } = new NutritionFacts();

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void CalculateNutritionFromSingleItemList()
        {
            NutritionFact = new NutritionFacts
            {
                Calories = Items.Sum(item => item.Calories),
                TotalFat = Items.Sum(item => item.TotalFat),
                SaturatedFat = Items.Sum(item => item.SaturatedFat),
                Carbohydrates = Items.Sum(item => item.Carbohydrates),
                Cholesterol = Items.Sum(item => item.Cholesterol),
                Sodium = Items.Sum(item => item.Sodium),
                Fiber = Items.Sum(item => item.Fiber),
                Sugars = Items.Sum(item => item.Sugars),
                Protein = Items.Sum(item => item.Protein)
            };

            OnPropertyChanged(nameof(NutritionFact));
        }

        public void AddItem(SingleItemInfo item)
        {
            Items.Add(item);
            CalculateNutritionFromSingleItemList();
        }

        public void RemoveItem(SingleItemInfo item)
        {
            if (Items.Remove(item))
            {
                CalculateNutritionFromSingleItemList();
            }
        }

        public void ClearItems()
        {
            Items.Clear();
            CalculateNutritionFromSingleItemList();
        }
    }
}
