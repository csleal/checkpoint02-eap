namespace ConsoleApp1.Entidades
{
    internal class Vendedor : Funcionario
    {
        public override double CalcularPagamento(List<Pedido> pedidos)
        {
            double vendas = 0;
            foreach (Pedido pedido in pedidos)
            {
                if (pedido.Funcionario.Matricula == Matricula)
                {
                    vendas += pedido.Valor * 0.1;
                }
                
            }
            return Salario + vendas;
        }
    }
}
