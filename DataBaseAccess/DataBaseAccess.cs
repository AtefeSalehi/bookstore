using Microsoft.Data.SqlClient;
using System;
using System.Data;
using Domain.Interfaces;


namespace DataBaseAccess
{
    public class DataBaseAccess: IDisposable
    {
       public IDataBaseService db;
        public SqlConnection conn;

        public DataBaseAccess()
        {
        }

        public DataBaseAccess(IDataBaseService db)
        {
            this.db = db;
        }
        public void DataBaseConnection()
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=BookStore; Trusted_Connection=True;TrustServerCertificate=True");
                conn.Open();
                //SqlCommand cmd = new SqlCommand("insert into Books(Name,Price)values('Doekta',120000)", conn);
                //cmd.ExecuteNonQuery();
                //Console.WriteLine("Inserting Data Successfully");
                //conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Occre while creating table:" + e.Message + "\t" + e.GetType());
            }
        }
        public void Dispose()
        {
            conn.Close();
        }
    }
}
