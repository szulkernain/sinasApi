using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Guidance.Helpers
{
    public class DBHelper
    {
        private string connString;

        public DBHelper()
        {
            connString = "Data Source=sinasserver.database.windows.net;Initial Catalog=TestDB;User ID=szulkernain;Password=Rahi4Rahi";
        }

        public List<Book> GetBooks()
        {
            List<Book> listBooks = new List<Book>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("select * from Books", conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Book book = new Book();
                                book.ISBN = reader.GetInt32(reader.GetOrdinal("ISBN"));
                                book.Title = reader.GetString(reader.GetOrdinal("Title"));
                                book.Description = reader.GetString(reader.GetOrdinal("Description"));

                                listBooks.Add(book);
                            }
                        }
                    }
                }
            }

            return listBooks;
        }
    }
}