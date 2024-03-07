using CodeBase.Modules.CoreModule.Creatures;

namespace CodeBase.Modules.CoreModule.Services.Creatures.Components.Base
{
    public interface IFractionCreature : ICoreComponent
    {
        CreatureDefinition Fraction { get; }
    }
}