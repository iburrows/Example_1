namespace Example_1.ViewModel
{
    public class HistoryVM
    {

        public string ButtonId { get; set; }
        public string State { get; set; }
        public string TimeStamp { get; set; }
        public HistoryVM(string buttonId, string state, string timeStamp)
        {
            ButtonId = buttonId;
            State = state;
            TimeStamp = timeStamp;
        }

    }
}