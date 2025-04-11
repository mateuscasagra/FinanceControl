class GerenciadorTransacao
{
    public List<Financeiro> transacoes = new List<Financeiro>();

    public void AdicionaTransacao(int data, string categoria, float valor)
    {
        Financeiro nova = new Financeiro(data, categoria, valor);
        transacoes.Add(nova);
    }

    public void ListarTodasTransacoes()
    {
        foreach (var t in transacoes)
        {
            ExibirTransacaoColorida(t);        
        }
    }

    private void ExibirTransacaoColorida(Financeiro t)
{

    Console.Write($"{t.GetDataFormatada()} - {t.CategoriaTransacao} - {t.ValorTransacao} - ");

    Console.ForegroundColor = t.DirecaoTransacao == "Entrada" ? ConsoleColor.Green : ConsoleColor.Red;

    Console.WriteLine(t.DirecaoTransacao);
    Console.ResetColor();
}


public void ListarTransacoesDia(int dia)
{
    foreach (var t in transacoes)
    {
        string dataStr = t.DataTransacao.ToString();
        DateTime data = DateTime.ParseExact(dataStr, "yyyyMMdd", null);

        if (data.Day == dia)
        {
            ExibirTransacaoColorida(t);
        }
    }
}
    public void ListarTransacoesMes(int mes)
{
    foreach (var t in transacoes)
    {
        string dataStr = t.DataTransacao.ToString();
        DateTime data = DateTime.ParseExact(dataStr, "yyyyMMdd", null);

        if (data.Month == mes)
        {
            ExibirTransacaoColorida(t);
        }
    }
}


public void ListarTransacoesAno(int ano)
{
    foreach (var t in transacoes)
    {
        string dataStr = t.DataTransacao.ToString();
        DateTime data = DateTime.ParseExact(dataStr, "yyyyMMdd", null);

        if (data.Year == ano)
        {
            ExibirTransacaoColorida(t);
        }
    }
}

    

}
