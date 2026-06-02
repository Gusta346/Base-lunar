using CentralOperacoesLunar.Dominio;
using CentralOperacoesLunar.Interfaces;
using CentralOperacoesLunar.Servicos;
using CentralOperacoesLunar.Utilitarios;

namespace CentralOperacoesLunar.Aplicacao;

public partial class CentralOperacoesLunar
{
    private readonly FabricaDependencias _dependencias;
    private readonly EstadoBaseLunar _estadoBase;
    private readonly Random _aleatorio;

    public CentralOperacoesLunar()
    {
        _dependencias = new FabricaDependencias();
        _estadoBase = new EstadoBaseLunar(DateTime.Now.Date);
        _aleatorio = Random.Shared;
    }

    public void Executar()
    {
        bool continuar = true;

        while (continuar && !_estadoBase.SistemaEncerrado)
        {
            try
            {
                ExibirCabecalhoPrincipal();
                ExibirMenuPrincipal();
                string opcao = _dependencias.ImpressaoConsole.LerOpcao("Selecione uma opção: ");
                continuar = ProcessarOpcaoPrincipal(opcao);
            }
            catch (FormatException)
            {
                ExibirMensagemErro("Entrada inválida. Informe apenas números correspondentes ao menu.");
            }
            catch (Exception ex)
            {
                ExibirMensagemErro($"Erro inesperado: {ex.Message}");
            }
        }
    }

    private bool ProcessarOpcaoPrincipal(string opcao)
    {
        switch (opcao.Trim())
        {
            case "1":
                AvancarDia();
                return true;
            case "2":
                VisualizarRobos();
                return true;
            case "3":
                ConsultarHistorico();
                return true;
            case "4":
                ExibirStatusDaBase();
                return true;
            case "5":
                EncerrarSistemaManual();
                return false;
            default:
                ExibirMensagemErro("Opção inexistente. Tente novamente.");
                return true;
        }
    }

    private void ExibirCabecalhoPrincipal()
    {
        global::CentralOperacoesLunar.Utilitarios.FormatoConsole.LimparTela();
        global::CentralOperacoesLunar.Utilitarios.FormatoConsole.EscreverTitulo("CENTRAL DE OPERAÇÕES LUNAR");
    }

    private static void ExibirMenuPrincipal()
    {
        Console.WriteLine("1 - Avançar dia");
        Console.WriteLine();
        Console.WriteLine("2 - Visualizar robôs");
        Console.WriteLine();
        Console.WriteLine("3 - Consultar histórico");
        Console.WriteLine();
        Console.WriteLine("4 - Status da base");
        Console.WriteLine();
        Console.WriteLine("5 - Encerrar sistema");
        Console.WriteLine();
    }

    private void ExibirMensagemErro(string mensagem)
    {
        Console.WriteLine();
        Console.WriteLine($"[ERRO] {mensagem}");
        Console.WriteLine("Pressione ENTER para continuar...");
        Console.ReadLine();
    }
}
