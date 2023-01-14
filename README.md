# Popups

Shows how to display a `Popup` from CommunityToolkit.Maui from inside a view model.

## Registering a popup

```csharp
PopupService.RegisterPopup<ConfirmationPopupView, ConfirmationPopupViewModel>(builder.Services);
```

## Showing a popup

`this.popupService.ShowPopupAsync<ConfirmationPopupViewModel>();`
