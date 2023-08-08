using System;

namespace AvaloniaNavigation.ViewModels;

public class FirstPageViewModel : PageViewModelBase
{
    public string Title => "Welcome to our Wizard-Sample.";
    public string Message => "Press \"Next\" to register yourself.";

    // This is our first page, so we can navigate to the next page in any case
    public override bool CanNavigateNext
    {
        get => true;
        protected set => throw new NotSupportedException();
    }

    // You cannot go back from this page
    public override bool CanNavigatePrevious
    {
        get => false;
        protected set => throw new NotSupportedException();
    }
}