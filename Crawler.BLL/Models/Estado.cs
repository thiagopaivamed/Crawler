using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Crawler.BLL.Models
{
    public class Estado
    {
        [Key]
        public int EstadoId { get; set; }
        public string Sigla { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<PostTwitter> PostTwitters { get; set; }
    }
}
