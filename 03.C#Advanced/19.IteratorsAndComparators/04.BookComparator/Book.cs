﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
    {
        public Book(string title, int year, params string[] authors)
        {
            Title = title;
            Year = year;
            Authors = authors.ToList();
        }

        public string Title { get; set; }
        public int Year { get; set; }
        public List<string> Authors { get; set; }

        public int CompareTo([AllowNull] Book other)
        {
            BookComparator bookComparator = new BookComparator();
            return bookComparator.Compare(this, other);
        }

        public override string ToString()
        {
            return $"{Title} - {Year}";
        }
    }
}
