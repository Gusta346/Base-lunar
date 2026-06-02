using CentralOperacoesLunar.Dominio;
using CentralOperacoesLunar.Interfaces;

namespace CentralOperacoesLunar.Servicos;

public sealed class ResolucaoOcorrenciaServico : IResolucaoOcorrencia
{
    public ResultadoResolucao Resolver(Ocorrencia ocorrencia, RoboBase roboSelecionado, EstadoBaseLunar estadoBase)
    {
        return roboSelecionado.Responder(ocorrencia, estadoBase);
    }
}
