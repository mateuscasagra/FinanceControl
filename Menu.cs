using System;

class Menu
{
    // Instância única do Gerenciador de Transações
    GerenciadorTransacao transacao = new GerenciadorTransacao();

    public void MenuInicial()
    {
        string opcao;
        do
        {
            Console.Clear();
            Console.WriteLine("### Menu de Transações ###");
            Console.WriteLine("1. Adicionar Transação");
            Console.WriteLine("2. Consultar Transações");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha uma opção: ");
            opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Transacao();
                    break;
                case "2":
                    MenuConsulta();
                    break;
                case "0":
                    Console.WriteLine("Saindo...");
                    break;
                default:
                    Console.WriteLine("Opção inválida! Tente novamente.");
                    break;
            }

            if (opcao != "0")
            {
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }

        } while (opcao != "0");
    }

    // Método para adicionar transações
    public void Transacao()
    {
        Console.WriteLine("Digite a Data da Transação em formato ddmmyyyy:");
        int data = Int32.Parse(Console.ReadLine());

        Console.WriteLine("Digite a Categoria da Transação:");
        string categoria = Console.ReadLine();

        Console.WriteLine("Digite o Valor da Transação:");
        float valor = float.Parse(Console.ReadLine());

        transacao.AdicionaTransacao(data, categoria, valor);
        Console.WriteLine("Transação adicionada com sucesso!");
    }

    // Método para consultar transações
    public void MenuConsulta()
    {
        string opcao;
        do
        {
            Console.Clear();
            Console.WriteLine("Filtrar por:");
            Console.WriteLine("(1) - Dia");
            Console.WriteLine("(2) - Mês");
            Console.WriteLine("(3) - Ano");
            Console.WriteLine("(4) - Todas transações");
            Console.WriteLine("(0) - Voltar");
            Console.Write("Escolha uma opção: ");
            opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    ListarTransacoesPorDia();
                    break;
                case "2":
                    ListarTransacoesPorMes();
                    break;
                case "3":
                    ListarTransacoesPorAno();
                    break;
                case "4":
                    transacao.ListarTodasTransacoes();
                    break;
                case "0":
                    break;
                default:
                    Console.WriteLine("Opção inválida! Tente novamente.");
                    break;
            }

            if (opcao != "0")
            {
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }

        } while (opcao != "0");
    }

    // Métodos para listar transações filtradas por dia, mês ou ano
    public void ListarTransacoesPorDia()
    {
        Console.WriteLine("Digite o dia para filtrar as transações:");
        int dia = Int32.Parse(Console.ReadLine());
        transacao.ListarTransacoesDia(dia);
    }

    public void ListarTransacoesPorMes()
    {
        Console.WriteLine("Digite o mês para filtrar as transações (1 a 12):");
        int mes = Int32.Parse(Console.ReadLine());
        transacao.ListarTransacoesMes(mes);
    }

    public void ListarTransacoesPorAno()
    {
        Console.WriteLine("Digite o ano para filtrar as transações:");
        int ano = Int32.Parse(Console.ReadLine());
        transacao.ListarTransacoesAno(ano);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        menu.MenuInicial();  // Chama o menu inicial
    }
}
