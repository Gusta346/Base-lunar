using CentralOperacoesLunar.Dominio;
using CentralOperacoesLunar.Estruturas;
using CentralOperacoesLunar.Interfaces;

namespace CentralOperacoesLunar.Servicos;

public sealed class FabricaDependencias
{
    public FabricaDependencias()
    {
        Notificador = new NotificadorConsole();
        ImpressaoConsole = new ImpressaoConsoleServico();
        Monitoramento = new MonitoramentoServico();
        Historico = new HistoricoServico();
        ResolucaoOcorrencia = new ResolucaoOcorrenciaServico();

        Robos =
        [
            new RoboAlfa(new CoordenadaLunar(1, 2)),
            new RoboBeta(new CoordenadaLunar(3, 4)),
            new RoboGama(new CoordenadaLunar(5, 6))
        ];
    }

    public INotificador Notificador { get; }
    public IImpressaoConsole ImpressaoConsole { get; }
    public IMonitoramento Monitoramento { get; }
    public IHistoricoServico Historico { get; }
    public IResolucaoOcorrencia ResolucaoOcorrencia { get; }
    public IReadOnlyList<RoboBase> Robos { get; }
}
