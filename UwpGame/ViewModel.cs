using System;
using System.ComponentModel;

namespace UwpGame
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        public event EventHandler<object> PageChanged;

        protected virtual void OnPageChanged(object obj)
        {
            this.PageChanged?.Invoke(this, obj);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        public void OnPropertyChanged(string propertyName)
        {
            RaisePropertyChanged(propertyName);
        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (this.PropertyChanged != null) PropertyChanged.Invoke(this, e);
        }
    }
}
