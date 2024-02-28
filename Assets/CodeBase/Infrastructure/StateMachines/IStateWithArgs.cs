using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.StateMachines
{
    public interface IStateWithArgs<TArgs> : IExitableState
    {
        UniTaskVoid Enter(TArgs args);
    }
}