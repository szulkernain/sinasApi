using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SinasApi.Helpers
{
    public class DBHelper
    {
        private string connString;

        public DBHelper()
        {
            connString = System.Configuration.ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
        }

        public List<Book> GetBooks()
        {
            List<Book> listBooks = new List<Book>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "dbo.GetBooks";

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Book book = new Book();
                                book.Initial = reader.GetString(reader.GetOrdinal("Initial"));
                                book.ISBN = reader.GetInt32(reader.GetOrdinal("ISBN"));
                                book.Title = reader.GetString(reader.GetOrdinal("Title"));

                                listBooks.Add(book);
                            }
                        }
                    }
                }
            }

            return listBooks;
        }

        public Book GetBookDetails(int isbn)
        {
            Book book = new Book();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "dbo.GetBookDetails";
                    cmd.Parameters.Add("@isbn", System.Data.SqlDbType.Int).Value = isbn;

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            book.ISBN = isbn;
                            book.Title = reader.GetString(reader.GetOrdinal("Title"));
                            book.Description = reader.GetString(reader.GetOrdinal("Description"));
                        }
                    }
                }
            }

            return book;
        }
    }
}