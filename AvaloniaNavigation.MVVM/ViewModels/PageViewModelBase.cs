using AvaloniaNavigation.Navigation;

namespace AvaloniaNavigation.ViewModels;


public abstract class PageViewModelBase : ViewModelBase, INavigation
{
    public abstract bool CanNavigateNext { get; protected set; }
    
    public abstract bool CanNavigatePrevious { get; protected set; }

    
    public virtual void NavigateNext()
    {
        throw new System.NotImplementedException();
    }

    public virtual void NavigatePrevious()
    {
        throw new System.NotImplementedException();
    }
}