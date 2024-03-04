using CodeBase.Infrastructure.CommandCache;
using CodeBase.Infrastructure.CommandCache.Commands.Args;
using CodeBase.Infrastructure.StateMachines.Game.States.Types;

namespace CodeBase.Modules.CoreModule.Services
{
    public class ReplayCommand : CacheCommand<NullArgs, CoreServiceHolder>
    {
        private CoreServiceHolder _services;

        public override void InitServices(CoreServiceHolder services)
        {
            _services = services;
        }

        protected override void InitArgsInternal(NullArgs args)
        {
            
        }

        protected override void PerformInternal()
        {
            _services.CoreStateMachine.Enter<InitializeState>();
        }
    }
}