using System.Collections.Generic;
using CodeBase.Modules.CoreModule.Services.Creatures.Components.Base;
using UnityEngine;
using Zenject;

namespace CodeBase.Modules.CoreModule.Services.Creatures
{
    public class Creature : CoreComponent, ICreature
    {
        [SerializeField] private string _name;

        private Vector3? _startPosition;
        private IEnumerable<IEnableable> _enumerable;

        public string Name => _name;

        public Transform Transform => transform;

        [Inject]
        private void Construct(IEnumerable<IEnableable> enableables)
        {
            _enumerable = enableables;
        }

        public void Reset()
        {
            _startPosition ??= transform.position;
            transform.position = _startPosition.Value;
        }

        public void Enable()
        {
            foreach (var enableable in _enumerable)
            {
                enableable.Enable();
            }
        }

        public void Disable()
        {
            foreach (var enableable in _enumerable)
            {
                enableable.Disable();
            }
        }

        public void Dispose()
        {
            if(gameObject != null)
                Object.Destroy(gameObject);
        }
    }
}