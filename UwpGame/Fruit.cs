using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Imaging;

namespace UwpGame
{
    public class Fruit : ViewModel
    {
        private readonly string Resources = "ms-appx:Assets/{0}.png";

        public bool isOnSale = true;

        private int Rarity = int.MinValue;

        private int MinPrice = int.MinValue;

        private int MaxPrice = int.MinValue;

        public int Price { get; private set; }

        public int Purchased { get; private set; } = 0;

        public BitmapImage Photo { get; private set; }

        public Fruit(string name, int minPrice, int maxPrice, int rarity)
        {
            this.Photo = new BitmapImage(new Uri(String.Format(this.Resources, name)));
            this.MinPrice = minPrice;
            this.MaxPrice = maxPrice;
            if (rarity < 1) rarity = 1;
            else if (rarity > 9) rarity = 9;
            this.Rarity = rarity;
            this.RefreshPrice();
        }

        private void RefreshPrice()
        {
            this.Price = new Random().Next(this.MinPrice, this.MaxPrice + 1);
        }

        private void RefreshState()
        {
            this.isOnSale = new Random().Next(1, 11) <= this.Rarity ? true : false;
        }

        public void Refresh()
        {
            this.RefreshPrice();
            this.RefreshState();
        }

    }
}
