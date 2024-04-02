using Bookstore.Domain.Entities;
using Bookstore.Domain.Interface;
using Bookstore.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrastructure.Repositories;
public class BookRepository : IBookRepository
{
    private readonly ApplicationDbContext _context;
    public BookRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Book> AddBook(Book book)
    {
        if (_context is not null && book is not null && _context.Books is not null)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }
        else
        {
            throw new InvalidOperationException("Invalid data.");
        }
    }

    public async Task DeleteBook(int id)
    {
        var book = await GetBook(id);
        
        if (book is not null)
        {
            _context.Books?.Remove(book);
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new InvalidOperationException("Invalid data.");
        }
    }

    public async Task<Book?> GetBook(int id)
    {
        var book = await _context.Books.FirstOrDefaultAsync(b => b.BookId == id);

        if(book is null)
            throw new InvalidOperationException($"Book {id} is not found");

        return book;
    }

    public async Task<IEnumerable<Book>> GetBooks()
    {
        if (_context is not null && _context.Books is not null)
        {
            var books = await _context.Books.ToListAsync();
            return books;
        }
        else
        {
            return new List<Book>();
        }
    }

    public async Task UpdateBook(Book book)
    {
        if (book is not null)
        {
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new ArgumentNullException("Invalid data.");
        }
    }
}
