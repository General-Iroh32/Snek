using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Snek.Graph_Creation.ViewModel;

public sealed class Create_Graph_ViewModel : ObservableObject
{
    private object _currentView;

    public Create_Graph_ViewModel(
        HomeViewModel homeViewModel,
        UeberUnsViewModel ueberUnsViewModel,
        PosViewModel posViewModel)
    {
        HomeViewModel = homeViewModel;
        UeberUnsViewModel = ueberUnsViewModel;
        PosViewModel = posViewModel;
        _currentView = HomeViewModel;

        HomeViewCommand = new RelayCommand(() => CurrentView = HomeViewModel);
        UeberUnsCommand = new RelayCommand(() => CurrentView = UeberUnsViewModel);
        PosCommand = new RelayCommand(() => CurrentView = PosViewModel);
    }

    public HomeViewModel HomeViewModel { get; }

    public UeberUnsViewModel UeberUnsViewModel { get; }

    public PosViewModel PosViewModel { get; }

    public object CurrentView
    {
        get => _currentView;
        private set => SetProperty(ref _currentView, value);
    }

    public IRelayCommand HomeViewCommand { get; }

    public IRelayCommand UeberUnsCommand { get; }

    public IRelayCommand PosCommand { get; }
}
