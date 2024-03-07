using Cysharp.Threading.Tasks;

namespace CodeBase.Modules.CoreModule.Services.Creatures
{
    public interface ICreatureFactory
    {
        UniTask<ICreature> Create(CreatureDefinition player);
    }
}