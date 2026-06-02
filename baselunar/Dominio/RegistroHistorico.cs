namespace CentralOperacoesLunar.Dominio;

public class RegistroHistorico
{
    public RegistroHistorico(DateTime dataHora, int dia, TipoEventoHistorico tipoEvento, string ocorrencia, string acaoRealizada, string resultadoObtido)
    {
        DataHora = dataHora;
        Dia = dia;
        TipoEvento = tipoEvento;
        Ocorrencia = ocorrencia;
        AcaoRealizada = acaoRealizada;
        ResultadoObtido = resultadoObtido;
    }

    public DateTime DataHora { get; }
    public int Dia { get; }
    public TipoEventoHistorico TipoEvento { get; }
    public string Ocorrencia { get; }
    public string AcaoRealizada { get; }
    public string ResultadoObtido { get; }

    public string Resumir() => $"Dia {Dia} | {DataHora:dd/MM/yyyy HH:mm} | {TipoEvento} | {Ocorrencia} | {AcaoRealizada} | {ResultadoObtido}";
}
