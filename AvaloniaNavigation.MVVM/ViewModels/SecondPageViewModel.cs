using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaNavigation.ViewModels;

public partial class SecondPageViewModel : PageViewModelBase
{
    [Required]
    [EmailAddress]
    [ObservableProperty] 
    private string? _mailAddress;
    
    [Required]
    [ObservableProperty]
    private string? _password;
    
    private bool _canNavigateNext;
    private bool _canNavigatePrevious;
    
    public override bool CanNavigateNext
    {
        get => _canNavigateNext;
        protected set => SetProperty(ref _canNavigateNext, value);
    }
    
    public override bool CanNavigatePrevious
    {
        get => true;
        protected set => SetProperty(ref _canNavigatePrevious, value);
    }
    
    public SecondPageViewModel()
    {
        // Subscribe to PropertyChanged event to check whether Email & Password is set correct.
        // When validation is done, we can navigate to the next page since 'CanNavigateNext' will be 'true'.
        PropertyChanged += OnPropertiesChanged;
    }
    
    private void OnPropertiesChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName is nameof(MailAddress) or nameof(Password))
        {
            UpdateCanNavigateNext();
        }
    }
    
    private void UpdateCanNavigateNext()
    {
        CanNavigateNext = !string.IsNullOrEmpty(MailAddress) && MailAddress.Contains("@") && !string.IsNullOrEmpty(Password);
    }
}

