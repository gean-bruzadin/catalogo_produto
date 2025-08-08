using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace catalogo_produto.Models
{
    public class Comentario
    {
        [Key]
        public int Id_comentario {  get; set; }
        public string Texto_comentario { get; set; }
        public DateTime Data_comentario { get; set; }

        public int Id_usuario { get; set; }
        [ForeignKey("Id_usuario")]
        public Usuario usuario { get; set; }

        public int Id_produto { get; set; }
        [ForeignKey("Id_produto")]
        public Produto produto { get; set; }
    }
}
