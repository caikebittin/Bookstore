using Bookstore.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Domain.Entities;
public class Book
{
    public int BookId { get; set; }

    [Required(ErrorMessage = "Enter the title of the book")]
    [StringLength(150)]
    public string? Title { get; set; }

    [Required(ErrorMessage = "Enter the name of the book author")]
    [StringLength(200)]
    public string? Author { get; set; }

    [Required(ErrorMessage = "Enter book release date")]
    public DateTime ReleaseDate { get; set; }

    [Required(ErrorMessage = "Enter the Image URL of the book")]
    [StringLength(200)]
    public string? Cover { get; set; }

    [Required]
    [EnumDataType(typeof(Publishing), ErrorMessage = "Select the Publishing")]
    public Publishing Publishing { get; set; }

    [Required]
    [EnumDataType(typeof(Category), ErrorMessage = "Select the Category")]
    public Category Category { get; set; }
    public Book(int bookId, string? title, string? author, DateTime releaseDate,
                string? cover, Publishing publishing, Category category)
    {
        BookId = bookId;
        Title = title;
        Author = author;
        ReleaseDate = releaseDate;
        Cover = cover;
        Publishing = publishing;
        Category = category;
    }
}


