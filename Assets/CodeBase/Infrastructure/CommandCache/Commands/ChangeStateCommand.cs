using CodeBase.Infrastructure.CommandCache.Commands.Args;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.StateMachines.Game.States.Types;

namespace CodeBase.Infrastructure.CommandCache.Commands
{
    public class ChangeStateCommand<TState> : CacheCommand<NullArgs, InfrastructureServiceHolder>
        where TState : IGameState
    {
        private InfrastructureServiceHolder _services;

        public override void InitServices(InfrastructureServiceHolder services)
        {
            _services = services;
        }

        protected override void InitArgsInternal(NullArgs args){ }

        protected override void PerformInternal()
        {
            _services.GameStateMachine.Enter<TState>();
        }
    }
}