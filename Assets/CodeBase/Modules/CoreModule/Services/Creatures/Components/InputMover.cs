using CodeBase.Modules.CoreModule.Services.Creatures.Components.Base;
using CodeBase.Modules.CoreModule.Services.Ticking;
using CodeBase.Modules.InputModule;
using Zenject;

namespace CodeBase.Modules.CoreModule.Services.Creatures.Components
{
    public class InputMover : CoreComponent, ITickHandler
    {
        private IInputService _inputService;
        private ICreatureBody _body;
        private ITickService _tickService;

        [Inject]
        private void Construct(
            IInputService inputService, 
            ICreatureBody body,
            ITickService tickService)
        {
            _tickService = tickService;
            _body = body;
            _inputService = inputService;
        }

        private void Start()
        {
            _tickService.Add(this);
        }

        private void OnDestroy()
        {
            _tickService.Remove(this);
        }

        public void Tick(float delta)
        {
            var direction = _inputService.MoveDirection;
            _body.Move(direction);
        }
    }
}