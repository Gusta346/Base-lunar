namespace CentralOperacoesLunar.Interfaces;

public interface IImpressaoConsole
{
    void EscreverLinha(string mensagem = "");
    void EscreverBloco(string titulo, IEnumerable<string> linhas);
    string LerOpcao(string mensagem);
}
