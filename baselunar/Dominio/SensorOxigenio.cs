using CentralOperacoesLunar.Estruturas;

namespace CentralOperacoesLunar.Dominio;

public sealed class SensorOxigenio : SensorBase
{
    public SensorOxigenio(CoordenadaLunar localizacao) : base("Sensor de Oxigênio", localizacao)
    {
    }
}
