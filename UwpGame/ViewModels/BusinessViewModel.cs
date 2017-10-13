using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UwpGame.Apps;
using UwpGame.Models;
using UwpGame.ViewModels.Common;
using Windows.UI.Xaml.Data;

namespace UwpGame.ViewModels
{
    public class BusinessViewModel : ViewModel
    {
        public Fruit Fruit { get; set; }

        public int BusinessAmount { get; private set; }

        public int BusinessModel { get; private set; }

        public RelayCommand Exit { get; private set; }

        public RelayCommand Brought { get; private set; }

        public BusinessViewModel(object param)
        {
            var items = (Tuple<Business, Fruit>)param;
            this.Fruit = items.Item2;
            this.BusinessModel = (int)items.Item1;
            this.BusinessAmount = this.BusinessModel.Equals(0) ? this.Fruit.Price : this.Fruit.Purchased;
            this.Exit = new RelayCommand(this.ExecuteExit);
        }

        public void ExecuteExit()
        {
            General.NavigateBack();
        }
    }
}
