namespace FetchNASAAPIApp.DTOs
{
    public class PictureDTO
    {
        public string? Copyright { get; set; }
        public DateOnly Date { get; set; }
        public string? Explanation { get; set; }
        public string? Hdurl { get; set; }
        public string? Media_type { get; set; }
        public string? Service_version { get; set; }
        public string Title { get; set; }
        public string? Url { get; set; }
    }
}
