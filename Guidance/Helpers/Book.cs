using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SinasApi.Helpers
{
    public class Book
    {
        public String Initial { get; set; }

        public int ISBN { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}