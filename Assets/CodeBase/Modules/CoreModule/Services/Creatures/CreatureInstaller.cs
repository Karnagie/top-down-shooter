using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CodeBase.Modules.CoreModule.Creatures
{
    public class CreatureInstaller : MonoInstaller
    {
        [SerializeField] private List<Object> _components;
        
        public override void InstallBindings()
        {
            foreach (var component in _components)
            {
                Container.BindInterfacesTo(component.GetType()).FromInstance(component).AsSingle();
            }
        }
    }
}