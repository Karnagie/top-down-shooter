using System.Collections.Generic;

namespace CodeBase.Infrastructure.StateMachines
{
    public interface IStateHolder<in TState>
    {
        void Add(IEnumerable<TState> states);
        
        public TFindingState GetStateByType<TFindingState>() where TFindingState : IState, TState;
        public TEnterState GetStateByType<TEnterState, TArgs>() where TEnterState : IStateWithArgs<TArgs>, TState;
    }
}