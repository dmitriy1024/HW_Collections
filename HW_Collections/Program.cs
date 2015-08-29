using System;

namespace HW_Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            var lib = new Library();

            Student studentf = new Student("Vasya", Genre.Fantastic, lib);
            Student studentc = new Student("Petya", Genre.Computer, lib);

            lib.AddBook(new Book("CLR via C#", "Jeffrey Richter", Genre.Computer));
            lib.AddBook(new Book("C# in a nutshell", "Joseph Albahari", Genre.Computer));
            lib.AddBook(new Book("Win10", "Andy Rathbone", Genre.Computer));
            lib.AddBook(new Book("The Time Machine", "H. G. Wells", Genre.Fantastic));
            lib.AddBook(new Book("The Lord of the Rings", "J. R. R. Tolkien", Genre.Fantastic));

            lib.GetBook("C# in a nutshell");

            Console.ReadKey();
        }
    }
}
