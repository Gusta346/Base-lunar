# Central de Operações Lunar

# integrantes
GUSTAVO OLIVEIRA RIBEIRO     RM- 559163
GABRIEL VASQUEZ				 RM-
AUGUSTO DOUGLAS				 RM-


## Objetivo
Simular a rotina de uma base lunar por meio de um console interativo, com ocorrências diárias, tomada de decisão, histórico e relatório final.

## Motivação
O projeto foi desenvolvido para demonstrar organização de código, orientação a objetos, desacoplamento, fluxo de eventos e experiência de console.

## Tecnologias utilizadas
- C#
- .NET 10
- Aplicação Console

## Estrutura do projeto
- Aplicacao: coordenação do fluxo principal e interface do operador.
- Dominio: entidades, robôs, ocorrências, estado da base e histórico.
- Servicos: monitoramento, resolução, histórico, notificação e injeção de dependência.
- Interfaces: contratos de abstração.
- Utilitarios: formatação e apoio ao console.
- Estruturas: struct obrigatória da simulação.

## Como executar
1. Abrir a solução no Visual Studio.
2. Restaurar os pacotes, se necessário.
3. Executar o projeto baselunar.
4. Utilizar o menu principal para avançar dias e acompanhar os eventos.

## Arquitetura
A aplicação segue uma organização em camadas, com separação entre domínio, serviços, interfaces e apresentação. A classe principal é parcial para distribuir responsabilidades de execução e suporte.

## Diagrama de fluxo textual
1. Iniciar sistema.
2. Exibir menu principal.
3. Escolher ação.
4. Se for avançar dia, gerar estado do dia.
5. Verificar continuidade de eventos anteriores.
6. Sortear ocorrência ou mensagem de rotina.
7. Se houver ocorrência, permitir escolha de robô ou ignorar.
8. Aplicar sucesso, falha, agravamento ou novo evento.
9. Registrar histórico.
10. Verificar condições de derrota.
11. Exibir status ou histórico quando solicitado.
12. Encerrar ao atingir condição de derrota ou decisão do operador.

## Evidências de execução
### Exemplo de tela inicial
==================================================
CENTRAL DE OPERAÇÕES LUNAR
==========================

1 - Avançar dia

2 - Visualizar robôs

3 - Consultar histórico

4 - Status da base

5 - Encerrar sistema

Selecione uma opção:

### Exemplo de ocorrência
==================================================
DIA 15
======

Ocorrência Detectada:

Falha no gerador principal

Ação necessária:

1 - Enviar Robô Alfa

2 - Enviar Robô Beta

3 - Enviar Robô Gama

4 - Ignorar ocorrência

Escolha uma opção:

### Exemplo de sucesso
[RESULTADO] Robô Alfa concluiu a ação com sucesso.

### Exemplo de falha
[RESULTADO] Robô Beta não conseguiu resolver a ocorrência.

### Exemplo de relatório final
RELATÓRIO FINAL

Motivo: 3 ocorrências críticas foram ignoradas consecutivamente.
Dias executados: 9
Falhas críticas acumuladas: 2
Ocorrências críticas ignoradas consecutivamente: 3
Data de encerramento: 01/07/2026 12:40
