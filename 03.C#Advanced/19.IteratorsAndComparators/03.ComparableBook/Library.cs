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
            this.Books.Sort();
        }

        public List<Book> Books
        {
            get { return books; }
            set { books = value; }
        }


        public IEnumerator<Book> GetEnumerator()
        {
            for (int i = 0; i < books.Count; i++)
            {
                yield return books[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator(); 
    }
}
