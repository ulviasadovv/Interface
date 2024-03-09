using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public class Library : IEntity
    {
        private static int _nextId = 1;
        public int Id { get; private set; }
        private int BookLimit;
        private List<Book> Books;

        public Library(int bookLimit)
        {
            Id = _nextId++;
            BookLimit = bookLimit;
            Books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            if (Books.Count >= BookLimit)
                throw new Utils.Exceptions.CapacityLimitException("Book limit exceeded.");

            if (Books.Any(b => b.Name == book.Name && !b.IsDeleted))
                throw new Utils.Exceptions.AlreadyExistsException($"A book with the naem {book.Name} already exists.");

            Books.Add(book);
        }

        public Book GetBookById(int id)
        {
            var book = Books.FirstOrDefault(b => b.Id == id && !b.IsDeleted);
            if (book == null)
                throw new Utils.Exceptions.NotFoundException($"No book found with ID: {id}");
            return book;
        }
    }
}
