using CentralOperacoesLunar.Dominio;

namespace CentralOperacoesLunar.Interfaces;

public interface IMonitoramento
{
    Ocorrencia? GerarOcorrencia(DateTime dataHora);
    string GerarMensagemSemOcorrencia();
}
