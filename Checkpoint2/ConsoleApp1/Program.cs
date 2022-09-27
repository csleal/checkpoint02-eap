using ConsoleApp1.Entidades.Enums;
using ConsoleApp1.Entidades;

//StatusPedido status = StatusPedido.AguardandoPagamento;
//int status1 = (int) StatusPedido.Processando;
//string status2 = StatusPedido.Enviado.ToString();
//StatusPedido status3 = (StatusPedido) 3;
//StatusPedido status4 = Enum.Parse<StatusPedido>("Cancelado");

//Console.WriteLine(status);
//Console.WriteLine($"Codigo do status Processando: {status1}");
//Console.WriteLine($"Status 2: {status2}");
//Console.WriteLine($"Status 3: {status3}");
//Console.WriteLine($"Status 4: {status4}");

//Pedido pedido = new Pedido()
//{
//    Id = 1,
//    DataPedido = DateTime.Now,
//    Valor = 235.8,
//    Status = StatusPedido.AguardandoPagamento,
//    Pagamento = FormaPagamento.CartaoDebito
//};

//Console.WriteLine(pedido);

List<Produto> produtos = new List<Produto>();
List<Funcionario> funcionarios = new List<Funcionario>();
List<Pedido> pedidos = new List<Pedido>();

int opcao = 0;

do
{
    Console.WriteLine("1 - Cadastrar Produto");
    Console.WriteLine("2 - Cadastrar Funcionario");
    Console.WriteLine("3 - Efetuar Venda");
    Console.WriteLine("4 - Listar Produtos");
    Console.WriteLine("5 - Listar Funcionarios");
    Console.WriteLine("6 - Listar Pedidos");
    Console.WriteLine("7 - Calcular Pagamento de Funcionario");
    Console.WriteLine("8 - Sair");
    Console.Write("Opcao: ");

    opcao = int.Parse(Console.ReadLine());

    Console.Clear();

    switch (opcao)
    {
        case 1:
            Console.WriteLine("Cadastrar Produto");
            Produto produto = new Produto();

            Console.Write("Id: ");
            produto.Id = int.Parse(Console.ReadLine());

            Console.Write("Nome: ");
            produto.Nome = Console.ReadLine();

            Console.Write("Valor: ");
            produto.Valor = double.Parse(Console.ReadLine());

            produtos.Add(produto);
            break;

        case 2:
            Console.WriteLine("Cadastrar Funcionario - 1 para Vendedor, 2 para Gerente");
            int tipo = int.Parse(Console.ReadLine());

            if (tipo == 1)
            {
                Vendedor vendedor = new Vendedor();
                Console.Write("Id: ");
                vendedor.Id = int.Parse(Console.ReadLine());

                Console.Write("Nome: ");
                vendedor.Nome = Console.ReadLine();

                Console.Write("Matricula: ");
                vendedor.Matricula = Console.ReadLine();

                Console.Write("Salario: ");
                vendedor.Salario = double.Parse(Console.ReadLine());

                funcionarios.Add(vendedor);
            }

            if (tipo == 2)
            {
                Gerente gerente = new Gerente();
                Console.Write("Id: ");
                gerente.Id = int.Parse(Console.ReadLine());

                Console.Write("Nome: ");
                gerente.Nome = Console.ReadLine();

                Console.Write("Matricula: ");
                gerente.Matricula = Console.ReadLine();

                Console.Write("Salario: ");
                gerente.Salario = double.Parse(Console.ReadLine());

                funcionarios.Add(gerente);
            }
            break;

        case 3:
            Console.WriteLine("Efetuar Venda");
            Pedido pedido = new Pedido();

            Console.Write("Id do Funcionario: ");
            int idFuncionario = int.Parse(Console.ReadLine());

            pedido.Funcionario = funcionarios.Find(funcionario => funcionario.Id == idFuncionario);

            Console.Write("Quantos itens irão compor a venda? ");
            int qtdItens = int.Parse(Console.ReadLine());

            for (int i=0; i<qtdItens; i++)
            {
                ItemPedido item = new ItemPedido();

                Console.Write($"Id do Produto {i + 1}: ");
                int idProduto = int.Parse(Console.ReadLine());

                item.Produto = produtos.Find(produto => produto.Id == idProduto);
                item.Valor = item.Produto.Valor;

                Console.Write($"Quantidade do Produto {i+1}: ");
                item.Quantidade = int.Parse(Console.ReadLine());

                pedido.AdicionarItem(item);
            }

            pedido.DataPedido = DateTime.Now;
            pedido.Status = StatusPedido.Processando;

            pedidos.Add(pedido);

            break;

        case 4:
            Console.WriteLine("Listar Produtos");

            produtos.ForEach(produto =>
            {
                Console.WriteLine(produto);
            });

            break;

        case 5:
            Console.WriteLine("Listar Funcionarios");

            funcionarios.ForEach(funcionario =>
            {
                Console.WriteLine(funcionario);
            });

            break;

        case 6:
            Console.WriteLine("Listar Pedidos");

            pedidos.ForEach(pedido =>
            {
                Console.WriteLine(pedido);
            });

            break;
        case 7:
            
            Console.WriteLine("Calcular Pagamento de Funcionário");
            Console.WriteLine("Digite o número da matrícula do funcionário para que seja calculado o pagamento");
            string matriculaFuncionario = Console.ReadLine();

            Funcionario funcionario = funcionarios.Find(funcionario => funcionario.Matricula == matriculaFuncionario);
            double pagamento = funcionario.CalcularPagamento(pedidos);
            Console.WriteLine($"O valor do pagamento do funcionário {funcionario.Nome} é de {pagamento:F2}");
            break;
    }

    Console.ReadKey();
    Console.Clear();
} while (opcao != 8);
