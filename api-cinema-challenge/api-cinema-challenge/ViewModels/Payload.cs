namespace api_cinema_challenge.ViewModels
{
    public class Payload<T> where T : class
    {
        public string status { get; set; } = "Sucsess";
        public T data { get; set; }
    }
}
