using System.Linq;
using System.Collections.Generic;

namespace AvaloniaNavigation.Navigation;

public class NavigationService
{
    private readonly List<INavigation?> _pages;

    public NavigationService(IEnumerable<INavigation> pages)
    {
        _pages = new List<INavigation?>(pages);
        CurrentPage = _pages.FirstOrDefault();
    }
    
    public INavigation NavigateNext()
    {
        var currentIndex = _pages.IndexOf(CurrentPage);
        
        if (currentIndex + 1 < _pages.Count)
        {
            CurrentPage = _pages[currentIndex + 1];
        }

        return CurrentPage;
    }

    public INavigation NavigatePrevious()
    {
        var currentIndex = _pages.IndexOf(CurrentPage);
        if (currentIndex - 1 >= 0)
        {
            CurrentPage = _pages[currentIndex - 1];
        }
        return CurrentPage;
    }

    public INavigation? CurrentPage { get; private set; }
}
