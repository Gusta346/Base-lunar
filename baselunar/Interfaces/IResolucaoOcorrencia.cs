using CentralOperacoesLunar.Dominio;

namespace CentralOperacoesLunar.Interfaces;

public interface IResolucaoOcorrencia
{
    ResultadoResolucao Resolver(Ocorrencia ocorrencia, RoboBase roboSelecionado, EstadoBaseLunar estadoBase);
}
