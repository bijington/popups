using CommunityToolkit.Maui.Views;
using System.ComponentModel;

namespace Popups;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterPopup<TPopupView, TPopupViewModel>(this IServiceCollection services)
        where TPopupView : Popup
        where TPopupViewModel : INotifyPropertyChanged
    {
        PopupService.RegisterPopup<TPopupView, TPopupViewModel>(services);

        return services;
    }
}
