using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Crawler.Models
{
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }
        public string Nome { get; set; }

        [JsonIgnore]
        public virtual ICollection<PostTwitter> PostTwitters  { get; set; }
    }
}