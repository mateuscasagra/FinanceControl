class Usuarios{
    private string login {get;set;}
    private string senha {get;set;}

    private bool logado {get;set;}




    public void CriaUsuario(string login, string senha){
        this.login = login;
        this.senha = senha;
        SalvaUsuario();
        logado = true;
    }

    public void SalvaUsuario(){
        using (StreamWriter escreve = new StreamWriter("Usuarios.txt",true)){
            escreve.WriteLine($"{login} / {senha}");
        }
    }

    public void FazerLogin(string Login, string Senha)
{
    string[] registros = File.ReadAllLines("Usuarios.txt");
    bool encontrou = false;

    foreach (string registro in registros)
    {
        string[] dados = registro.Split('/');
        string login = dados[0].Trim();
        string senha = dados[1].Trim();

        if (login == Login.Trim() && senha == Senha.Trim())
        {
            logado = true;
            Console.WriteLine($"Olá {login}");
            encontrou = true;
            break;
        }
    }

    if (!encontrou)
    {
        Console.WriteLine("Dados incorretos ou não cadastrados");
    }
}

    public bool StatusLogado(){
        return logado;
    }



}