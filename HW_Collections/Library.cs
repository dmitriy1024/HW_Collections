using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Threading;

namespace HW_Collections
{
    class Library
    {
        private ObservableCollection<Book> _books = new ObservableCollection<Book>();

        public event NotifyCollectionChangedEventHandler CollectionChanged
        {
            add
            {
                lock(_books)
                {
                    _books.CollectionChanged += value;
                }
            }
            remove
            {   
                lock(_books)
                {
                    _books.CollectionChanged -= value;
                }                
            }
        }

        public void AddHandler(NotifyCollectionChangedEventHandler handler)
        {
            if(handler != null)
            {
                _books.CollectionChanged += handler;
            }
        }

        public void RemoveHandler(NotifyCollectionChangedEventHandler handler)
        {
            if (handler != null)
            {
                _books.CollectionChanged -= handler;
            }
        }

        public void AddBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                _books.Add(book);
            }
        }

        public Book GetBook(string title)
        {
            if (title == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                Book findedBook = null;
                foreach (var item in _books)
                {
                    if (String.Compare(item.Title, title, true) == 0)
                    {
                        findedBook = item;
                    }
                }

                if (findedBook != null)
                {
                    _books.Remove(findedBook);
                }

                return findedBook;
            }
        }
    }
}
