class Carregando
{
    public void IniciarCarregamento()
    {
        int i = 0;

        while (true) 
        {
            string pontos = new string('.', i % 4); // "", ".", "..", "..."
            Console.Write($"\r{pontos}"); 
            Thread.Sleep(500);
            i++;
        }
    }
}