using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> books;

        public Library(params Book[] books)
        {
            Books = books.ToList();
        }

        public List<Book> Books
        {
            get { return books; }
            set { books = value; }
        }
    }
}
