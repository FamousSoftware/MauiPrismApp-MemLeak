using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MauiPrismApp.Views;

namespace MauiPrismApp.ViewModels
{
    public class Page2ViewModel : BindableBase
    {
        public ICommand NavPage1Command { get; }
        public ICommand NavPage1ClearStackCommand { get; }
        public ICommand NavGoBackCommand { get; }

        public Page2ViewModel(INavigationService navigationService)
        {
            NavPage1Command = new DelegateCommand(async () => await navigationService.NavigateAsync(nameof(MainPage)));
            NavPage1ClearStackCommand = new DelegateCommand(async () => await navigationService.NavigateAsync($"/{nameof(MainPage)}"));
            NavGoBackCommand = new DelegateCommand(async () => await navigationService.GoBackAsync());
        }
    }
}
