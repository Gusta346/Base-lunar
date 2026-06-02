using CentralOperacoesLunar.Dominio;
using CentralOperacoesLunar.Interfaces;

namespace CentralOperacoesLunar.Servicos;

public sealed class HistoricoServico : IHistoricoServico
{
    private readonly List<RegistroHistorico> _registros = new();

    public void Registrar(RegistroHistorico registro) => _registros.Add(registro);

    public IReadOnlyList<RegistroHistorico> ConsultarTodos() => _registros;
}
