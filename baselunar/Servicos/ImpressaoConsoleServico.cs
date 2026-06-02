using CentralOperacoesLunar.Interfaces;

namespace CentralOperacoesLunar.Servicos;

public sealed class ImpressaoConsoleServico : IImpressaoConsole
{
    public void EscreverLinha(string mensagem = "") => Console.WriteLine(mensagem);

    public void EscreverBloco(string titulo, IEnumerable<string> linhas)
    {
        Console.WriteLine(titulo);
        Console.WriteLine();
        foreach (var linha in linhas)
        {
            Console.WriteLine(linha);
        }
        Console.WriteLine();
    }

    public string LerOpcao(string mensagem)
    {
        Console.Write(mensagem);
        return Console.ReadLine() ?? string.Empty;
    }
}
