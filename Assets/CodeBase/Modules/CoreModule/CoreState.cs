using CodeBase.Infrastructure.LoadingCurtains;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.StateMachines.Game.States.Types;
using Cysharp.Threading.Tasks;

namespace CodeBase.Modules.CoreModule
{
    public class CoreState : IGameState
    {
        private readonly ILogService _logger;
        private readonly ILoadingCurtain _loadingCurtain;

        private readonly CoreFacade _coreFacade;
        public CoreState(
            ILogService logger, 
            ILoadingCurtain loadingCurtain, 
            CoreFacade coreFacade)
        {
            _loadingCurtain = loadingCurtain;
            _coreFacade = coreFacade;
            _logger = logger;
        }
        
        public async UniTaskVoid Enter()
        {
            _logger.Log($"{nameof(CoreState)} entered");
            await _loadingCurtain.Show();
            await _coreFacade.Initialize();
            await _loadingCurtain.Hide();
            _coreFacade.Run();
        }

        public async UniTask Exit()
        {
            await _loadingCurtain.Show();
            
            _coreFacade.Dispose();
            _logger.Log($"{nameof(CoreState)} exited");
        }
    }
}