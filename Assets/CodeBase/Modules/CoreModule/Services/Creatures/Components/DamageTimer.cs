using CodeBase.Modules.CoreModule.Services.Creatures.Components.Base;
using UnityEngine;

namespace CodeBase.Modules.CoreModule.Services.Creatures.Components
{
    public class DamageTimer : CoreComponent, IDamageReady
    {
        [SerializeField] private float _cooldown = 1;
        
        private float _nextReadyTime;

        public bool IsReady()
        {
            return Time.time >= _nextReadyTime;
        }

        public void Reset()
        {
            _nextReadyTime = Time.time + _cooldown;
        }
    }
}