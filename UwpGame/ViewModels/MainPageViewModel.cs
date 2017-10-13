using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UwpGame.Apps;
using UwpGame.Models;
using UwpGame.ViewModels.Common;
using UwpGame.Views;

namespace UwpGame.ViewModels
{
    public class MainPageViewModel : ViewModel
    {
        public int Wealth { get; private set; } = 1234567;

        public RelayCommand Purchase { get; private set; }

        public RelayCommand Sale { get; private set; }

        private List<Fruit> fruits;

        public ObservableCollection<Fruit> Fruits { get { return this.NewFrutis(); } }

        public int MyProperty { get; set; }

        public MainPageViewModel()
        {
            this.Initialize();
            this.Purchase = new RelayCommand(this.ExecutePurchase);
            this.Sale = new RelayCommand(this.ExecuteSale);
        }

        private void Initialize()
        {
            this.fruits = new List<Fruit>();
            for (int i = 0; i < 9; i++)
            {
                var fruit = this.DefineFruit((FruitName)i);
                this.fruits.Add(new Fruit(fruit.Item1, fruit.Item2, fruit.Item3, fruit.Item4));
            }
            this.RaisePropertyChanged(nameof(this.Fruits));
        }

        public void Refresh()
        {
            for (int i = 0; i < this.fruits.Count; i++) this.fruits[i].Refresh();

            this.fruits.Sort((x, y) => -x.Price.CompareTo(y.Price));

            this.RaisePropertyChanged(nameof(this.Fruits));
        }

        private ObservableCollection<Fruit> NewFrutis()
        {
            var list = this.fruits.Where(o => o.isOnSale == true);

            return new ObservableCollection<Fruit>(list);
        }

        private Tuple<string, int, int, int> DefineFruit(FruitName fruitName)
        {
            var minPrice = int.MinValue;
            var maxPrice = int.MinValue;
            var rarity = int.MinValue;
            switch (fruitName)
            {
                case FruitName.Apple: { minPrice = 2; maxPrice = 10; rarity = 9; break; }
                case FruitName.Banana: { minPrice = 2; maxPrice = 30; rarity = 3; break; }
                case FruitName.Cherry: { minPrice = 10; maxPrice = 100; rarity = 1; break; }
                case FruitName.Eggplant: { minPrice = 12; maxPrice = 22; rarity = 8; break; }
                case FruitName.Grape: { minPrice = 5; maxPrice = 20; rarity = 6; break; }
                case FruitName.Orange: { minPrice = 75; maxPrice = 90; rarity = 4; break; }
                case FruitName.Pear: { minPrice = 2; maxPrice = 10; rarity = 7; break; }
                case FruitName.Strawberry: { minPrice = 15; maxPrice = 55; rarity = 5; break; }
                case FruitName.Tomato: { minPrice = 40; maxPrice = 100; rarity = 2; break; }
                default: break;
            }
            return new Tuple<string, int, int, int>(Enum.GetName(typeof(FruitName), fruitName), minPrice, maxPrice, rarity);
        }

        public void ExecutePurchase(object parameter)
        {
            General.NavigateForward(new BusinessView(new Tuple<Business, Fruit>(Apps.Business.Purchase, (Fruit)parameter)));
        }

        public void ExecuteSale(object parameter)
        {
            General.NavigateForward(new BusinessView(new Tuple<Business, Fruit>(Apps.Business.Sale, (Fruit)parameter)));
        }
    }
}
