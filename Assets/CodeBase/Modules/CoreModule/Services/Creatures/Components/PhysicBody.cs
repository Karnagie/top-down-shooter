using CodeBase.Modules.CoreModule.Services.Creatures.Components.Base;
using CodeBase.Modules.CoreModule.Services.Physic;
using UnityEngine;
using Zenject;

namespace CodeBase.Modules.CoreModule.Services.Creatures.Components
{
    public class PhysicBody : CoreComponent, IPhysicBody
    {
        [SerializeField] private Collider2D _collider;
        
        private PhysicService _physicService;
        private LinkService _linkService;
        
        public Collider2D Collider => _collider;
        
        [Inject]
        public void Construct(PhysicService physicService, LinkService linkService)
        {
            _linkService = linkService;
            _physicService = physicService;
        }

        private void Start()
        {
            _physicService.Add(this);
        }

        private void OnDestroy()
        {
            _physicService.Remove(this);
        }

        public bool TryGetAround<T>(out T findingComponent) where T : ICoreComponent
        {
            findingComponent = default;
            
            var creatures = _physicService.GetTriggeringCreatures(this);
            foreach (var creature in creatures)
            {
                if (_linkService.TryGet(creature, out T component))
                {
                    findingComponent = component;
                }
            }
            
            return findingComponent != null;
        }
    }
}