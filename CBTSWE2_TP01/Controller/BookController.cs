using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP01.Interface;
using TP01.Models;
using TP01.Repository;

// Vinicius do Nascimento Ayres (CB3025675)
// Matheus Leandro Terra Luciano (CB3024881)

namespace TP01.Controller
{
    public class BookController
    {
        private readonly IBookRepository _bookRepository;
        public BookController() {
            this._bookRepository = new BookRepositoryCsv();
            this.cargaInicial();
        }

        private void cargaInicial()
        {
            var books = this._bookRepository.getAll();

            if (books.Count <= 0)
            {
                Author[] authors = {
                    new Author("Stephen King", "stephenking@example.com", 'm'),
                    new Author("Agatha Christie", "agathachristie@example.com", 'f')
                };

                Book book = new Book("The Shining", authors, 19.99, 250);

                this._bookRepository.add(book);
            }
        }

        public void DesmostrarMetodos()
        {
            Author author1 = new Author("J.K. Rowling", "jkrowling@example.com", 'f');
            Author author2 = new Author("George R.R. Martin", "grrmartin@example.com", 'm');

            Author[] authors = { author1, author2 };

            Book book = new Book("A Song of Ice and Fire", authors, 29.99, 100);

            Console.WriteLine("Nome do livro: " + book.getName());
            Console.WriteLine("Autores: " + book.getAuthorNames());
            Console.WriteLine("Preco do livro: " + book.getPrice());
            Console.WriteLine("Quantidade disponivel: " + book.getQty());

            book.setPrice(24.99);
            book.setQty(50);

            Console.WriteLine("Novo preco do livro: " + book.getPrice());
            Console.WriteLine("Nova quantidade disponivel: " + book.getQty());

            Console.WriteLine(book.ToString());
        }

        public Task GetNameBook(HttpContext context) {
            var book = _bookRepository.getAll().FirstOrDefault();
            return context.Response.WriteAsync(book.getName());
        }
        public Task GetBook(HttpContext context) {
            var book = _bookRepository.getAll().FirstOrDefault();
            return context.Response.WriteAsync(book.ToString());
        }
        public Task GetAuthorsBook(HttpContext context) {
            var book = _bookRepository.getAll().FirstOrDefault();
            return context.Response.WriteAsync(book.getAuthorNames());
        }
        public Task GetHtmlBook(HttpContext context) {
            var book = _bookRepository.getAll().FirstOrDefault();
            var authors = book.getAuthors().Select(a => $"<li>{a.Name}</li>");
            return context.Response.WriteAsync(@$"
                <h1>{book.getName()}</h1>    
                <strong>Autores:</strong>
                <ol>
                    {string.Join("", authors)}
                </ol>
            ");
        }
    }
}
