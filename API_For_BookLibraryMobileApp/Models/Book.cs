namespace API_For_BookLibraryMobileApp.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public int YearOfPublication { get; set; }
        public string PublisherAddress { get; set; }
        public int NumberOfPages { get; set; }
    }
}
