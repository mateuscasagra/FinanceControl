using System;

class Program
{
    static void Main(string[] args)
    {
        Usuarios usuario = new Usuarios();
        GerenciadorTransacao transacao = new GerenciadorTransacao();

        Console.WriteLine("Bem-vindo... ");
        Console.WriteLine("(1) - Cadastrar\n(2) - Login");
        string resposta = Console.ReadLine();

        if (resposta == "1")
        {
            Console.WriteLine("Digite o Usuário:");
            string login = Console.ReadLine();
            Console.WriteLine("Digite a Senha:");
            string senha = Console.ReadLine();
            usuario.CriaUsuario(login, senha);
        }
        else if (resposta == "2")
        {
            Console.WriteLine("Digite o Usuário:");
            string login = Console.ReadLine();
            Console.WriteLine("Digite a Senha:");
            string senha = Console.ReadLine();
            usuario.FazerLogin(login, senha);
        }

        while (usuario.StatusLogado())
        {
            Console.WriteLine("\nEscolha a operação...\n(1) - Lançar\n(2) - Consultar\n(3) - Definir Meta");
            resposta = Console.ReadLine();

            switch (resposta)
            {
                case "1":
                    Console.WriteLine("Digite a data da transação... (dd/MM/yyyy)");
                    DateTime data = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                    Console.WriteLine("Digite a categoria da transação:");
                    string categoria = Console.ReadLine();
                    Console.WriteLine("Digite o Valor da transação:");
                    double valor = double.Parse(Console.ReadLine());

                    transacao.AdicionaTransacao(data, categoria, valor);
                    break;

                case "2":
                    Console.WriteLine("\nVisualizar\n(1) - Transações Dia\n(2) - Transações Mês\n(3) - Transações Ano\n(4) - Todas as Transações");
                    string opcao = Console.ReadLine();

                    switch (opcao)
                    {
                        case "1":
                            Console.WriteLine("Qual o dia buscado?");
                            int dia = int.Parse(Console.ReadLine());
                            transacao.ListarTransacoesDia(dia);
                            transacao.TotalTransacoesDia(dia);
                            break;

                        case "2":
                            Console.WriteLine("Qual o mês buscado?");
                            int mes = int.Parse(Console.ReadLine());
                            transacao.ListarTransacoesMes(mes);
                            break;

                        case "3":
                            Console.WriteLine("Qual o ano buscado?");
                            int ano = int.Parse(Console.ReadLine());
                            transacao.ListarTransacoesAno(ano);
                            break;

                        case "4":
                            transacao.ListarTodasTransacoes();
                            break;
                    }
                    break;
            }
        }
    }
}
