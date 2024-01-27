namespace FetchNASAAPIApp.Models
{
    public class NasaApiRequestParams
    {
        public DateOnly Date { get;set;}
        public DateOnly StartDate { get;set;}
        public DateOnly EndDate { get;set;}
        public int Count { get;set;}
        public bool Thumbs { get;set;}
        public string ApiKey { get; set; } = "DEMO_KEY";
    }
}
