using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Vinicius do Nascimento Ayres (CB3025675)

namespace TP01.Models
{
    public class Book
    {
        private string name { get; set; }
        private Author[] authors { get; set; }
        private double price { get; set; }
        private int qty { get; set; }

        public Book(string name, Author[] authors, double price)
        {
            this.name = name;
            this.authors = authors;
            this.price = price;
            this.qty = 0;
        }

        public Book(string name, Author[] authors, double price, int qty)
        {
            this.name = name;
            this.authors = authors;
            this.price = price;
            this.qty = qty;
        }

        public string getName() => this.name;
        public Author[] getAuthors() => this.authors;
        public double getPrice() => this.price;
        public int getQty() => this.qty;

        public void setPrice(double price) => this.price = price;
        public void setQty(int qty) => this.qty = qty;
        public string getAuthorNames()
        {
            var authorNames = this.authors.Select(a => a.Name).ToArray();
            return string.Join(", ", authorNames);
        }

        public override string ToString()
        {
            var authors = string.Join(", ", this.authors.Select(a => a.ToString()));
            return $"Book[name={this.name}, authors={{{authors}}}, price={this.price}, qty={this.qty}]";
        }
    }
}
