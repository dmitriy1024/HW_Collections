using System;
using System.Collections.Specialized;

namespace HW_Collections
{
    class Student
    {
        private string _name;
        private Genre _preferedGenre;

        public string Name
        {
            get { return _name; }
        }

        public Genre PreferedGenre
        {
            get { return _preferedGenre; }
        }

        public Student(string name, Genre prefGenre, Library lib)
        {
            if (name == null || lib == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                _name = name;
                _preferedGenre = prefGenre;

                lib.CollectionChanged += LibChanged;
            }
        }

        private void LibChanged(object o, NotifyCollectionChangedEventArgs args)
        {
            if(args.Action == NotifyCollectionChangedAction.Add)
            {
                if (((Book)args.NewItems[0]).Genre == Genre.Computer && _preferedGenre == Genre.Computer)
                {
                    Console.WriteLine("{0}: I'm going to go to the library. Trere is a new computer book!", _name);
                }

                if (((Book)args.NewItems[0]).Genre == Genre.Fantastic && _preferedGenre == Genre.Fantastic)
                {
                    Console.WriteLine("{0}: I want a home delivery of a new fantastic book!", _name);
                }
            }
            if(args.Action == NotifyCollectionChangedAction.Remove)
            {
                if (_preferedGenre == Genre.Fantastic && ((Book)args.OldItems[0]).Genre != Genre.Fantastic)
                {
                    Console.WriteLine("{0}: I'm not going to read \"{1}\"", _name, ((Book)args.OldItems[0]).Title);
                }
            }
        }
    }
}
