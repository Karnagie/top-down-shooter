using CodeBase.Infrastructure.Services.AsyncOperations;
using CodeBase.Modules.CoreModule.StateMachine;
using CodeBase.Modules.InputModule;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Modules.CoreModule
{
    public class RunState : ICoreState
    {
        private readonly IInputService _inputService;
        private readonly AsyncOperationsService _asyncOperationsService;

        public RunState(IInputService inputService, 
            AsyncOperationsService asyncOperationsService)
        {
            _inputService = inputService;
            _asyncOperationsService = asyncOperationsService;
        }
        
        public UniTaskVoid Enter()
        {
            _inputService.SetEnable(true);
            
            return default;
        }

        public UniTask Exit()
        {
            _asyncOperationsService.CancelAllWorkingTokens();
            return UniTask.CompletedTask;
        }
    }
}