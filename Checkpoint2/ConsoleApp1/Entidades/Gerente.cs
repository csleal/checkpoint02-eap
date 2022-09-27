namespace ConsoleApp1.Entidades
{
    internal class Gerente : Funcionario
    {
        public override double CalcularPagamento(List<Pedido> pedidos)
        {
            double vendas = 0;
            foreach (Pedido pedido in pedidos)
            {
                vendas += pedido.Valor * 0.05;
            }
            return Salario + vendas;
        }

    }
}
