using Example_1.Communication;
using Example_1.TheClients;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.ObjectModel;

namespace Example_1.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        public RelayCommand ListenButton { get; set; }
        public RelayCommand ConnectButton { get; set; }
        public RelayCommand<int> ToggleBtnClicked { get; set; }

        public ObservableCollection<HistoryVM> HistoryList { get; set; }


        Server server;
        Client client;

        private const int port = 10100;

        private bool toggle1;

        public bool Toggle1
        {
            get { return toggle1; }
            set { toggle1 = value; RaisePropertyChanged(); }
        }
        private bool toggle2;

        public bool Toggle2
        {
            get { return toggle2; }
            set { toggle2 = value; RaisePropertyChanged(); }
        }
        private bool toggle3;

        public bool Toggle3
        {
            get { return toggle3; }
            set { toggle3 = value; RaisePropertyChanged(); }
        }
        private bool toggle4;

        public bool Toggle4
        {
            get { return toggle4; }
            set { toggle4 = value; RaisePropertyChanged(); }
        }

        private bool isServer = false;

        private string isClient = "Visible";

        public string IsClient
        {
            get { return isClient; }
            set { isClient = value; RaisePropertyChanged(); }
        }

        private bool disable = false;

        public bool Disable
        {
            get { return disable; }
            set { disable = value; }
        }


        public MainViewModel()
        {
            HistoryList = new ObservableCollection<HistoryVM>();

            ListenButton = new RelayCommand(() =>
            {
                server = new Server(port);
                isServer = true;
                Disable = true;
            }
            ,()=> { return !Disable; });

            ConnectButton = new RelayCommand(() =>
            {
                client = new Client(port, UpdateGui);
                IsClient = "Hidden";
                Disable = true;
            }
            , () => { return !Disable; });

            ToggleBtnClicked = new RelayCommand<int>((p) =>
            {
                string date = DateTime.Now.ToLongTimeString();
                
                switch (p)
                {
                    case 1:
                        Toggle1 = !Toggle1;
                        AddToHistory(p.ToString(), date, Toggle1);
                        break;
                    case 2:
                        Toggle2 = !Toggle2;
                        AddToHistory(p.ToString(), date, Toggle2);
                        break;
                    case 3:
                        Toggle3 = !Toggle3;
                        AddToHistory(p.ToString(), date, Toggle3);
                        break;
                    case 4:
                        Toggle4 = !Toggle4;
                        AddToHistory(p.ToString(), date, Toggle4);
                        break;
                }

                if (isServer)
                {
                    server.Send(toggle1.ToString() + "," + toggle2.ToString() + "," + toggle3.ToString() + "," + toggle4.ToString());
                }

            });
        }

        private void AddToHistory(string v, string date, bool toggle)
        {
            HistoryList.Add(new HistoryVM("Button " + v, toggle, date));
        }


        private void UpdateGui(string message)
        {
            App.Current.Dispatcher.Invoke(() =>
            {
                string[] ReceivedMessage = message.Split(',');

                Toggle1 = Convert.ToBoolean(ReceivedMessage[0]);
                Toggle2 = Convert.ToBoolean(ReceivedMessage[1]);
                Toggle3 = Convert.ToBoolean(ReceivedMessage[2]);
                Toggle4 = Convert.ToBoolean(ReceivedMessage[3]);
            });
        }
    }
}