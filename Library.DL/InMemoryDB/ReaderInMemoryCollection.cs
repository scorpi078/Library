using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniLibrary.Models.DTO;

namespace Library.DL.InMemoryDB
{
   public static class ReaderInMemoryCollection
    {
        public static List<Reader> ReadersDb = new List<Reader>()
        {
            new Reader()
            {
                Id = 1,
                Name = "Reader1",
                PhoneNumber = 0871234567
            },
            new Reader()
            {
                Id = 2,
                Name = "Reader2" , 
                PhoneNumber = 0887654321
            },
            new Reader()
            {
                Id = 3,
                Name = "Reader3",
                PhoneNumber = 0876541237
            }
        };

    }
}
