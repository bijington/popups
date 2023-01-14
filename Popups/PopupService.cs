using System.ComponentModel;
using CommunityToolkit.Maui.Views;

namespace Popups;

public class PopupService
{
    private readonly IServiceProvider serviceProvider;

    private readonly static IDictionary<Type, Type> viewModelToViewMappings = new Dictionary<Type, Type>();

    public PopupService(IServiceProvider serviceProvider)
	{
        this.serviceProvider = serviceProvider;
    }

    public static void RegisterPopup<TPopupView, TPopupViewModel>(IServiceCollection services)
        where TPopupView : Popup
        where TPopupViewModel : INotifyPropertyChanged
    {
        viewModelToViewMappings.Add(typeof(TPopupViewModel), typeof(TPopupView));

        services.AddTransient(typeof(TPopupView));
        services.AddTransient(typeof(TPopupViewModel));
    }

    public Task<object> ShowPopupAsync<TViewModel>()
    {
        var viewModelType = typeof(TViewModel);

        var viewModel = (TViewModel)this.serviceProvider.GetService<TViewModel>();

        if (viewModel is null)
        {
            throw new InvalidOperationException($"Unable to resolve type {viewModelType} please make sure that you have called RegisterPopup");
        }

        return ShowPopupAsync<TViewModel>(viewModel);
    }

    public Task<object> ShowPopupAsync<TViewModel>(TViewModel viewModel)
    {
        var viewModelType = typeof(TViewModel);

        var view = (Popup)this.serviceProvider.GetRequiredService(viewModelToViewMappings[viewModelType]);

        view.BindingContext = viewModel;

        // TODO: Do we need to provide an override for determine the main page? Or we at least need to verify there is a main page.
        return Application.Current.MainPage.ShowPopupAsync(view);
    }
}
