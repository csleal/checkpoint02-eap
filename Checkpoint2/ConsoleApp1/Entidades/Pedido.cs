using ConsoleApp1.Entidades.Enums;

namespace ConsoleApp1.Entidades
{
    internal class Pedido
    {
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }
        public double Valor { get; set; }
        public StatusPedido Status { get; set; }
        public List<ItemPedido> Itens { get; set; }
        public Funcionario Funcionario { get; set; }

        public void AdicionarItem(ItemPedido item)
        {
            if (Itens == null)
            {
                Itens = new List<ItemPedido>();
            }

            Itens.Add(item);
            CalcularValor();
        }

        public void RemoverItem(ItemPedido item)
        {
            if (Itens != null && Itens.Contains(item))
            {
                Itens.Remove(item);
                CalcularValor();
            }
        }

        private void CalcularValor()
        {
            double soma = 0;

            Itens.ForEach(item =>
            {
                soma += item.SubTotal();
            });

            Valor = soma;
        }

        public override string ToString()
        {
            return $"{Id} | {DataPedido} | {Valor} | {Status} ";
        }
    }
}
