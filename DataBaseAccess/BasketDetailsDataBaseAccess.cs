using Domain.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseAccess
{
    public class BasketDetailsDataBaseAccess
    {
        public void AddBasketDetails(int basketid, Book book, int count)
        {
            using (DataBaseAccess database = new DataBaseAccess())
            {
                SqlCommand cmd = new SqlCommand($"insert into BasketDetails(BookID,BasketID,Count) values('{book.id}','{basketid}','{count}')", database.conn);
                cmd.ExecuteNonQuery();
            }

        }
        public IEnumerable<BasketDetail> GetAllBasket(User user)
        {

            List<BasketDetail> basketdetail = new List<BasketDetail>();
            using (DataBaseAccess database = new DataBaseAccess())
            {
                var userdatabaseaccess = new UserDataBaseAccess();
                SqlCommand cmd = new SqlCommand($"select Basket.UserID,BookID,Books.Price,BasketID,Count from BasketDetails join Basket on Basket.ID = BasketDetails.BookID where Basket.UserID ={user.id} ", database.conn);
                var Reader = cmd.ExecuteReader();
                while (Reader.Read())
                {
                    basketdetail.Add(new BasketDetail()
                    {

                    });

                }
            }
            return basketdetail;
        }
    }
   
}
