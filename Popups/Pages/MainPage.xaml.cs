using Popups.ViewModels;

namespace Popups.Pages;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageViewModel mainPageViewModel)
    {
        InitializeComponent();

        BindingContext = mainPageViewModel;
    }
}
