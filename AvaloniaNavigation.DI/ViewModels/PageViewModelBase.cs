using AvaloniaNavigation.Navigation;

namespace AvaloniaNavigation.ViewModels;

public abstract class PageViewModelBase : ViewModelBase, INavigationService
{
    public abstract bool CanNavigateNext { get; protected set; }

    public abstract bool CanNavigatePrevious { get; protected set; }


    public virtual void NavigateNext()
    {
        throw new System.NotImplementedException("Navigation to the next page is not implemented.");
    }

    public virtual void NavigatePrevious()
    {
        throw new System.NotImplementedException("Navigation to the previous page is not implemented.");
    }
}
