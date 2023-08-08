using CommunityToolkit.Mvvm.Input;
using AvaloniaNavigation.Navigation;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaNavigation.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly NavigationService _navigationService;
    [ObservableProperty] private INavigation? _currentPage;
    
    public MainWindowViewModel()
    {
        var pages = new INavigation[]
        {
            new FirstPageViewModel(),
            new SecondPageViewModel(),
            new ThirdPageViewModel()
        };
        
        _navigationService = new NavigationService(pages);
        CurrentPage = _navigationService.CurrentPage;
    }

    [RelayCommand]
    private void NavigateNext()
    {
        if (CurrentPage == null  || !CurrentPage.CanNavigateNext) return;
        CurrentPage = _navigationService.NavigateNext();
    }

    [RelayCommand]
    private void NavigatePrevious()
    {
        if (CurrentPage == null || !CurrentPage.CanNavigatePrevious) return;
        CurrentPage = _navigationService.NavigatePrevious();
    }
}