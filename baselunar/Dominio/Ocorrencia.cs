namespace CentralOperacoesLunar.Dominio;

public class Ocorrencia
{
    public Ocorrencia(string nome, string descricao, TipoSeveridadeOcorrencia severidade, DateTime dataHora)
    {
        Nome = nome;
        Descricao = descricao;
        Severidade = severidade;
        DataHora = dataHora;
    }

    public string Nome { get; }
    public string Descricao { get; }
    public TipoSeveridadeOcorrencia Severidade { get; }
    public DateTime DataHora { get; }

    public bool ECritica => Severidade == TipoSeveridadeOcorrencia.Critica;
    public bool EMedia => Severidade == TipoSeveridadeOcorrencia.Media;
    public bool ELeve => Severidade == TipoSeveridadeOcorrencia.Leve;

    public override string ToString() => $"{Nome} - {Descricao}";
}
