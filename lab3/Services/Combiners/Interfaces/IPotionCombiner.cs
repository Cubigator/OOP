using lab3.Model.Potions;

namespace lab3.Services.Combiners.Interfaces;

public interface IPotionCombiner
{
    public Heal Combine(Heal first, Heal second);
    public Invisibility Combine(Invisibility first, Invisibility second);
    public Speed Combine(Speed first, Speed second);
}