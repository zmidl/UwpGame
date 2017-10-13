using UwpGame.ViewModels;
using Windows.UI.Xaml.Controls;

namespace UwpGame.Views
{
    public sealed partial class BusinessView : UserControl
    {
        public BusinessViewModel ViewModel { get; private set; }

        public BusinessView(object param)
        {
            this.ViewModel = new BusinessViewModel(param);
            this.InitializeComponent();
            this.DataContext = this.ViewModel;
        }
    }
}
