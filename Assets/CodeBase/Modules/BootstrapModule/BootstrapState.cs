
using CodeBase.Infrastructure.CommandCache;
using CodeBase.Infrastructure.Editor;
using CodeBase.Infrastructure.LoadingCurtains;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.StateMachines.Game;
using CodeBase.Infrastructure.StateMachines.Game.States.Types;
using CodeBase.Modules.MenuModule;
using Cysharp.Threading.Tasks;

namespace CodeBase.Modules.BootstrapModule
{
    public class BootstrapState : IGameState
    {
        private ILogService _logger;
        private ILoadingCurtain _loadingCurtain;
        private GameStateMachine _gameStateMachine;
        
#if UNITY_EDITOR
        private IEditorStaticDataService _editorStaticDataService;
        private ICommandService<InfrastructureServiceHolder> _commandFacade;

        public BootstrapState(
            ILogService logger, 
            ILoadingCurtain loadingCurtain, 
            GameStateMachine gameStateMachine,
            IEditorStaticDataService editorStaticDataService,
            ICommandService<InfrastructureServiceHolder> commandFacade)
        {
            _commandFacade = commandFacade;
            _editorStaticDataService = editorStaticDataService;
            _gameStateMachine = gameStateMachine;
            _loadingCurtain = loadingCurtain;
            _logger = logger;
        }
#else
        public BootstrapState(
            ILogService logger, 
            ILoadingCurtain loadingCurtain, 
            GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
            _loadingCurtain = loadingCurtain;
            _logger = logger;
        }
#endif

        public async UniTaskVoid Enter()
        {
            _logger.Log($"{nameof(BootstrapState)} entered", LogDefinition.GameState);
#if UNITY_EDITOR
            _editorStaticDataService.StartedFromBootstrap = true;
#endif
            await _loadingCurtain.Initialize();
            await _loadingCurtain.Show();
            _commandFacade.Initialize();
            _gameStateMachine.Enter<MenuState>();
        }

        public UniTask Exit()
        {
            _logger.Log($"{nameof(BootstrapState)} exited", LogDefinition.GameState);
            return UniTask.CompletedTask;
        }
    }
}