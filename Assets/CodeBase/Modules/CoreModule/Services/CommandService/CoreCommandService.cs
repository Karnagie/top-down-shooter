using CodeBase.Infrastructure.CommandCache;
using CodeBase.Modules.CoreModule.StateMachine;

namespace CodeBase.Modules.CoreModule.Services
{
    public class CoreServiceHolder : IServicesHolder
    {
        public CoreServiceHolder(CoreStateMachine coreStateMachine)
        {
            CoreStateMachine = coreStateMachine;
        }

        public CoreStateMachine CoreStateMachine { get; }
    }
}