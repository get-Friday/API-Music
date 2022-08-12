namespace API_Music.ViewModels
{
    public class FailedReturnViewModel
    {
        public string Failure { get; set; }
        public FailedReturnViewModel(string failure)
        {
            Failure = failure;
        }
    }
}
