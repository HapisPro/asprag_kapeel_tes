using System.Text.Json.Serialization;

namespace Bookapi.Models
{
    public class Book
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("judul")]
        public string Judul { get; set; }

        [JsonPropertyName("penulis")]
        public string Penulis { get; set; }

        [JsonPropertyName("tahunTerbit")]
        public string TahunTerbit { get; set; }

        [JsonPropertyName("tersedia")]
        public bool Tersedia { get; set; }
    }
}
