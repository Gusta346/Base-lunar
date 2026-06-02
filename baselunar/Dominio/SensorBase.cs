using CentralOperacoesLunar.Estruturas;

namespace CentralOperacoesLunar.Dominio;

public abstract class SensorBase : EquipamentoBase
{
    protected SensorBase(string nome, CoordenadaLunar localizacao) : base(nome, localizacao)
    {
    }

    public bool AlertaAtivo { get; private set; }

    public void AtivarAlerta() => AlertaAtivo = true;
    public void LimparAlerta() => AlertaAtivo = false;
}
