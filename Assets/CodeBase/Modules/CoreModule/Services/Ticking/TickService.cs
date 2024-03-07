using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CodeBase.Modules.CoreModule.Services.Ticking
{
    public class TickService : ITickService, ITickable
    {
        private List<ITickHandler> _tickHandlers = new ();
        private float _delta;
        
        public void Add(ITickHandler tickHandler)
        {
            _tickHandlers.Add(tickHandler);
        }

        public void Remove(ITickHandler tickHandler)
        {
            _tickHandlers.Remove(tickHandler);
        }

        public void Tick()
        {
            _delta = Time.deltaTime;
            foreach (var tickHandler in _tickHandlers)
            {
                tickHandler.Tick(_delta);
            }
        }
    }
}