using CodeBase.Modules.CoreModule.Services.Creatures;
using Cysharp.Threading.Tasks;

namespace CodeBase.Modules.CoreModule.Services.Camera
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