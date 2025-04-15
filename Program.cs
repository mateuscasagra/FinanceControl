using System;
using System.IO;



class Program
{
    static void Main(string[] args)
    {
        GerenciadorTransacao gerenciador = new GerenciadorTransacao();
        Usuarios usuario = new Usuarios();
        Console.WriteLine("Bem vindo... ");
        Console.WriteLine("(1) - Cadastrar\n(2) - Login");
        string resposta = Console.ReadLine();
        if(resposta == "1"){
            Console.WriteLine("Digite o Usuário");
            string login = Console.ReadLine();
            Console.WriteLine("Digite a Senha");
            string senha = Console.ReadLine();
            usuario.CriaUsuario(login, senha);
        }else if (resposta == "2"){
            Console.WriteLine("Digite o Usuário");
            string login = Console.ReadLine();
            Console.WriteLine("Digite a Senha");
            string senha = Console.ReadLine();
            usuario.FazerLogin(login, senha);
        }
        while(usuario.StatusLogado()){
            Menu menu = new Menu();
            Console.WriteLine("O que deseja?\n(1) - Lançar Registro\n(2) - Relatórios\n(3) - Metas");
            resposta = Console.ReadLine();
            menu.MenuInicial(resposta);
            

        }
       
        
    }
}