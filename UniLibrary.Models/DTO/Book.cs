using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniLibrary.Models.Enums;

namespace UniLibrary.Models.DTO
{
   public class Book
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Category Category { get; set; }

        public string AuthorName { get; set; }

       
    }
}
