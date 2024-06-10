using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace namePass
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }

            return false;
        }

        // text and visibility of status label
        private string statusLabelText;

        public string StatusLabelText { get => statusLabelText; set => SetProperty(ref statusLabelText, value); }

        private bool loginStatusVisible;

        public bool LoginStatusVisible { get => loginStatusVisible; set => SetProperty(ref loginStatusVisible, value); }

    }
}


