using Bookstore.Domain.Entities;

namespace Bookstore.Domain.Interface;
public interface IBookRepository 
{
    Task<IEnumerable<Book>> GetBooks();
    Task<Book?> GetBook(int id);
    Task<Book> AddBook(Book book);
    Task DeleteBook(int id);
    Task UpdateBook(Book book);
}
