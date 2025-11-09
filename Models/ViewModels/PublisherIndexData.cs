using Claudiu_Cojocaru_Lab2.Models;

namespace Claudiu_Cojocaru_Lab2.Models.ViewModels;

public class PublisherIndexData
{
    public IEnumerable<Publisher> Publishers { get; set; }
    public IEnumerable<Book> Books { get; set; }
}
