using lab3.Model.Armors;

namespace lab3.Services.Combiners.Interfaces;

public interface IArmorCombiner
{
    public Boots Combine(Boots first, Boots second);
    public Chainmail Combine(Chainmail first, Chainmail second);
    public Helmet Combine(Helmet first, Helmet second);
    public Shield Combine(Shield first, Shield second);
}