using CodeBase.Infrastructure.Services.AsyncOperations;
using CodeBase.Modules.InputModule;
using Cysharp.Threading.Tasks;

namespace CodeBase.Modules.CoreModule.StateMachine
{
    public class RunState : ICoreState
    {
        private readonly IInputService _inputService;
        private readonly AsyncOperationsService _asyncOperationsService;
        private readonly ServiceHandler _serviceHandler;

        public RunState(
            IInputService inputService, 
            AsyncOperationsService asyncOperationsService, 
            ServiceHandler serviceHandler)
        {
            _inputService = inputService;
            _asyncOperationsService = asyncOperationsService;
            _serviceHandler = serviceHandler;
        }
        
        public UniTaskVoid Enter()
        {
            _serviceHandler.Run();
            _inputService.SetEnable(true);
            
            return default;
        }

        public UniTask Exit()
        {
            _serviceHandler.End();
            _asyncOperationsService.CancelAllWorkingTokens();
            return UniTask.CompletedTask;
        }
    }
}