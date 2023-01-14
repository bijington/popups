using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Popups.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    private readonly PopupService popupService;

    public MainPageViewModel(PopupService popupService)
    {
        this.popupService = popupService;
    }

    [RelayCommand]
    private void Confirm()
    {
        this.popupService.ShowPopupAsync<ConfirmationPopupViewModel>();
    }
}
