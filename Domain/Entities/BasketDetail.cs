using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class BasketDetail
    {
        public int id { get; set; }
        public Book bookId { get; set; }
        public decimal price { get; set; }
        public Basket basketId { get; set; }
        public int count { get; set; }


    }
}
