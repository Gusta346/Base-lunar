namespace CentralOperacoesLunar.Dominio;

public class ConsequenciaFutura
{
    public ConsequenciaFutura(int diaAlvo, string mensagem, Action<EstadoBaseLunar>? efeito = null)
    {
        DiaAlvo = diaAlvo;
        Mensagem = mensagem;
        Efeito = efeito;
    }

    public int DiaAlvo { get; }
    public string Mensagem { get; }
    public Action<EstadoBaseLunar>? Efeito { get; }
}
