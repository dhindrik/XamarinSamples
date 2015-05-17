using Drivis.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Drivis.XForms.Views
{
    public partial class MainView : ContentPage
    {
        private bool _isInitialized;

        public MainViewModel ViewModel{
            get { return (MainViewModel)BindingContext; }
        }

        public MainView(MainViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            if(!_isInitialized)
            {              
                _isInitialized = true;
            }
        }
    }
}
