using System;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Infrastructure.CommandCache
{
    public class CommandCacheService
    {
        private List<ICacheCommand> _commands = new ();

        public event Action<ICacheCommand> Removed;

        public void Add(ICacheCommand command)
        {
            if (_commands.Contains(command))
            {
                Debug.Log($"Copies not supporting!");
                return;
            }
            
            _commands.Add(command);
        }

        public bool TryRemove(ICacheCommand command)
        {
            if(_commands.Contains(command) == false)
                return false;
            
            _commands.Remove(command);
            Removed?.Invoke(command);
            return true;
        }
    }
}