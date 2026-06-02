# 🌕 Central de Operações Lunar

Sistema desenvolvido em **C# e .NET Console** que simula o gerenciamento de uma base lunar. O jogador assume o papel de operador da central de operações e deve monitorar sistemas, resolver ocorrências e tomar decisões estratégicas para garantir a sobrevivência da colônia.

---

# 👨‍💻 Integrantes

| Nome                     | RM        |
| ------------------------ | --------- |
| Gustavo Oliveira Ribeiro | RM 559163 |
| Gabriel Vasquez          | RM 557056 |
| Augusto Douglas          | RM 558371 |

---

# 🚀 Sobre o Projeto

A **Central de Operações Lunar** é uma simulação interativa baseada em eventos. Durante a execução, a base lunar enfrenta situações inesperadas que exigem intervenção do operador.

O sistema foi desenvolvido com foco em:

* Programação Orientada a Objetos (POO)
* Arquitetura em Camadas
* Desacoplamento entre componentes
* Injeção de Dependência
* Simulação baseada em eventos
* Organização e reutilização de código

O objetivo é manter a base operacional pelo maior número possível de dias, evitando falhas críticas que possam comprometer a missão.

---

# 🎯 Objetivo da Simulação

O operador é responsável por:

* Monitorar o estado da base lunar.
* Resolver ocorrências técnicas.
* Selecionar robôs para execução de tarefas.
* Acompanhar eventos anteriores.
* Consultar o histórico de operações.
* Tomar decisões estratégicas.
* Evitar o colapso da colônia.

Cada escolha realizada pode influenciar diretamente os acontecimentos futuros.

---

# ⚙️ Como Funciona

A simulação ocorre em ciclos diários.

A cada novo dia:

1. O estado da base é atualizado.
2. Eventos pendentes podem continuar ou se agravar.
3. Uma nova ocorrência pode ser gerada.
4. O operador recebe informações sobre a situação.
5. Uma decisão deve ser tomada:

   * Enviar um robô para resolver o problema.
   * Ignorar a ocorrência.
6. O sistema processa o resultado da ação.
7. O histórico é atualizado.
8. O status geral da base é reavaliado.

Caso muitas falhas críticas se acumulem, a missão poderá ser encerrada.

---

# 🤖 Sistema de Robôs

A base conta com robôs especializados para auxiliar na manutenção dos sistemas.

Os robôs podem ser utilizados para:

* Reparos estruturais.
* Correção de falhas energéticas.
* Manutenção de equipamentos.
* Resolução de emergências.

Dependendo da ocorrência, determinados robôs podem apresentar melhor desempenho.

---

# ⚠️ Sistema de Ocorrências

Diversos eventos podem ocorrer durante a operação da base, como:

* Falha no gerador principal.
* Pane nos sistemas de comunicação.
* Problemas em sensores.
* Vazamento de oxigênio.
* Falhas em módulos habitacionais.
* Eventos críticos acumulados.

Ocorrências ignoradas podem gerar consequências mais graves nos dias seguintes.

---

# 📊 Condições de Derrota

A simulação pode ser encerrada quando:

* Muitas falhas críticas são acumuladas.
* Ocorrências importantes são ignoradas repetidamente.
* A operação da base torna-se inviável.

Ao final, o sistema gera um relatório completo da missão.

---

# 🏗️ Tecnologias Utilizadas

* C#
* .NET 10
* Aplicação Console
* Programação Orientada a Objetos (POO)
* Injeção de Dependência
* Arquitetura em Camadas

---

# 📁 Estrutura do Projeto

## Aplicacao

Responsável pelo fluxo principal da simulação e interação com o operador.

## Dominio

Contém as entidades, robôs, ocorrências, estado da base e histórico.

## Servicos

Implementa as regras de negócio e processamento dos eventos.

## Interfaces

Define contratos utilizados para abstração dos componentes.

## Estruturas

Contém a estrutura (struct) obrigatória utilizada na simulação.

## Utilitarios

Funções auxiliares de exibição e formatação.

---

# ▶️ Como Executar

## Pré-requisitos

* Visual Studio 2022 ou superior
* .NET 10 SDK

## Passos

1. Clone o repositório:

```bash
git clone https://github.com/Gusta346/Base-lunar.git
```

2. Abra a solução no Visual Studio.

3. Compile o projeto.

4. Execute a aplicação.

5. Utilize o menu principal para interagir com a Central de Operações Lunar.

---

# 📸 Evidências da Aplicação

## Tela Inicial

*Inserir captura da tela inicial da aplicação.*

![Tela Inicial](Imagens/tela-inicial.png)

---

## Menu Principal

*Inserir captura do menu principal.*

![Menu Principal](Imagens/menu-principal.png)

---

## Visualização dos Robôs

*Inserir captura mostrando os robôs disponíveis.*

![Robôs](Imagens/robos.png)

---

## Ocorrência Detectada

*Inserir captura de uma ocorrência gerada pelo sistema.*

![Ocorrência](Imagens/ocorrencia.png)

---

## Resolução de Ocorrência

*Inserir captura da escolha de um robô para resolver uma situação.*

![Resolução](Imagens/resolucao.png)

---

## Histórico de Eventos

*Inserir captura da tela de histórico.*

![Histórico](Imagens/historico.png)

---

## Status da Base

*Inserir captura do status atual da base lunar.*

![Status da Base](Imagens/status-base.png)

---

## Relatório Final

*Inserir captura do relatório gerado ao término da simulação.*

![Relatório Final](Imagens/relatorio-final.png)

---

# 🖥️ Exemplo de Menu

```text
==================================================
CENTRAL DE OPERAÇÕES LUNAR
==================================================

1 - Avançar Dia
2 - Visualizar Robôs
3 - Consultar Histórico
4 - Status da Base
5 - Encerrar Sistema

Selecione uma opção:
```

---

# 🔧 Exemplo de Ocorrência

```text
==================================================
DIA 15
==================================================

Ocorrência Detectada:

Falha no Gerador Principal

Ação Necessária:

1 - Enviar Robô Alfa
2 - Enviar Robô Beta
3 - Enviar Robô Gama
4 - Ignorar Ocorrência

Escolha uma opção:
```

---

# 📈 Exemplo de Relatório Final

```text
RELATÓRIO FINAL

Motivo:
3 ocorrências críticas foram ignoradas consecutivamente.

Dias executados: 9
Falhas críticas acumuladas: 2
Ocorrências críticas ignoradas consecutivamente: 3

Data de encerramento:
01/07/2026 12:40
```

---

# 🏛️ Arquitetura

A aplicação segue uma arquitetura em camadas com separação entre:

* Apresentação
* Domínio
* Serviços
* Interfaces
* Utilitários

Essa abordagem facilita a manutenção, evolução e reutilização do código.

---

# 📄 Licença

Projeto desenvolvido para fins acadêmicos.
