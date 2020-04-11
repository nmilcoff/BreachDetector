using System.ComponentModel;
using Xamarin.Forms;
using TestApp.ViewModels;

namespace TestApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ChecksPage : ContentPage
    {
        ChecksViewModel viewModel;

        public ChecksPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ChecksViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.ExecuteChecksCommand.Execute(null);
        }
    }
}