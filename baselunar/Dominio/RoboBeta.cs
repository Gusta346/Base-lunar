using CoordenadaLunar = CentralOperacoesLunar.Estruturas.CoordenadaLunar;

namespace CentralOperacoesLunar.Dominio;

public sealed class RoboBeta : RoboBase
{
    public RoboBeta(CoordenadaLunar localizacao) : base("Robô Beta", "Transporte", localizacao)
    {
    }

    public override string Descrever() => $"{Nome} (Transporte) | Energia: {Energia}% | Posição: {Localizacao.Linha},{Localizacao.Coluna}";

    public override ResultadoResolucao Responder(Ocorrencia ocorrencia, EstadoBaseLunar estadoBase)
    {
        ConsumirEnergia(ocorrencia.Severidade == TipoSeveridadeOcorrencia.Critica ? 14 : 8);

        if (!Operacional)
        {
            return ResultadoResolucao.Falha;
        }

        if (ocorrencia.Severidade == TipoSeveridadeOcorrencia.Critica)
        {
            return ResultadoResolucao.Sucesso;
        }

        return ocorrencia.Severidade == TipoSeveridadeOcorrencia.Media && estadoBase.Energia < 30
            ? ResultadoResolucao.Agravamento
            : ResultadoResolucao.Sucesso;
    }
}
