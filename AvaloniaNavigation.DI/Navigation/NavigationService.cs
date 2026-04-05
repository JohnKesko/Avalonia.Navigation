using System.Linq;
using System.Collections.Generic;

namespace AvaloniaNavigation.Navigation;

// Concrete implementation of INavigationService
public class NavigationService
{
    // This list holds the pages that can be navigated to.
    private readonly List<INavigationService?> _pages;

    // Constructor that initializes the navigation service with a list of pages.
    public NavigationService(IEnumerable<INavigationService> pages)
    {
        _pages = new List<INavigationService?>(pages);
        CurrentPage = _pages.FirstOrDefault();
    }

    // This method navigates forward to the next page in the navigation stack.
    // If there is no next page, it returns null.
    public INavigationService? NavigateNext()
    {
        int currentIndex = _pages.IndexOf(CurrentPage);

        if (currentIndex + 1 < _pages.Count)
        {
            CurrentPage = _pages[currentIndex + 1];
        }

        return CurrentPage;
    }

    // This method navigates to the previous page in the navigation stack.
    // If there is no previous page, it returns null.
    public INavigationService? NavigatePrevious()
    {
        var currentIndex = _pages.IndexOf(CurrentPage);
        if (currentIndex - 1 >= 0)
        {
            CurrentPage = _pages[currentIndex - 1];
        }
        return CurrentPage;
    }

    // Prop to hold the current page in the navigation stack.
    public INavigationService? CurrentPage { get; private set; }
}
