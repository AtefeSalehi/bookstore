using Domain.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Book = Domain.Entities.Book;

namespace DataBaseAccess
{
    public class BookDataBaseAccess:IBookService
    {
      
        public IEnumerable<Book> SelectBook()
        {
            using (DataBaseAccess database = new DataBaseAccess())
            {
                List<Book> books = new List<Book>();
                SqlCommand cmd = new SqlCommand("select * from Book", database.conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    books.Add(new Book()
                    {
                        name = reader.GetString(0),
                        price = reader.GetDecimal(1)

                    });
                }
                return books;
            }

        }
        
    }
}
