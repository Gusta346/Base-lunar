using CentralOperacoesLunar.Estruturas;

namespace CentralOperacoesLunar.Dominio;

public abstract class RoboBase
{
    protected RoboBase(string nome, string especialidade, CoordenadaLunar localizacao)
    {
        Nome = nome;
        Especialidade = especialidade;
        Localizacao = localizacao;
        Energia = 100;
    }

    public string Nome { get; }
    public string Especialidade { get; }
    public CoordenadaLunar Localizacao { get; }
    public int Energia { get; private set; }
    public bool Operacional => Energia > 0;

    public virtual string Descrever()
    {
        return $"{Nome} | Especialidade: {Especialidade} | Energia: {Energia}% | Posição: {Localizacao.Linha},{Localizacao.Coluna}";
    }

    public virtual string RealizarManutencao()
    {
        Energia = 100;
        return $"{Nome} recebeu manutenção e voltou à carga máxima.";
    }

    public abstract ResultadoResolucao Responder(Ocorrencia ocorrencia, EstadoBaseLunar estadoBase);

    protected void ConsumirEnergia(int quantidade)
    {
        Energia = Math.Max(0, Energia - quantidade);
    }

    protected void RecuperarEnergia(int quantidade)
    {
        Energia = Math.Min(100, Energia + quantidade);
    }
}
