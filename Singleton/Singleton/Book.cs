using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Singleton
{
    public class Book
    {
        public string Judul { get; set; } 

        public string Penulis { get; set; }

        public Book(string judul, string penulis)
        {
            this.Judul = judul;
            this.Penulis = penulis;
        }
    }
}
