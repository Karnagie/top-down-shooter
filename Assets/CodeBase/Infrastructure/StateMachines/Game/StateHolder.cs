using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.Services;

namespace CodeBase.Infrastructure.StateMachines.Game
{
    public class StateHolder<TState> : IStateHolder<TState>
    {
        private Dictionary<Type, TState> _states = new();
        private ILogService _log;

        public StateHolder(List<TState> states, ILogService log)
        {
            _log = log;
            foreach (var state in states)
            {
                _states.Add(state.GetType(), state);
            }
        }

        public void Add(IEnumerable<TState> states)
        {
            foreach (var state in states)
            {
                if (_states.TryAdd(state.GetType(), state) == false)
                    _log.LogError($"State with type {state.GetType()} is already added");
            }
        }
        
        public TFindingState GetStateByType<TFindingState>() where TFindingState : IState, TState
        {
            return (TFindingState)_states[typeof(TFindingState)];
        }

        public TEnterState GetStateByType<TEnterState, TArgs>() where TEnterState : IStateWithArgs<TArgs>, TState
        {
            return (TEnterState)_states[typeof(TEnterState)];
        }
    }
}