using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniLibrary.Models.Enums;

namespace Library.Models.Requests
{
   public class BookRequest
    {
        public string Name { get; set; }

        public Category Category { get; set; }

        public string AuthorName { get; set; }

    }
}
