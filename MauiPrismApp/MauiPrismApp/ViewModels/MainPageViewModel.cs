using MauiPrismApp.Views;
using System.Windows.Input;

namespace MauiPrismApp.ViewModels;

public class MainPageViewModel : BindableBase
{
    private ISemanticScreenReader _screenReader { get; }
    private int _count;

    public ICommand NavPage2Command { get; }
    public ICommand CollectGarbageCommand { get; }

    public string Title => "Main Page";

    private string _text = "Click me";

    public MainPageViewModel(ISemanticScreenReader screenReader, INavigationService navigationService, IPageDialogService pageDialogService)
    {
        _screenReader = screenReader;
        CountCommand = new DelegateCommand(OnCountCommandExecuted);
        NavPage2Command = new DelegateCommand(async () => await navigationService.NavigateAsync(nameof(Page2)));
        CollectGarbageCommand = new DelegateCommand(async () => {
            GC.Collect();
            await pageDialogService.DisplayAlertAsync("Alert", "GC.Collect() called.", "OK");
            });
    }

    public string Text
    {
        get => _text;
        set => SetProperty(ref _text, value);
    }

    public DelegateCommand CountCommand { get; }

    private void OnCountCommandExecuted()
    {
        _count++;
        if (_count == 1)
            Text = "Clicked 1 time";
        else if (_count > 1)
            Text = $"Clicked {_count} times";

        _screenReader.Announce(Text);
    }
}
