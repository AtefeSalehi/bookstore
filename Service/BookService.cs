using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entities;
using Domain.Interfaces;

namespace Service
{
    public class BookService
    {
        IBookService bookservice;
        public BookService(IBookService bookservice)
        {
            this.bookservice = bookservice;
        }
        public Book FindBook(int id)
        {
            return bookservice.SelectBook().ToList().Find(BOOK => BOOK.id == id);
        }
        
    }
}
