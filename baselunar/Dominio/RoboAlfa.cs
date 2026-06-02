using CoordenadaLunar = CentralOperacoesLunar.Estruturas.CoordenadaLunar;

namespace CentralOperacoesLunar.Dominio;

public sealed class RoboAlfa : RoboBase
{
    public RoboAlfa(CoordenadaLunar localizacao) : base("Robô Alfa", "Manutenção", localizacao)
    {
    }

    public override string Descrever() => $"{Nome} (Manutenção) | Energia: {Energia}% | Posição: {Localizacao.Linha},{Localizacao.Coluna}";

    public override ResultadoResolucao Responder(Ocorrencia ocorrencia, EstadoBaseLunar estadoBase)
    {
        ConsumirEnergia(ocorrencia.Severidade == TipoSeveridadeOcorrencia.Critica ? 18 : 10);

        return ocorrencia.Severidade switch
        {
            TipoSeveridadeOcorrencia.Critica when Operacional => ResultadoResolucao.Sucesso,
            TipoSeveridadeOcorrencia.Media when Energia >= 20 => ResultadoResolucao.Sucesso,
            TipoSeveridadeOcorrencia.Leve => ResultadoResolucao.Sucesso,
            _ => ResultadoResolucao.Falha
        };
    }
}
