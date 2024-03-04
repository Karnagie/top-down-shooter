using CodeBase.Infrastructure.LoadingCurtains;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.AsyncOperations;
using CodeBase.Infrastructure.StateMachines.Game;
using CodeBase.Infrastructure.StateMachines.Game.States.Types;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Modules.CoreModule
{
    public class FinalizeState<TState> : IGameState where TState : IGameState
    {
        private readonly ILogService _logger;
        private readonly GameStateMachine _gameStateMachine;
        private readonly AsyncOperationsService _asyncOperationsService;

        public FinalizeState(
            ILogService logger,
            GameStateMachine gameStateMachine,
            AsyncOperationsService asyncOperationsService)
        {
            _asyncOperationsService = asyncOperationsService;
            _gameStateMachine = gameStateMachine;
            _logger = logger;
        }

        public UniTaskVoid Enter()
        {
            _logger.Log($"{nameof(FinalizeState<TState>)} entered", LogDefinition.GameState);
            _asyncOperationsService.CancelAllWorkingTokens();
            _gameStateMachine.Enter<TState>();
            return default;
        }

        public UniTask Exit()
        {
            _logger.Log($"{nameof(FinalizeState<TState>)} exited", LogDefinition.GameState);
            return UniTask.CompletedTask;
        }
    }
}