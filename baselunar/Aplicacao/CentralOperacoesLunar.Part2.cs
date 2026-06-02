using CentralOperacoesLunar.Dominio;
using CentralOperacoesLunar.Utilitarios;

namespace CentralOperacoesLunar.Aplicacao;

public partial class CentralOperacoesLunar
{
    private void AvancarDia()
    {
        _estadoBase.AvancarDia();
        DateTime dataHoraAtual = _estadoBase.DataDoDia.AddHours(8).AddMinutes(_aleatorio.Next(0, 59));

        ExibirCabecalhoDia();

        foreach (var consequencia in _estadoBase.ObterConsequenciasDoDia())
        {
            ExibirMensagemCategoria("CONTINUIDADE", consequencia.Mensagem);
            consequencia.Efeito?.Invoke(_estadoBase);
            _estadoBase.RemoverConsequencia(consequencia);
            RegistrarHistorico(TipoEventoHistorico.Continuacao, consequencia.Mensagem, "Ajuste interno aplicado", "Conseqüência processada");
        }

        Ocorrencia? ocorrencia = _dependencias.Monitoramento.GerarOcorrencia(dataHoraAtual);

        if (ocorrencia is null)
        {
            string mensagem = _dependencias.Monitoramento.GerarMensagemSemOcorrencia();
            ExibirMensagemCategoria("ROTINA", mensagem);
            RegistrarHistorico(TipoEventoHistorico.Normal, "Sem ocorrência", "Nenhuma ação necessária", mensagem);
        }
        else
        {
            ExibirOcorrencia(ocorrencia);
            RegistrarHistorico(TipoEventoHistorico.Ocorrencia, ocorrencia.Nome, "Aguardando ação do operador", ocorrencia.Descricao);
            ResolverOcorrencia(ocorrencia, dataHoraAtual);
        }

        if (CatalogoOcorrencias.DeveOcorrerEventoPositivo(_aleatorio))
        {
            string eventoPositivo = CatalogoOcorrencias.ObterEventoPositivo(_aleatorio);
            ExibirMensagemCategoria("EVENTO POSITIVO", eventoPositivo);
            _estadoBase.AplicarEventoPositivo();
            RegistrarHistorico(TipoEventoHistorico.Positivo, eventoPositivo, "Apoio operacional ampliado", "Impacto positivo aplicado");
        }

        AvaliarCondicaoDerrota();

        if (_estadoBase.SistemaEncerrado)
        {
            return;
        }

        ExibirStatusDaBase();
        AguardarEntrada();
    }

    private void ExibirCabecalhoDia()
    {
        Console.WriteLine();
        Console.WriteLine(global::CentralOperacoesLunar.Utilitarios.FormatoConsole.LinhaSeparadora);
        Console.WriteLine($"DIA {_estadoBase.DiaAtual}");
        Console.WriteLine(new string('=', 6 + _estadoBase.DiaAtual.ToString().Length));
        Console.WriteLine();
    }

    private void ExibirOcorrencia(Ocorrencia ocorrencia)
    {
        Console.WriteLine("Ocorrência Detectada:");
        Console.WriteLine();
        Console.WriteLine(ocorrencia.Nome);
        Console.WriteLine();
        Console.WriteLine(ocorrencia.Descricao);
        Console.WriteLine();
        Console.WriteLine("Ação necessária:");
        Console.WriteLine();
        Console.WriteLine("1 - Enviar Robô Alfa (Manutenção)");
        Console.WriteLine();
        Console.WriteLine("2 - Enviar Robô Beta (Transporte)");
        Console.WriteLine();
        Console.WriteLine("3 - Enviar Robô Gama (Exploração)");
        Console.WriteLine();
        Console.WriteLine("4 - Ignorar ocorrência");
        Console.WriteLine();
    }

