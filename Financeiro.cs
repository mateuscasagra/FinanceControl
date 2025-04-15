class Financeiro
{
    public int DataTransacao { get; set; }
    public string CategoriaTransacao { get; set; }
    public float ValorTransacao { get; set; }
    public string DirecaoTransacao { get; set; }
    

    public Financeiro(int data, string categoria, float valor)
    {
        DataTransacao = data;
        CategoriaTransacao = categoria;
        ValorTransacao = valor;
        DirecaoTransacao = valor > 0 ? "Entrada" : "Saída";
    }

    public string GetDataFormatada()
    {
        string dataStr = DataTransacao.ToString(); 
        DateTime data = DateTime.ParseExact(dataStr, "yyyyMMdd", null);
        return data.ToString("dd/MM/yyyy"); 
    }

    public string DataDia(){
        string dataStr = DataTransacao.ToString();
        DateTime data = DateTime.ParseExact(dataStr, "yyyyMMdd", null);
        return data.ToString("dd");

    }

    public string DataMes(){
        string dataStr = DataTransacao.ToString();
        DateTime data = DateTime.ParseExact(dataStr, "yyyyMMdd", null);
        return data.ToString("MM");

    }
    public string DataAno(){
        string dataStr = DataTransacao.ToString();
        DateTime data = DateTime.ParseExact(dataStr, "yyyyMMdd", null);
        return data.ToString("yyyy");

    }

    public string TransacaoDirecao(){
        return DirecaoTransacao;
    }
}
