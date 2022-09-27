namespace ConsoleApp1.Entidades
{
    internal abstract class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public double Salario { get; set; }


        public abstract double CalcularPagamento(List<Pedido> pedidos);

        public override string ToString()
        {
            return $"{Id} | {Nome} | {Matricula} | {Salario}";
        }
    }
}
