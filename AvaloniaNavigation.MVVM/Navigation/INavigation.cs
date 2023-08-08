namespace AvaloniaNavigation.Navigation;

public interface INavigation
{
    bool CanNavigateNext { get; }
    bool CanNavigatePrevious { get; }
    void NavigateNext();
    void NavigatePrevious();
}