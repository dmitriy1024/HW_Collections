using System;

namespace HW_Collections
{
    enum Genre { Computer, Fantastic }

    class Book
    {
        string _title;
        string _authorSName;
        private Genre _genre;

        public string Title
        {
            get { return _title; }
        }

        public string AuthorSName
        {
            get { return _authorSName; }
        }

        public Genre Genre
        {
            get { return _genre; }
        }

        public Book(string title, string authorSName, Genre genre)
        {
            if (title == null || authorSName == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                _title = title;
                _authorSName = authorSName;
                _genre = genre;
            }
        }

        public override bool Equals(object obj)
        {
            Book book = obj as Book;
            if (obj == null)
            {
                return false;
            }
            else
            {
                return String.Compare(book.Title, _title, true) == 0 &&
                       String.Compare(book.AuthorSName, _authorSName, true) == 0 &&
                       book.Genre == _genre;
            }
        }
    }
}
