using CommunityToolkit.Maui.Views;
using Popups.ViewModels;

namespace Popups.Views;

public partial class ConfirmationPopupView
{
	public ConfirmationPopupView(ConfirmationPopupViewModel confirmationPopupViewModel)
	{
		InitializeComponent();

		BindingContext = confirmationPopupViewModel;
	}
}
