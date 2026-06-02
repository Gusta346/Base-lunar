using CentralOperacoesLunar.Estruturas;

namespace CentralOperacoesLunar.Dominio;

public sealed class SensorEnergia : SensorBase
{
    public SensorEnergia(CoordenadaLunar localizacao) : base("Sensor de Energia", localizacao)
    {
    }
}
