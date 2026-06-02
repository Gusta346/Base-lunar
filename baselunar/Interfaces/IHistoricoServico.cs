using CentralOperacoesLunar.Dominio;

namespace CentralOperacoesLunar.Interfaces;

public interface IHistoricoServico
{
    void Registrar(RegistroHistorico registro);
    IReadOnlyList<RegistroHistorico> ConsultarTodos();
}
