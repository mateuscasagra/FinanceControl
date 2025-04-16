using System;
using System.Collections.Generic;
using System.IO;

class GerenciadorTransacao
{
    public List<Financeiro> transacoes = new List<Financeiro>();

    public void AdicionaTransacao(DateTime data, string categoria, double valor)
    {
        Financeiro transacao = new Financeiro(data, categoria, valor);
        transacoes.Add(transacao);

        using (StreamWriter escreve = new StreamWriter("Transacoes.txt", true))
        {
            // Usando | como separador
            escreve.WriteLine($"{data:dd/MM/yyyy}|{categoria}|{valor}|{transacao.DirecaoTransacao}");
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
            if (transacao.DataTransacao.Day == dia)
            {
                ExibirTransacaoColorida(transacao);
            }
        }
    }

    public void ListarTransacoesMes(int mes)
    {
        foreach (var transacao in CarregarTransacoesDoArquivo())
        {
            if (transacao.DataTransacao.Month == mes)
            {
                ExibirTransacaoColorida(transacao);
            }
        }
    }

    public void ListarTransacoesAno(int ano)
    {
        foreach (var transacao in CarregarTransacoesDoArquivo())
        {
            if (transacao.DataTransacao.Year == ano)
            {
                ExibirTransacaoColorida(transacao);
            }
        }
    }

    private void ExibirTransacaoColorida(Financeiro t)
    {
        Console.Write($"{t.DataTransacao:dd/MM/yyyy} - {t.CategoriaTransacao} - {t.ValorTransacao} - ");
        Console.ForegroundColor = t.DirecaoTransacao == "Entrada" ? ConsoleColor.Green : ConsoleColor.Red;
        Console.WriteLine(t.DirecaoTransacao);
        Console.ResetColor();
    }

    private Financeiro LinhaParaFinanceiro(string linha)
    {
        try
        {
            string[] partes = linha.Split('|');
            if (partes.Length == 4)
            {
                string dataStr = partes[0].Trim(); // formato: dd/MM/yyyy
                DateTime data = DateTime.ParseExact(dataStr, "dd/MM/yyyy", null);

                string categoria = partes[1].Trim();
                double valor = double.Parse(partes[2].Trim());

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

    public void TotalTransacoesDia(int dia)
{
    double totalEntrada = 0;
    double totalSaida = 0;

    foreach (var transacao in CarregarTransacoesDoArquivo())
    {
        if (transacao.DataTransacao.Day == dia)
        {
            if (transacao.ValorTransacao > 0)
            {
                totalEntrada += transacao.ValorTransacao;
            }
            else
            {
                totalSaida += transacao.ValorTransacao; 
            }
        }
    }

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"Total Entradas: R$ {totalEntrada:F2}");
    
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Total Saídas: R$ {Math.Abs(totalSaida):F2}");

    Console.ResetColor();
}
 public void TotalTransacoesMes(int mes)
{
    double totalEntrada = 0;
    double totalSaida = 0;

    foreach (var transacao in CarregarTransacoesDoArquivo())
    {
        if (transacao.DataTransacao.Month == mes)
        {
            if (transacao.ValorTransacao > 0)
            {
                totalEntrada += transacao.ValorTransacao;
            }
            else
            {
                totalSaida += transacao.ValorTransacao; 
            }
        }
    }

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"Total Entradas: R$ {totalEntrada:F2}");
    
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Total Saídas: R$ {Math.Abs(totalSaida):F2}");

    Console.ResetColor();
}
 public void TotalTransacoesAno(int ano)
{
    double totalEntrada = 0;
    double totalSaida = 0;

    foreach (var transacao in CarregarTransacoesDoArquivo())
    {
        if (transacao.DataTransacao.Year == ano)
        {
            if (transacao.ValorTransacao > 0)
            {
                totalEntrada += transacao.ValorTransacao;
            }
            else
            {
                totalSaida += transacao.ValorTransacao; 
            }
        }
    }

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"Total Entradas: R$ {totalEntrada:F2}");
    
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Total Saídas: R$ {Math.Abs(totalSaida):F2}");

    Console.ResetColor();
}
 public void TotalTransacoes()
{
    double totalEntrada = 0;
    double totalSaida = 0;

    foreach (var transacao in CarregarTransacoesDoArquivo())
    {
        if (transacao.DataTransacao !=null)
        {
            if (transacao.ValorTransacao > 0)
            {
                totalEntrada += transacao.ValorTransacao;
            }
            else
            {
                totalSaida += transacao.ValorTransacao; 
            }
        }
    }

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"Total Entradas: R$ {totalEntrada:F2}");
    
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Total Saídas: R$ {Math.Abs(totalSaida):F2}");

    Console.ResetColor();
}
}
