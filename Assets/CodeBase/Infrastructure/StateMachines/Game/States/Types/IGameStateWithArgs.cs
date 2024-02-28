namespace CodeBase.Infrastructure.StateMachines.Game.States.Types
{
    public interface IGameStateWithArgs<TArgs> : IExitableGameState, IStateWithArgs<TArgs>
    {
    }
}