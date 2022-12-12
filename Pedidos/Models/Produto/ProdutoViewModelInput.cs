using System.ComponentModel.DataAnnotations;

namespace Pedidos.Models.Usuario
{
    public class ProdutoViewModelInput
    {
        [Required(ErrorMessage = "Campo Nome do Produto é obrigatório!")]
        public string NomeProduto { get; set; }
        [Required(ErrorMessage = "Campo Nome do Produto é obrigatório!")]
        public decimal Valor { get; set; }

    }
}
