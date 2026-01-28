using Bookapi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Bookapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private static readonly string filePath = "Data/book.json";

        private static List<Book> LoadData()
        {
            if (!System.IO.File.Exists(filePath))
            {
                System.IO.Directory.CreateDirectory("Data");
                System.IO.File.WriteAllText(filePath, "[]");
            }

            var json = System.IO.File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Book>>(json) ?? new();
        }

        private static void SaveData(List<Book> data)
        {
            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(filePath, json);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBook()
        {
            return Ok(LoadData());
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBookById(int id)
        {
            var data = LoadData();
            var book = data.FirstOrDefault(b => b.Id == id);

            if (book == null)
                return NotFound("Book tidak ditemukan");

            return Ok(book);
        }


        [HttpPost]
        public ActionResult<Book> PostMahasiswa(Book book)
        {
            var data = LoadData();

            book.Id = data.Count == 0 ? 1 : data.Max(b => b.Id) + 1;

            data.Add(book);
            SaveData(data);

            return CreatedAtAction(
                nameof(GetBookById),
                new { id = book.Id },
                book
            );
        }

        [HttpPut("{id}")]
        public IActionResult PutBook(int id, Book book)
        {
            var data = LoadData();
            var index = data.FindIndex(b => b.Id == id);

            if (index == -1)
                return NotFound("Buku tidak ditemukan");

            book.Id = id;
            data[index] = book;
            SaveData(data);

            return Ok(new
            {
                message = "Data buku berhasil diperbarui",
                data = book
            });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var data = LoadData();
            var book = data.FirstOrDefault(b => b.Id == id);

            if (book == null)
                return NotFound("Buku tidak ditemukan");

            data.Remove(book);
            SaveData(data);

            return Ok(new
            {
                message = "Data buku berhasil dihapus",
                data = book
            });
        }
    }
    }
