using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Claudiu_Cojocaru_Lab2.Models
{
    public class Book
    {
        public int ID { get; set; }
        [Display(Name = "Book Title")]
        public string Title { get; set; } = string.Empty;
        public int? AuthorID { get; set; }
        public Author? Author { get; set; }

        [Column(TypeName = "REAL")]
        public double Price { get; set; }
        public DateTime PublishingDate { get; set; }

        public int? PublisherID { get; set; }
        public Publisher? Publisher { get; set; } // navigation property
        public ICollection<BookCategory>? BookCategories { get; set; }
    }
}
