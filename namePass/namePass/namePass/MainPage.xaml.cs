using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace namePass
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }


        void ButtonSend_Clicked(System.Object sender, System.EventArgs e)
        {
            var a = loginName.Text;
        }

    }
}

