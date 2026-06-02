namespace CentralOperacoesLunar.Dominio;

public enum TipoSeveridadeOcorrencia
{
    Leve,
    Media,
    Critica
}

public enum TipoEventoHistorico
{
    Normal,
    Ocorrencia,
    Resolucao,
    Positivo,
    Continuacao,
    Derrota,
    Encerramento
}

public enum ResultadoResolucao
{
    Sucesso,
    Falha,
    Agravamento,
    NovoEvento,
    Parcial,
    Ignorado
}
