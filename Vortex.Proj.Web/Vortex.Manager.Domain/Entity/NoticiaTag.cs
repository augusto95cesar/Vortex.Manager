using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vortex.Manager.Domain.Entity
{
    public class NoticiaTag
    {
        [Key]
        public int Id { get; set; }
        public int NoticiaId { get; set; }
        public int TagId { get; set; }

        //Relacionamento
        [ForeignKey("TagId")]
        public required virtual Tag Tag { get; set; }

        [ForeignKey("NoticiaId")]
        public required virtual Noticia Noticia { get; set; }
    }
}
