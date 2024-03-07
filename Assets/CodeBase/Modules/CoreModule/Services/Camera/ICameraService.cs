using CodeBase.Modules.CoreModule.Creatures;
using Cysharp.Threading.Tasks;

namespace CodeBase.Modules.CoreModule
{
    public interface ICameraService
    {
        UniTask FollowTo(ICreature creature);
    }

    public interface ILoadableService
    {
        UniTask Load();
    }

    public interface IPrewarmService
    {
        void Prewarm();
    }
}