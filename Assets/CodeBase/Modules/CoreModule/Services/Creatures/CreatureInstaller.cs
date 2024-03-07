using System;
using System.Collections.Generic;
using System.Linq;
using CodeBase.Modules.CoreModule.Creatures.Components;
using CodeBase.Modules.CoreModule.Services.Creatures.Components.Base;
using UnityEngine;
using Zenject;

namespace CodeBase.Modules.CoreModule.Creatures
{
    public class CreatureInstaller : MonoInstaller, IInitializable
    {
        [SerializeField] private List<CoreComponent> _components;
        
        private LinkService _linkService;

        [Inject]
        private void Construct(LinkService linkService)
        {
            _linkService = linkService;
        }

        private void OnValidate()
        {
            _components = gameObject.GetComponentsInChildren<CoreComponent>().ToList();
        }

        public override void InstallBindings()
        {
            foreach (var component in _components)
            {
                Container.BindInterfacesAndSelfTo(component.GetType()).FromInstance(component).AsSingle();
            }

            Container.BindInterfacesAndSelfTo<CreatureInstaller>().FromInstance(this).AsSingle();
        }

        public void Initialize()
        {
            _linkService.Add(_components);
        }
    }
}