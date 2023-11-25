using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookstore.model
{
    [Table("Book")]
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Desctipion { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }


        public Book(int id, string title, string desctipion, string author, DateTime publishDate)
        {
            Id = id;
            Title = title;
            Desctipion = desctipion;
            Author = author;
            PublishDate = publishDate;
        }
    }
}
