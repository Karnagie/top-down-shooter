using CodeBase.Infrastructure.CommandCache;
using CodeBase.Infrastructure.StateMachines.Game;

namespace CodeBase.Infrastructure.Services
{
    public class InfrastructureServiceHolder : IServicesHolder
    {
        public ILogService LogService { get; }
        public GameStateMachine GameStateMachine { get; }

        public InfrastructureServiceHolder(ILogService logService, GameStateMachine gameStateMachine)
        {
            LogService = logService;
            GameStateMachine = gameStateMachine;
        }
    }
}