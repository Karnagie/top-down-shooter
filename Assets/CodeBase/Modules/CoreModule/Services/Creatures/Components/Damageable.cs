using CodeBase.Infrastructure.Services;
using CodeBase.Modules.CoreModule.Services.Creatures.Components.Base;
using UnityEngine;
using Zenject;

namespace CodeBase.Modules.CoreModule.Creatures.Components
{
    public class Damageable : CoreComponent, IDamageable
    {
        private ILogService _log;
        private ICreature _creature;

        [Inject]
        private void Construct(ILogService log, ICreature creature)
        {
            _creature = creature;
            _log = log;
        }
        
        public void Damage(float value)
        {
            _log.Log($"{_creature.Name} got damage: {value}", LogDefinition.Core);
        }
    }
}