using System;
using CodeBase.Modules.CoreModule.Services.Creatures.Components.Base;
using CodeBase.Modules.CoreModule.Services.Ticking;
using UnityEngine;
using Zenject;

namespace CodeBase.Modules.CoreModule.Creatures.Components
{
    public class CollisionDamager : CoreComponent, ITickHandler
    {
        [SerializeField] private float _damage = 1;
        [SerializeField] private CreatureDefinition _targetFraction;
        
        private IDamageReady _damageReady;
        private IPhysicBody _physicBody;
        private ITickService _tickService;
        private LinkService _linkService;

        [Inject]
        public void Construct(
            IPhysicBody physicBody,
            ITickService tickService,
            IDamageReady damageReady,
            LinkService linkService)
        {
            _linkService = linkService;
            _tickService = tickService;
            _physicBody = physicBody;
            _damageReady = damageReady;
        }

        private void Awake()
        {
            _tickService.Add(this);
        }

        public void Tick(float delta)
        {
            if(_damageReady.IsReady() == false)
                return;

            if (_physicBody.TryGetAround(out IDamageable player) == false)
                return;

            if(_linkService.TryGet(player, out IFractionCreature fractionCreature) == false)
                return;
            
            if(fractionCreature.Fraction != _targetFraction)
                return;
            
            player.Damage(_damage);
            _damageReady.Reset();
        }

        private void OnDestroy()
        {
            _tickService.Remove(this);
        }
    }
}