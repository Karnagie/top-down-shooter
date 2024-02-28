using CodeBase.Modules.InputModule;
using UnityEngine;
using Zenject;

namespace CodeBase.Modules.CoreModule.Creatures.Components
{
    public class InputMover : MonoBehaviour
    {
        private IInputService _inputService;
        private ICreatureBody _body;

        [Inject]
        private void Construct(IInputService inputService, ICreatureBody body)
        {
            _body = body;
            _inputService = inputService;
        }

        private void FixedUpdate()
        {
            var direction = _inputService.MoveDirection;
            _body.Move(direction);
        }
    }
}