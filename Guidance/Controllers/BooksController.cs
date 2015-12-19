using System.Collections.Generic;
using System.Web.Http;
using SinasApi.Helpers;

namespace SinasApi.Controllers
{
    public class BooksController : ApiController
    {
        // GET: api/Books
        public List<Book> Get()
        {
            return new DBHelper().GetBooks();
        }

        // GET: api/Books/5
        public Book Get(int id)
        {
            return new DBHelper().GetBookDetails(id);
        }

        // POST: api/Books
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Books/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Books/5
        //public void Delete(int id)
        //{
        //}
    }
}
