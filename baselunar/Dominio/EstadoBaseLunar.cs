using CentralOperacoesLunar.Estruturas;

namespace CentralOperacoesLunar.Dominio;

public class EstadoBaseLunar
{
    private readonly List<ConsequenciaFutura> _consequenciasFuturas = new();

    public EstadoBaseLunar(DateTime dataInicial)
    {
        DataInicial = dataInicial;
        DiaAtual = 1;
        Energia = 92;
        Oxigenio = 96;
        Comunicacao = 94;
        SuporteVida = 95;
        Integridade = 97;
        CoordenadaPrincipal = new global::CentralOperacoesLunar.Estruturas.CoordenadaLunar(12, 7);
    }

    public DateTime DataInicial { get; }
    public int DiaAtual { get; private set; }
    public int Energia { get; private set; }
    public int Oxigenio { get; private set; }
    public int Comunicacao { get; private set; }
    public int SuporteVida { get; private set; }
    public int Integridade { get; private set; }
    public int FalhasCriticasAcumuladas { get; private set; }
    public int OcorrenciasCriticasIgnoradasConsecutivas { get; private set; }
    public bool SistemaEncerrado { get; private set; }
    public global::CentralOperacoesLunar.Estruturas.CoordenadaLunar CoordenadaPrincipal { get; }

    public DateTime DataDoDia => DataInicial.AddDays(DiaAtual - 1);

    public void AvancarDia() => DiaAtual++;

    public void RegistrarFalhaCritica()
    {
        FalhasCriticasAcumuladas++;
        Integridade = Math.Max(0, Integridade - 6);
        Energia = Math.Max(0, Energia - 4);
    }

    public void RegistrarOmissaoCritica()
    {
        OcorrenciasCriticasIgnoradasConsecutivas++;
        Integridade = Math.Max(0, Integridade - 8);
        Oxigenio = Math.Max(0, Oxigenio - 6);
    }

    public void ReiniciarSequenciaDeOmissao() => OcorrenciasCriticasIgnoradasConsecutivas = 0;

    public void AplicarSucesso(TipoSeveridadeOcorrencia severidade)
    {
        switch (severidade)
        {
            case TipoSeveridadeOcorrencia.Critica:
                Integridade = Math.Min(100, Integridade + 5);
                Energia = Math.Min(100, Energia + 3);
                break;
            case TipoSeveridadeOcorrencia.Media:
                Integridade = Math.Min(100, Integridade + 2);
                Energia = Math.Min(100, Energia + 2);
                break;
            default:
                Energia = Math.Min(100, Energia + 1);
                break;
        }
    }

    public void AplicarFalha(TipoSeveridadeOcorrencia severidade)
    {
        switch (severidade)
        {
            case TipoSeveridadeOcorrencia.Critica:
                RegistrarFalhaCritica();
                Comunicacao = Math.Max(0, Comunicacao - 8);
                SuporteVida = Math.Max(0, SuporteVida - 8);
                break;
            case TipoSeveridadeOcorrencia.Media:
                Integridade = Math.Max(0, Integridade - 3);
                Energia = Math.Max(0, Energia - 2);
                break;
            default:
                Energia = Math.Max(0, Energia - 1);
                break;
        }
    }

    public void AplicarAgravamento(TipoSeveridadeOcorrencia severidade)
    {
        switch (severidade)
        {
            case TipoSeveridadeOcorrencia.Leve:
                Energia = Math.Max(0, Energia - 2);
                Integridade = Math.Max(0, Integridade - 1);
                break;
            case TipoSeveridadeOcorrencia.Media:
                Energia = Math.Max(0, Energia - 4);
                Integridade = Math.Max(0, Integridade - 3);
                Oxigenio = Math.Max(0, Oxigenio - 2);
                break;
            case TipoSeveridadeOcorrencia.Critica:
                RegistrarFalhaCritica();
                Oxigenio = Math.Max(0, Oxigenio - 8);
                SuporteVida = Math.Max(0, SuporteVida - 8);
                break;
        }
    }

    public void AplicarEventoPositivo()
    {
        Energia = Math.Min(100, Energia + 4);
        Oxigenio = Math.Min(100, Oxigenio + 3);
        Comunicacao = Math.Min(100, Comunicacao + 2);
        Integridade = Math.Min(100, Integridade + 2);
    }

    public void AgendarConsequencia(ConsequenciaFutura consequencia) => _consequenciasFuturas.Add(consequencia);

    public IReadOnlyList<ConsequenciaFutura> ObterConsequenciasDoDia()
    {
        return _consequenciasFuturas.Where(consequencia => consequencia.DiaAlvo == DiaAtual).ToList();
    }

    public void RemoverConsequencia(ConsequenciaFutura consequencia) => _consequenciasFuturas.Remove(consequencia);

    public void EncerrarSistema() => SistemaEncerrado = true;

    public string ObterResumoStatus()
    {
        return $"Dia {DiaAtual} | Energia {Energia}% | Oxigênio {Oxigenio}% | Comunicação {Comunicacao}% | Suporte de vida {SuporteVida}% | Integridade {Integridade}% | Falhas críticas {FalhasCriticasAcumuladas}";
    }
}
