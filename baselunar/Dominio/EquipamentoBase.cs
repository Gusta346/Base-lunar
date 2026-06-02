using CentralOperacoesLunar.Estruturas;

namespace CentralOperacoesLunar.Dominio;

public abstract class EquipamentoBase
{
    protected EquipamentoBase(string nome, CoordenadaLunar localizacao)
    {
        Nome = nome;
        Localizacao = localizacao;
        Funcional = true;
    }

    public string Nome { get; }
    public CoordenadaLunar Localizacao { get; }
    public bool Funcional { get; private set; }
    public int Desgaste { get; private set; }

    public virtual void SofrerDano(int intensidade)
    {
        Desgaste = Math.Min(100, Desgaste + intensidade);
        if (Desgaste >= 75)
        {
            Funcional = false;
        }
    }

    public virtual string Reparar()
    {
        Desgaste = 0;
        Funcional = true;
        return $"{Nome} voltou a operar normalmente.";
    }
}
