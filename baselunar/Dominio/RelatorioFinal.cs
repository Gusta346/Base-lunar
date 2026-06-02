namespace CentralOperacoesLunar.Dominio;

public class RelatorioFinal
{
    public DateTime DataHoraEncerramento { get; init; }
    public int DiasExecutados { get; init; }
    public int FalhasCriticas { get; init; }
    public int OcorrenciasCriticasIgnoradasConsecutivas { get; init; }
    public string MotivoEncerramento { get; init; } = string.Empty;
    public IReadOnlyList<RegistroHistorico> Historico { get; init; } = Array.Empty<RegistroHistorico>();
}
