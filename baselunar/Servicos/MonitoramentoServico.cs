using CentralOperacoesLunar.Dominio;
using CentralOperacoesLunar.Interfaces;

namespace CentralOperacoesLunar.Servicos;

public sealed class MonitoramentoServico : IMonitoramento
{
    private readonly Random _aleatorio;

    public MonitoramentoServico(Random? aleatorio = null)
    {
        _aleatorio = aleatorio ?? Random.Shared;
    }

    public Ocorrencia? GerarOcorrencia(DateTime dataHora)
    {
        if (_aleatorio.Next(100) < 28)
        {
            return null;
        }

        return CatalogoOcorrencias.CriarOcorrenciaAleatoria(_aleatorio, dataHora);
    }

    public string GerarMensagemSemOcorrencia() => CatalogoOcorrencias.ObterMensagemSemOcorrencia(_aleatorio);
}
