namespace CentralOperacoesLunar.Dominio;

public static class CatalogoOcorrencias
{
    private static readonly string[] MensagensSemOcorrencia =
    [
        "Todos os sensores estão operando normalmente.",
        "Comunicação com a Terra está estável.",
        "Robô Alfa concluiu inspeção preventiva.",
        "Nenhuma anomalia detectada nas últimas 24 horas.",
        "Sistema de suporte à vida funcionando normalmente.",
        "Reservas de energia permanecem estáveis.",
        "Painéis solares operando com eficiência máxima."
    ];

    private static readonly (string Nome, string Descricao)[] OcorrenciasCriticas =
    [
        ("Vazamento de oxigênio", "Queda brusca de pressão atmosférica em setor habitável."),
        ("Falha no gerador principal", "O núcleo energético principal parou de responder."),
        ("Perda de comunicação com a Terra", "Nenhum sinal está sendo recebido no canal principal."),
        ("Painel solar atingido por micrometeorito", "Uma fileira inteira de captação foi comprometida."),
        ("Incêndio em módulo secundário", "Aumento de temperatura detectado em compartimento técnico."),
        ("Falha no sistema de suporte à vida", "Os indicadores vitais da estação estão instáveis."),
        ("Colisão de equipamento automatizado", "Um veículo interno danificou estruturas sensíveis.")
    ];

    private static readonly (string Nome, string Descricao)[] OcorrenciasMedias =
    [
        ("Sensor fora de operação", "Um sensor essencial deixou de responder."),
        ("Bateria de robô descarregada", "Uma unidade robótica perdeu autonomia."),
        ("Oscilação energética", "A distribuição de energia está instável."),
        ("Falha em antena auxiliar", "O sistema de redundância apresenta falhas."),
        ("Pequeno vazamento detectado", "Há perda mínima de pressão em um compartimento."),
        ("Problema em módulo de armazenamento", "Parte dos suprimentos foi afetada.")
    ];

    private static readonly (string Nome, string Descricao)[] OcorrenciasLeves =
    [
        ("Inspeção preventiva necessária", "Uma revisão simples pode evitar falhas futuras."),
        ("Atualização de software pendente", "Um módulo precisa ser atualizado."),
        ("Limpeza dos painéis solares necessária", "Poerira lunar reduziu a eficiência."),
        ("Calibração de sensores recomendada", "Alguns sensores pedem ajuste fino."),
        ("Verificação de equipamentos de rotina", "Uma checagem padrão está agendada.")
    ];

    private static readonly string[] EventosPositivos =
    [
        "Descoberta de gelo subterrâneo",
        "Nova área explorada",
        "Missão científica concluída",
        "Nova rota de comunicação encontrada",
        "Equipamento experimental apresentou excelentes resultados"
    ];

    public static string ObterMensagemSemOcorrencia(Random sorteio)
    {
        return MensagensSemOcorrencia[sorteio.Next(MensagensSemOcorrencia.Length)];
    }

    public static Ocorrencia CriarOcorrenciaAleatoria(Random sorteio, DateTime dataHora)
    {
        int seletor = sorteio.Next(100);

        if (seletor < 18)
        {
            return CriarOcorrencia(OcorrenciasCriticas, TipoSeveridadeOcorrencia.Critica, sorteio, dataHora);
        }

        if (seletor < 44)
        {
            return CriarOcorrencia(OcorrenciasMedias, TipoSeveridadeOcorrencia.Media, sorteio, dataHora);
        }

        return CriarOcorrencia(OcorrenciasLeves, TipoSeveridadeOcorrencia.Leve, sorteio, dataHora);
    }

    public static bool DeveOcorrerEventoPositivo(Random sorteio) => sorteio.Next(100) < 7;

    public static string ObterEventoPositivo(Random sorteio)
    {
        return EventosPositivos[sorteio.Next(EventosPositivos.Length)];
    }

    private static Ocorrencia CriarOcorrencia((string Nome, string Descricao)[] baseOcorrencias, TipoSeveridadeOcorrencia severidade, Random sorteio, DateTime dataHora)
    {
        var item = baseOcorrencias[sorteio.Next(baseOcorrencias.Length)];
        return new Ocorrencia(item.Nome, item.Descricao, severidade, dataHora);
    }
}