    private void ResolverOcorrencia(Ocorrencia ocorrencia, DateTime dataHora)
    {
        string opcao = _dependencias.ImpressaoConsole.LerOpcao("Escolha uma opção: ");
        RoboBase? roboSelecionado = opcao.Trim() switch
        {
            "1" => _dependencias.Robos[0],
            "2" => _dependencias.Robos[1],
            "3" => _dependencias.Robos[2],
            "4" => null,
            _ => throw new FormatException()
        };

        if (roboSelecionado is null)
        {
            string mensagem = "A ocorrência foi ignorada pelo operador.";
            _estadoBase.RegistrarOmissaoCritica();
            _estadoBase.AplicarAgravamento(ocorrencia.Severidade);
            RegistrarHistorico(TipoEventoHistorico.Resolucao, ocorrencia.Nome, "Ocorrência ignorada", mensagem);
            _estadoBase.AgendarConsequencia(new ConsequenciaFutura(_estadoBase.DiaAtual + 1, "As condições anteriores continuaram afetando os módulos auxiliares.", estado => estado.AplicarAgravamento(ocorrencia.Severidade)));
            ExibirMensagemCategoria("RESULTADO", mensagem);
            return;
        }

        ResultadoResolucao resultado = ResolverComEspecialidade(ocorrencia, roboSelecionado);

        switch (resultado)
        {
            case ResultadoResolucao.Sucesso:
                _estadoBase.ReiniciarSequenciaDeOmissao();
                _estadoBase.AplicarSucesso(ocorrencia.Severidade);
                RegistrarHistorico(TipoEventoHistorico.Resolucao, ocorrencia.Nome, roboSelecionado.Nome, "Ocorrência resolvida com sucesso");
                _estadoBase.AgendarConsequencia(new ConsequenciaFutura(_estadoBase.DiaAtual + 1, "Reparo concluído com sucesso e sistemas estabilizados.", estado => estado.AplicarSucesso(ocorrencia.Severidade)));
                ExibirMensagemCategoria("RESULTADO", $"{roboSelecionado.Nome} concluiu a ação com sucesso.");
                break;
            case ResultadoResolucao.Parcial:
                _estadoBase.AplicarAgravamento(ocorrencia.Severidade);
                RegistrarHistorico(TipoEventoHistorico.Resolucao, ocorrencia.Nome, roboSelecionado.Nome, "A especialidade do robô não era a ideal, solução parcial aplicada");
                _estadoBase.AgendarConsequencia(new ConsequenciaFutura(_estadoBase.DiaAtual + 1, "A ocorrência foi parcialmente tratada, mas ainda exige atenção.", estado => estado.AplicarAgravamento(ocorrencia.Severidade)));
                ExibirMensagemCategoria("RESULTADO", $"{roboSelecionado.Nome} realizou apenas uma correção parcial.");
                break;
            case ResultadoResolucao.Falha:
                _estadoBase.AplicarFalha(ocorrencia.Severidade);
                RegistrarHistorico(TipoEventoHistorico.Resolucao, ocorrencia.Nome, roboSelecionado.Nome, "A tentativa de resolução falhou");
                _estadoBase.AgendarConsequencia(new ConsequenciaFutura(_estadoBase.DiaAtual + 1, "A falha anterior causou danos adicionais aos sistemas auxiliares.", estado => estado.AplicarFalha(ocorrencia.Severidade)));
                ExibirMensagemCategoria("RESULTADO", $"{roboSelecionado.Nome} não conseguiu resolver a ocorrência.");
                break;
            case ResultadoResolucao.Agravamento:
                _estadoBase.AplicarAgravamento(ocorrencia.Severidade);
                RegistrarHistorico(TipoEventoHistorico.Resolucao, ocorrencia.Nome, roboSelecionado.Nome, "A ocorrência agravou durante a tentativa de solução");
                _estadoBase.AgendarConsequencia(new ConsequenciaFutura(_estadoBase.DiaAtual + 2, "Oscilações continuam afetando a base.", estado => estado.AplicarAgravamento(ocorrencia.Severidade)));
                ExibirMensagemCategoria("RESULTADO", "A situação agravou durante a operação.");
                break;
            case ResultadoResolucao.NovoEvento:
                _estadoBase.ReiniciarSequenciaDeOmissao();
                _estadoBase.AplicarSucesso(ocorrencia.Severidade);
                RegistrarHistorico(TipoEventoHistorico.Resolucao, ocorrencia.Nome, roboSelecionado.Nome, "Novo evento positivo desencadeado");
                _estadoBase.AgendarConsequencia(new ConsequenciaFutura(_estadoBase.DiaAtual + 1, "Nova área explorada com êxito.", estado => estado.AplicarEventoPositivo()));
                ExibirMensagemCategoria("RESULTADO", "Nova descoberta gerou uma oportunidade adicional.");
                break;
            default:
                _estadoBase.AplicarFalha(ocorrencia.Severidade);
                RegistrarHistorico(TipoEventoHistorico.Resolucao, ocorrencia.Nome, roboSelecionado.Nome, "Resultado indefinido tratado como falha");
                ExibirMensagemCategoria("RESULTADO", "A central não conseguiu interpretar a ação aplicada.");
                break;
        }
    }

    private void VisualizarRobos()
    {
        Console.WriteLine();
        Console.WriteLine("ROBÔS DISPONÍVEIS");
        Console.WriteLine();

        foreach (var robo in _dependencias.Robos)
        {
            Console.WriteLine(robo.Descrever());
        }

        Console.WriteLine();
        Console.WriteLine("MANUTENÇÃO");
        Console.WriteLine();
        Console.WriteLine("1 - Realizar manutenção em todos os robôs");
        Console.WriteLine();
        string opcaoManutencao = _dependencias.ImpressaoConsole.LerOpcao("Selecione uma opção de manutenção ou pressione ENTER para voltar: ");

        if (opcaoManutencao.Trim() == "1")
        {
            foreach (var robo in _dependencias.Robos)
            {
                Console.WriteLine(robo.RealizarManutencao());
            }

            Console.WriteLine();
        }

        AguardarEntrada();
    }

