using System;

namespace AvaloniaNavigation.ViewModels;

public class ThirdPageViewModel : PageViewModelBase
{
    // This is the last page, so we cannot navigate next in our sample.
    public override bool CanNavigateNext
    {
        get => false;
        protected set => throw new NotSupportedException("This is the last page, so we should not be able to navigate to the next page.");
    }

    // We navigate back form this page in any case
    public override bool CanNavigatePrevious
    {
        get => true;
        protected set => throw new NotSupportedException("This is the last page, so we should always be able to navigate back to the previous page.");
    }
}
