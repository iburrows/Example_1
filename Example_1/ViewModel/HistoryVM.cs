namespace Example_1.ViewModel
{
    public class HistoryVM
    {

        public string ButtonId { get; set; }
        public bool State { get; set; }
        public string TimeStamp { get; set; }
        public string Color { get; set; }
        public HistoryVM(string buttonId, bool state, string timeStamp)
        {
            ButtonId = buttonId;
            
            TimeStamp = timeStamp;

            if (state)
            {
                Color = "Green";
            }
            else
            {
                Color = "Orange";
            }
        }

    }
}