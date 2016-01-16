using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Crawler.Models
{
    public class PostTwitter
    {
        [Key]
        public int PostTwitterId { get; set; }

        public string NomeUsuario { get; set; }

        public string Texto { get; set; }

        public string Data { get; set; }

        [ForeignKey("Estado")]
        public int EstadoId { get; set; }
        [JsonIgnore]
        public virtual Estado Estado { get; set; }

        [ForeignKey("Categoria")]
        public int CategoriaId { get; set; }
        [JsonIgnore]
        public virtual Categoria Categoria { get; set; }
    }
}