    private void ConsultarHistorico()
    {
        Console.WriteLine();
        Console.WriteLine("HISTÓRICO DA CENTRAL");
        Console.WriteLine();

        var registros = _dependencias.Historico.ConsultarTodos();

        if (registros.Count == 0)
        {
            Console.WriteLine("Nenhum registro disponível.");
        }
        else
        {
            foreach (var registro in registros)
            {
                Console.WriteLine(registro.Resumir());
            }
        }

        Console.WriteLine();
        AguardarEntrada();
    }

    private void ExibirStatusDaBase()
    {
        Console.WriteLine();
        Console.WriteLine("STATUS DA BASE");
        Console.WriteLine();
        Console.WriteLine(_estadoBase.ObterResumoStatus());
        Console.WriteLine();
        AguardarEntrada();
    }

    private void EncerrarSistemaManual()
    {
        _estadoBase.EncerrarSistema();
        RegistrarHistorico(TipoEventoHistorico.Encerramento, "Encerramento manual", "Operador finalizou a sessão", "Sistema encerrado com sucesso");
        ExibirRelatorioFinal("Encerramento manual solicitado pelo operador.");
        AguardarEntrada();
    }

    private void AvaliarCondicaoDerrota()
    {
        if (_estadoBase.OcorrenciasCriticasIgnoradasConsecutivas >= 3)
        {
            _estadoBase.EncerrarSistema();
            ExibirRelatorioFinal("3 ocorrências críticas foram ignoradas consecutivamente.");
        }

        if (_estadoBase.FalhasCriticasAcumuladas >= 5)
        {
            _estadoBase.EncerrarSistema();
            ExibirRelatorioFinal("5 falhas críticas foram acumuladas.");
        }
    }

    private void ExibirRelatorioFinal(string motivo)
    {
        var relatorio = new RelatorioFinal
        {
            DataHoraEncerramento = DateTime.Now,
            DiasExecutados = _estadoBase.DiaAtual,
            FalhasCriticas = _estadoBase.FalhasCriticasAcumuladas,
            OcorrenciasCriticasIgnoradasConsecutivas = _estadoBase.OcorrenciasCriticasIgnoradasConsecutivas,
            MotivoEncerramento = motivo,
            Historico = _dependencias.Historico.ConsultarTodos()
        };

        Console.WriteLine();
        Console.WriteLine("RELATÓRIO FINAL");
        Console.WriteLine();
        Console.WriteLine($"Motivo: {relatorio.MotivoEncerramento}");
        Console.WriteLine($"Dias executados: {relatorio.DiasExecutados}");
        Console.WriteLine($"Falhas críticas acumuladas: {relatorio.FalhasCriticas}");
        Console.WriteLine($"Ocorrências críticas ignoradas consecutivamente: {relatorio.OcorrenciasCriticasIgnoradasConsecutivas}");
        Console.WriteLine($"Data de encerramento: {relatorio.DataHoraEncerramento:dd/MM/yyyy HH:mm}");
        Console.WriteLine();

        Console.WriteLine("Últimos registros:");
        Console.WriteLine();

        foreach (var registro in relatorio.Historico.TakeLast(5))
        {
            Console.WriteLine(registro.Resumir());
        }

    }

    private void AguardarEntrada()
    {
        Console.WriteLine("Pressione ENTER para continuar...");
        Console.ReadLine();
    }

    private ResultadoResolucao ResolverComEspecialidade(Ocorrencia ocorrencia, RoboBase roboSelecionado)
    {
        bool especialidadeCorreta = ocorrencia.Severidade switch
        {
            TipoSeveridadeOcorrencia.Critica => roboSelecionado is RoboAlfa,
            TipoSeveridadeOcorrencia.Media => roboSelecionado is RoboBeta,
            TipoSeveridadeOcorrencia.Leve => roboSelecionado is RoboGama,
            _ => false
        };

        if (!especialidadeCorreta)
        {
            return ResultadoResolucao.Parcial;
        }

        return _dependencias.ResolucaoOcorrencia.Resolver(ocorrencia, roboSelecionado, _estadoBase);
    }

    private void RegistrarHistorico(TipoEventoHistorico tipoEvento, string ocorrencia, string acao, string resultado)
    {
        _dependencias.Historico.Registrar(new RegistroHistorico(DateTime.Now, _estadoBase.DiaAtual, tipoEvento, ocorrencia, acao, resultado));
    }

    private void ExibirMensagemCategoria(string categoria, string mensagem)
    {
        Console.WriteLine();
        Console.WriteLine($"[{categoria}] {mensagem}");
        Console.WriteLine();
    }
}
