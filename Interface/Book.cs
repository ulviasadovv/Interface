using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public class Book : IEntity
    {
        private static int _nextId = 1;
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string AuthorName { get; private set; }
        public int PageCount { get; private set; }
        public bool IsDeleted { get; set; } = false;

        public Book(string name, string authorName, int pageCount)
        {
            Id = _nextId++;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            AuthorName = authorName ?? throw new ArgumentNullException(nameof(authorName));
            PageCount = pageCount > 0 ? pageCount : throw new ArgumentException("PageCount must be greater than zero");
        }

        public void ShowInfo()
        {
            Console.WriteLine($"ID: {Id}, Name: {Name}, Author: {AuthorName}, PageCount: {PageCount}, IsDeleted: {IsDeleted}");
        }

        public static bool operator >(Book a, Book b) => a.PageCount > b.PageCount;
        public static bool operator <(Book a, Book b) => a.PageCount < b.PageCount;
    }
}
