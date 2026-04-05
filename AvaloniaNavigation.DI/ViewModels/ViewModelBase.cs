using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaNavigation.ViewModels;

// Root ViewModel so all view models can inherit Observable from Community Toolkit
// Think of it as a base class for all view models.

// ViewModelBase ( ObservableValidator )
// ├── PageViewModelBase ( INavigationService )
// │   ├── FirstPageViewModel ( Can use all properties and methods from ViewModelBase and PageViewModelBase )
// │   ├── SecondPageViewModel ( Same as above )
// │   └── ThirdPageViewModel ( Same as above )

public class ViewModelBase : ObservableValidator
{
}
