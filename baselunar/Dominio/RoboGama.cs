using CentralOperacoesLunar.Estruturas;

namespace CentralOperacoesLunar.Dominio;

public sealed class RoboGama : RoboBase
{
    public RoboGama(global::CentralOperacoesLunar.Estruturas.CoordenadaLunar localizacao) : base("Robô Gama", "Exploração", localizacao)
    {
    }

    public override string Descrever() => $"{Nome} (Exploração) | Energia: {Energia}% | Posição: {Localizacao.Linha},{Localizacao.Coluna}";

    public override ResultadoResolucao Responder(Ocorrencia ocorrencia, EstadoBaseLunar estadoBase)
    {
        ConsumirEnergia(ocorrencia.Severidade == TipoSeveridadeOcorrencia.Critica ? 12 : 7);

        if (!Operacional)
        {
            return ResultadoResolucao.Falha;
        }

        return ocorrencia.Severidade switch
        {
            TipoSeveridadeOcorrencia.Critica => ResultadoResolucao.NovoEvento,
            TipoSeveridadeOcorrencia.Media => ResultadoResolucao.Sucesso,
            _ => ResultadoResolucao.Sucesso
        };
    }
}
