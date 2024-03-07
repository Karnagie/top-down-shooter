using System;
using CodeBase.Modules.CoreModule.Services.Creatures.Components.Base;
using CodeBase.Modules.CoreModule.Services.Ticking;
using UnityEngine;
using Zenject;

namespace CodeBase.Modules.CoreModule.Creatures.Components
{
    public class TargetMover : CoreComponent, ITickHandler, IEnableable
    {
        [SerializeField] private CreatureDefinition _creatureDefinition;
        
        private ICreatureBody _body;
        private CreatureService _creatureService;
        private ICreature _creature;
        private ITickService _tickService;
        private bool _enabled;

        [Inject]
        private void Construct(
            ICreatureBody body, 
            CreatureService creatureService,
            ICreature creature,
            ITickService tickService)
        {
            _tickService = tickService;
            _creature = creature;
            _creatureService = creatureService;
            _body = body;
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
            if (_enabled == false)
                return;
            
            var targets = _creatureService.FindAll(_creatureDefinition);
            
            if(targets.Count == 0)
                return;
            
            var direction = (targets[0].Transform.position-_creature.Transform.position).normalized;
            _body.Move(direction);
        }

        public void Enable()
        {
            _enabled = true;
        }

        public void Disable()
        {
            _enabled = false;
        }
    }
}