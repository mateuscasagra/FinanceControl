class Program
{
    static void Main(string[] args)
    {
        GerenciadorTransacao gerenciador = new GerenciadorTransacao();

       
        gerenciador.AdicionaTransacao(20250410, "Pix", 150.75f);
        gerenciador.AdicionaTransacao(20250211, "Mercado", -89.90f);
        gerenciador.AdicionaTransacao(20240210, "Salário", 2500f);

        Console.WriteLine();
        gerenciador.ListarTodasTransacoes();
        Console.WriteLine();
        gerenciador.ListarTransacoesMes(02);
        Console.WriteLine();
        gerenciador.ListarTransacoesDia(10);
        Console.WriteLine();
        gerenciador.ListarTransacoesAno(2023);
        Console.WriteLine();
    }
}