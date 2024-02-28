using CodeBase.Infrastructure.CommandCache;
using CodeBase.Infrastructure.CommandCache.Commands;
using CodeBase.Infrastructure.CommandCache.Commands.Args;
using CodeBase.Infrastructure.Services;
using CodeBase.Modules.CoreModule;
using CodeBase.Modules.WindowsModule;
using DG.Tweening;
using UnityEngine;
using Zenject;
using Button = UnityEngine.UI.Button;
using Object = UnityEngine.Object;

namespace CodeBase.Modules.MenuModule
{
    public class MenuHierarchy : MonoBehaviour, IPanel
    {
        private ICommandService<InfrastructureServiceHolder> _commandFacade;
        
        public Button Play;
        private ChangeStateCommand<CoreState> _playCommand;

        [Inject]
        private void Construct(ICommandService<InfrastructureServiceHolder> commandFacade)
        {
            _commandFacade = commandFacade;
        }

        public void Initialize()
        {
            _playCommand = _commandFacade.Create<ChangeStateCommand<CoreState>, NullArgs>(new NullArgs());
        }
        
        public void Show()
        {
            Play.onClick.AddListener(OnPlay);
            Play.transform.DOPunchScale(Vector3.one/10, 0.5f);
        }

        private void OnPlay()
        {
            _playCommand.Perform();
        }

        public void Dispose()
        {
            Object.Destroy(gameObject);
        }
    }
}