namespace AvaloniaNavigation.Navigation;

public interface INavigationService
{
    bool CanNavigateNext { get; }
    bool CanNavigatePrevious { get; }
    void NavigateNext();
    void NavigatePrevious();
}