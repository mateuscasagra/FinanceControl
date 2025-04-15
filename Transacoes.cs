using System;
using System.Collections.Generic;
using System.IO;

class GerenciadorTransacao
{
    public List<Financeiro> transacoes = new List<Financeiro>();

    public void AdicionaTransacao(int data, string categoria, float valor)
    {
        Financeiro transacao = new Financeiro(data, categoria, valor);
        transacoes.Add(transacao);

        using (StreamWriter escreve = new StreamWriter("Transacoes.txt", true))
        {
            escreve.WriteLine($"{data} / {categoria} / {valor} / {transacao.DirecaoTransacao}");
        }
    }

    public void ListarTodasTransacoes()
    {
        if (File.Exists("Transacoes.txt"))
        {
            string[] linhas = File.ReadAllLines("Transacoes.txt");

            foreach (var linha in linhas)
            {
                Financeiro transacao = LinhaParaFinanceiro(linha);
                if (transacao != null)
                {
                    ExibirTransacaoColorida(transacao);
                }
            }
        }
        else
        {
            Console.WriteLine("Nenhuma transação encontrada.");
        }
    }

    public void ListarTransacoesDia(int dia)
    {
        foreach (var transacao in CarregarTransacoesDoArquivo())
        {
            DateTime data = DateTime.ParseExact(transacao.DataTransacao.ToString(), "yyyyMMdd", null);
            if (data.Day == dia)
            {
                ExibirTransacaoColorida(transacao);
            }
        }
    }

    public void ListarTransacoesMes(int mes)
    {
        foreach (var transacao in CarregarTransacoesDoArquivo())
        {
            DateTime data = DateTime.ParseExact(transacao.DataTransacao.ToString(), "yyyyMMdd", null);
            if (data.Month == mes)
            {
                ExibirTransacaoColorida(transacao);
            }
        }
    }

    public void ListarTransacoesAno(int ano)
    {
        foreach (var transacao in CarregarTransacoesDoArquivo())
        {
            DateTime data = DateTime.ParseExact(transacao.DataTransacao.ToString(), "yyyyMMdd", null);
            if (data.Year == ano)
            {
                ExibirTransacaoColorida(transacao);
            }
        }
    }

    private void ExibirTransacaoColorida(Financeiro t)
    {
        Console.Write($"{t.GetDataFormatada()} - {t.CategoriaTransacao} - {t.ValorTransacao} - ");

        Console.ForegroundColor = t.DirecaoTransacao == "Entrada" ? ConsoleColor.Green : ConsoleColor.Red;
        Console.WriteLine(t.DirecaoTransacao);
        Console.ResetColor();
    }

    private Financeiro LinhaParaFinanceiro(string linha)
    {
        try
        {
            string[] partes = linha.Split('/');
            if (partes.Length == 4)
            {
                int data = int.Parse(partes[0].Trim());
                string categoria = partes[1].Trim();
                float valor = float.Parse(partes[2].Trim());
                // A direção é ignorada porque o construtor já define com base no valor
                return new Financeiro(data, categoria, valor);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao converter linha: " + ex.Message);
        }
        return null;
    }

    private List<Financeiro> CarregarTransacoesDoArquivo()
    {
        List<Financeiro> lista = new List<Financeiro>();

        if (File.Exists("Transacoes.txt"))
        {
            string[] linhas = File.ReadAllLines("Transacoes.txt");

            foreach (var linha in linhas)
            {
                Financeiro t = LinhaParaFinanceiro(linha);
                if (t != null)
                    lista.Add(t);
            }
        }

        return lista;
    }
}
