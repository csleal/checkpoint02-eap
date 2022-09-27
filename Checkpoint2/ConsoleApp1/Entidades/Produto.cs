namespace ConsoleApp1.Entidades
{
    internal class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }

        public override string ToString()
        {
            return $"{Id} | {Nome} | {Valor:F2}";
        }
    }
}
