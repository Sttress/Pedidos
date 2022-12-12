namespace Pedidos.Models
{
    public class ValidaCampos
    {
        public IEnumerable<string> Erros { get; private set; }

        public ValidaCampos(IEnumerable<string> erros)
        {
            Erros = erros;
        }
    }
}
