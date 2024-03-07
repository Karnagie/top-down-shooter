using CodeBase.Infrastructure.LoadingCurtains;
using CodeBase.Infrastructure.Services.AsyncOperations;
using CodeBase.Modules.CoreModule.Creatures;
using CodeBase.Modules.CoreModule.StateMachine;
using CodeBase.Modules.InputModule;
using Cysharp.Threading.Tasks;

namespace CodeBase.Modules.CoreModule
{
    public class InitializeState : ICoreState
    {
        private readonly ICameraService _cameraService;
        private readonly CreatureService _creatureService;
        private readonly CoreStateMachine _coreStateMachine;
        private readonly ServiceHandler _serviceHandler;
        private readonly ILoadingCurtain _loadingCurtain;
        private readonly IInputService _inputService;
        private readonly AsyncOperationsService _asyncOperationsService;

        public InitializeState(
            ICameraService cameraService, 
            CreatureService creatureService,
            CoreStateMachine coreStateMachine, 
            ServiceHandler serviceHandler,
            ILoadingCurtain loadingCurtain,
            IInputService inputService, 
            AsyncOperationsService asyncOperationsService)
        {
            _inputService = inputService;
            _asyncOperationsService = asyncOperationsService;
            _loadingCurtain = loadingCurtain;
            _coreStateMachine = coreStateMachine;
            _serviceHandler = serviceHandler;
            _creatureService = creatureService;
            _cameraService = cameraService;
        }
        
        public async UniTaskVoid Enter()
        {
            _asyncOperationsService.CancelAllWorkingTokens();
            _inputService.SetEnable(false);
            
            await _loadingCurtain.Show();
            
            await _serviceHandler.PrewarmAll();

            await _loadingCurtain.Hide();
            
            await _cameraService.FollowTo(_creatureService.Player);

            _coreStateMachine.Enter<RunState>();
        }

        public UniTask Exit()
        {
            return UniTask.CompletedTask;
        }
    }
}