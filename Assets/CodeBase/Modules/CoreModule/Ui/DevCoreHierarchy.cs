using CodeBase.Infrastructure.CommandCache;
using CodeBase.Infrastructure.CommandCache.Commands;
using CodeBase.Infrastructure.CommandCache.Commands.Args;
using CodeBase.Infrastructure.Services;
using CodeBase.Modules.CoreModule.Services;
using CodeBase.Modules.MenuModule;
using CodeBase.Modules.WindowsModule;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.Modules.CoreModule.Ui
{
    public class DevCoreHierarchy : MonoBehaviour, IPanel
    {
        public Button Play;
        public Button Restart;
        
        private ICommandService<InfrastructureServiceHolder> _infrastructureCommandService;
        private ICommandService<CoreServiceHolder> _coreCommandService;

        private ChangeStateCommand<FinalizeState<MenuState>> _returnToMenu;
        private ReplayCommand _replay;

        [Inject]
        private void Construct(
            ICommandService<InfrastructureServiceHolder> infrastructureCommandService,
            ICommandService<CoreServiceHolder> coreCommandService)
        {
            _coreCommandService = coreCommandService;
            _infrastructureCommandService = infrastructureCommandService;
        }
        
        public void Initialize()
        {
            _returnToMenu = _infrastructureCommandService.Create<ChangeStateCommand<FinalizeState<MenuState>>,NullArgs>();
            _replay = _coreCommandService.Create<ReplayCommand, NullArgs>();
            
            Play.onClick.AddListener((() => _returnToMenu.Perform()));
            Restart.onClick.AddListener((() => _replay.Perform()));
        }

        public void Show()
        {
            
        }
        
        public void Dispose()
        {
            
        }
    }
}