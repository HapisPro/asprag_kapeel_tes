using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public sealed class HelperSingleton
    {
        
        private List<Book>? _buku;
        private static HelperSingleton _instance;

        private HelperSingleton() {
            _buku = new List<Book>();
        }

        public static HelperSingleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new HelperSingleton();
            }
            return _instance;
        }

        public void addBuku(Book buku)
        {
            _buku.Add(buku);
        }

        public void print()
        {
            if (_buku.Count > 0)
            {
                foreach(var item in _buku)
                {
                    Console.WriteLine(item.Judul + "" + item.Penulis);
                } 
            } else
            {
                Console.WriteLine("Tidak ada buku");
            }
        }
    }
}
