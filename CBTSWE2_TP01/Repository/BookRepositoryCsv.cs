using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TP01.Interface;
using TP01.Models;

// Vinicius do Nascimento Ayres (CB3025675)
// Matheus Leandro Terra Luciano (CB3024881)

namespace TP01.Repository
{
    public class BookRepositoryCsv : IBookRepository
    {
        private static readonly string nameDatabaseCSV = "books.csv";

        private ICollection<Book> _books;

        public BookRepositoryCsv()
        {
            this.loadBooksCsv();
        }

        public ICollection<Book> getAll()
        {
            return this._books.ToList();
        }

        public void add(Book book)
        {
            using (var file = File.AppendText(BookRepositoryCsv.nameDatabaseCSV))
            {
                var authorsJson = JsonConvert.SerializeObject(book.getAuthors());
                file.WriteLine($"{book.getName()};{authorsJson};{book.getPrice()};{book.getQty()}");
            }
        }

        private void loadBooksCsv() {
            var books = new List<Book>();

            if (!File.Exists(BookRepositoryCsv.nameDatabaseCSV))
            {
                using (var createFile = File.CreateText(BookRepositoryCsv.nameDatabaseCSV)) {};
            }

            using (var file = File.OpenText(BookRepositoryCsv.nameDatabaseCSV))
            {
                while (!file.EndOfStream)
                {
                    var textBook = file.ReadLine();
                    if (string.IsNullOrEmpty(textBook))
                    {
                        continue;
                    }
                    var infosBook = textBook.Split(';');

                    var authors = convertAuthor(infosBook[1]);

                    var book = new Book(
                        infosBook[0],
                        authors, 
                        Convert.ToDouble(infosBook[2]), 
                        Convert.ToInt32(infosBook[3])
                    );

                    books.Add(book);
                }
            }

            this._books = books;
        }

        private Author[] convertAuthor(string authorsJson)
        {
            var authors = JsonConvert.DeserializeObject<Author[]>(authorsJson);
            return authors;
        }

    }
}
