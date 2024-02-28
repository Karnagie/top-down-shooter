using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.StateMachines
{
    public class StateMachine<TState> where TState : IExitableState
    {
        private IStateHolder<TState> _stateHolder;
        private IExitableState _currentState;
        
        public void Initialize(IStateHolder<TState> stateHolder)
        {
            _stateHolder = stateHolder;
        }
        
        public async void Enter<TEnterState>() where TEnterState : IState, TState
        {
            if(_currentState != null)
                await _currentState.Exit();
            
            var newState = _stateHolder.GetStateByType<TEnterState>();
            newState.Enter();
            _currentState = newState;
        }
        
        public async UniTaskVoid Enter<TEnterState, TArgs>(TArgs args) where TEnterState : IStateWithArgs<TArgs>, TState
        {
            if(_currentState != null)
                await _currentState.Exit();
            
            var newState = _stateHolder.GetStateByType<TEnterState, TArgs>();
            newState.Enter(args);
            _currentState = newState;
        }
    }
}