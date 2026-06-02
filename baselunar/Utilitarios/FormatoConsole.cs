namespace CentralOperacoesLunar.Utilitarios;

public static class FormatoConsole
{
    public static string LinhaSeparadora => new('=', 50);

    public static void LimparTela()
    {
        Console.Clear();
        Console.WriteLine(LinhaSeparadora);
    }

    public static void EscreverTitulo(string titulo)
    {
        Console.WriteLine(LinhaSeparadora);
        Console.WriteLine(titulo.ToUpperInvariant());
        Console.WriteLine(new string('=', titulo.Length));
        Console.WriteLine();
    }
}
