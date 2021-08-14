using Snek.Graph_Creation.Core;
using Snek.Graph_Creation.View;

namespace Snek.Graph_Creation.ViewModel
{
    class Create_Graph_ViewModel : ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand EinstellungenViewCommand { get; set; }
        public RelayCommand UeberUnsCommand { get; set; }
        public RelayCommand PosCommand { get; set; }

        public object _currentView;

        public EinstellungViewModel EinstellungViewModel { get; set; }
        public HomeViewModel HomeViewModel { get; set; }
        public UeberUnsViewModel UeberUnsViewModel { get; set; }
        public PosViewModel PosViewModel { get; set; }
        public object CurrentView { get { return _currentView; } set { _currentView = value; OnPropertyChanged(); } }

        public Create_Graph_ViewModel()
        {
            EinstellungViewModel = new EinstellungViewModel();
            HomeViewModel = new HomeViewModel();
            UeberUnsViewModel = new UeberUnsViewModel();
            PosViewModel = new PosViewModel();

            HomeViewCommand = new RelayCommand(a => { CurrentView = HomeViewModel; });
            EinstellungenViewCommand = new RelayCommand(a => { CurrentView = EinstellungenViewCommand; });
            UeberUnsCommand = new RelayCommand(a => { CurrentView = UeberUnsViewModel; });
            PosCommand= new RelayCommand(a => { CurrentView = PosViewModel; });
            /* PosCommand = new RelayCommand(a => { CurrentView = PosCommand; });
            *neue View in view ordner 
             *in app.xaml adden 
             */
            CurrentView = HomeViewModel;
        }
    }
}
