# Central de Operações Lunar

![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=for-the-badge&logo=dotnet)
![C#](https://img.shields.io/badge/C%23-Console-239120?style=for-the-badge&logo=csharp)
![Status](https://img.shields.io/badge/Status-Em%20desenvolvimento-yellow?style=for-the-badge)

## Sumário

- [Sobre o projeto](#sobre-o-projeto)
- [Objetivo](#objetivo)
- [Motivação](#motivação)
- [Tecnologias utilizadas](#tecnologias-utilizadas)
- [Estrutura do projeto](#estrutura-do-projeto)
- [Funcionalidades](#funcionalidades)
- [Robôs da base](#robôs-da-base)
- [Como executar](#como-executar)
- [Capturas de tela](#capturas-de-tela)
- [Arquitetura](#arquitetura)
- [Requisitos atendidos](#requisitos-atendidos)

## Sobre o projeto

A **Central de Operações Lunar** é uma simulação interativa em **C# / .NET 10 Console** sobre o monitoramento de uma base lunar.

O usuário assume o papel de operador da central e precisa acompanhar ocorrências, tomar decisões, resolver problemas e manter a base em funcionamento.

## Objetivo

Criar uma experiência de console organizada e imersiva, com eventos diários, continuidade de acontecimentos, histórico e relatório final.

## Motivação

O projeto foi desenvolvido para praticar:

- Programação orientada a objetos
- Herança e polimorfismo
- Abstração e interfaces
- Injeção de dependência
- Tratamento de exceções
- Organização modular do código

## Tecnologias utilizadas

- C#
- .NET 10
- Aplicação Console

## Estrutura do projeto

- **Aplicacao**: fluxo principal da central e interface com o operador
- **Dominio**: robôs, ocorrências, estado da base, histórico e relatório
- **Servicos**: monitoramento, resolução, notificação e histórico
- **Interfaces**: contratos para desacoplamento
- **Utilitarios**: formatação e apoio ao console
- **Estruturas**: struct `CoordenadaLunar`

## Funcionalidades

- Avanço de dias na base lunar
- Geração aleatória de ocorrências
- Ocorrências críticas, médias e leves
- Eventos positivos raros
- Resolução com robôs especializados
- Manutenção de robôs
- Histórico completo com data e hora
- Relatório final de encerramento
- Condições de derrota por falhas acumuladas ou ocorrências ignoradas

## Robôs da base

### Robô Alfa
**Especialidade:** Manutenção

Responsável por:
- Reparar painéis solares
- Reparar geradores
- Reparar antenas
- Reparar sensores

### Robô Beta
**Especialidade:** Transporte

Responsável por:
- Transporte de suprimentos
- Entrega de peças
- Movimentação de equipamentos

### Robô Gama
**Especialidade:** Exploração

Responsável por:
- Investigar anomalias
- Explorar novas regiões
- Buscar recursos

## Como executar

1. Abra a solução no Visual Studio.
2. Restaure os pacotes, se necessário.
3. Execute o projeto `baselunar`.
4. Use o menu principal para avançar os dias e acompanhar os eventos.

## Capturas de tela

### Menu principal
