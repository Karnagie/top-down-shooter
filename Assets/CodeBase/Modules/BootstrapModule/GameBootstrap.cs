using CodeBase.Infrastructure.StateMachines;
using CodeBase.Infrastructure.StateMachines.Game;
using CodeBase.Infrastructure.StateMachines.Game.States.Types;
using UnityEngine;
using Zenject;

namespace CodeBase.Modules.BootstrapModule
{
    public class GameBootstrap : MonoBehaviour
    {
        private GameStateMachine _gameStateMachine;
        private IStateHolder<IExitableGameState> _stateHolder;

        [Inject]
        private void Construct(GameStateMachine gameStateMachine, IStateHolder<IExitableGameState> stateHolder)
        {
            _stateHolder = stateHolder;
            _gameStateMachine = gameStateMachine;
        }

        private void Awake()
        {
            _gameStateMachine.Initialize(_stateHolder);
            _gameStateMachine.Enter<BootstrapState>();
        }
    }
}