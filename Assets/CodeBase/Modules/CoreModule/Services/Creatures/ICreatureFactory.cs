using Cysharp.Threading.Tasks;

namespace CodeBase.Modules.CoreModule.Creatures
{
    public interface ICreatureFactory
    {
        UniTask<ICreature> Create(CreatureDefinition player);
    }
}