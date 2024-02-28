using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.StateMachines
{
    public interface IExitableState
    {
        UniTask Exit();
    }

    public interface IState : IExitableState
    {
        UniTaskVoid Enter();
    }
}