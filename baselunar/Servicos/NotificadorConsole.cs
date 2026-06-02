using CentralOperacoesLunar.Interfaces;

namespace CentralOperacoesLunar.Servicos;

public sealed class NotificadorConsole : INotificador
{
    public void Notificar(string mensagem, string categoria)
    {
        Console.WriteLine();
        Console.WriteLine($"[{categoria.ToUpperInvariant()}] {mensagem}");
        Console.WriteLine();
    }
}
