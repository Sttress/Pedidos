using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pedidos.Bussines.Entities
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Nome do produto é obrigatório!")]
        [StringLength(20, ErrorMessage = "O Nome do produto deve ter no máximo 20 caracteres")]
        public string NomeProduto { get; set; }
        [Required(ErrorMessage = "Campo Valor é obrigatório!")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Valor { get; set; }
        public ICollection<ItensPedido>? ItemPedido { get; set; }
    }
}
