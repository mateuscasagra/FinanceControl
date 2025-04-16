class Financeiro
{
    public DateTime DataTransacao { get; set; }
    public string CategoriaTransacao { get; set; }
    public double ValorTransacao { get; set; }
    public string DirecaoTransacao { get; set; }


    public Financeiro(DateTime data, string categoria, double valor)
    {
        DataTransacao = data;
        CategoriaTransacao = categoria;
        ValorTransacao = valor;
        DirecaoTransacao = valor > 0 ? "Entrada" : "Saída";
    }

    public string GetDataFormatada()
    {
        return DataTransacao.ToString("dd/MM/yyyy");
    }

    public string DataDia()
    {
        return DataTransacao.Day.ToString("D2");
    }

    public string DataMes()
    {
        return DataTransacao.Month.ToString("D2");
    }

    public string DataAno()
    {
        return DataTransacao.Year.ToString();
    }
    public string TransacaoDirecao()
{
    return DirecaoTransacao;
}
}
