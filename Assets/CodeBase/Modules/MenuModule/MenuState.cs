using CodeBase.Infrastructure.LoadingCurtains;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.StateMachines.Game.States.Types;
using Cysharp.Threading.Tasks;

namespace CodeBase.Modules.MenuModule
{
    public class MenuState : IGameState
    {
        private readonly ILogService _logger;
        private readonly ILoadingCurtain _loadingCurtain;
        private readonly MenuFacade _menuFacade;

        public MenuState(
            ILogService logger, 
            ILoadingCurtain loadingCurtain, 
            MenuFacade menuFacade)
        {
            _loadingCurtain = loadingCurtain;
            _menuFacade = menuFacade;
            _logger = logger;
        }
        
        public async UniTaskVoid Enter()
        {
            _logger.Log($"{nameof(MenuState)} entered");
            await _loadingCurtain.Show();
            await _menuFacade.Initialize();
            await _loadingCurtain.Hide();
            _menuFacade.Run();
        }

        public async UniTask Exit()
        {
            await _loadingCurtain.Show();
            
            _menuFacade.Dispose();
            _logger.Log($"{nameof(MenuState)} exited");
        }
    }
}