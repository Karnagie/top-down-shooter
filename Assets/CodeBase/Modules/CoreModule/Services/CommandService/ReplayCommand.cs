using CodeBase.Infrastructure.CommandCache;
using CodeBase.Infrastructure.CommandCache.Commands.Args;
using CodeBase.Modules.CoreModule.StateMachine;

namespace CodeBase.Modules.CoreModule.Services.CommandService
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