using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Data.SqlClient;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBaseAccess
{
    public class BasketDataBaseAccess : IBasketService
    {
        public int AddBasket(User user)
        {
            int id = 0;
            using (DataBaseAccess database = new DataBaseAccess())
            {

                SqlCommand cmd = new SqlCommand($"insert into Basket(UserID,Date) values('{user.id}','{DateTime.Now}')", database.conn);
                SqlCommand cmd2 = new SqlCommand($"select ID from Basket where Date={DateTime.Now.Date}", database.conn);
                cmd.ExecuteNonQuery();
                var reader = cmd2.ExecuteReader();
                while (reader.Read())
                {
                    id = reader.GetInt32(0);
                }
            }
            return id;
        }
        public IEnumerable<Basket> SelectBasket()
        {
            using (DataBaseAccess database = new DataBaseAccess())
            {
                List<Basket> baskets = new List<Basket>();
                SqlCommand cmd = new SqlCommand("select * from Basket", database.conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    baskets.Add(new Basket()
                    {
                        id = reader.GetInt32(0),
                        userid = reader.GetInt32(1),
                        date = reader.GetDateTime(2),

                    });
                }
                return baskets;

            }


        }
    }
}
