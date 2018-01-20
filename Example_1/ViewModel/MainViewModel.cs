using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;

namespace Example_1.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        public RelayCommand ListenButton { get; set; }
        public RelayCommand ConnectButton { get; set; }
        public RelayCommand Toggle_1 { get; set; }
        public RelayCommand Toggle_2 { get; set; }
        public RelayCommand Toggle_3 { get; set; }
        public RelayCommand Toggle_4 { get; set; }
        public ObservableCollection<HistoryVM> HistoryList { get; set; }

        public MainViewModel()
        {
            ListenButton = new RelayCommand(()=> { });
            ConnectButton = new RelayCommand(() => { });
            Toggle_1 = new RelayCommand(() => { });
            Toggle_2= new RelayCommand(() => { });
            Toggle_3 = new RelayCommand(() => { });
            Toggle_4 = new RelayCommand(() => { });
        }
    }
}