using System.Collections.Generic;
using System.Linq;

namespace CodeBase.Modules.CoreModule.Services.Creatures.Components.Base
{
    public class LinkService
    {
        private readonly HashSet<List<object>> _componentGroups = new();
        
        public bool TryGet<T>(object baseComponent, out T component) where T : ICoreComponent
        {
            component = default;
            
            foreach (var componentGroup in _componentGroups)
            {
                if (componentGroup.Contains(baseComponent) == false)
                    continue;

                foreach (var coreComponent in componentGroup)
                {
                    if (coreComponent is T typedComponent)
                    {
                        component = typedComponent;
                        return true;
                    }
                }
            }
            
            return false;
        }

        public void Add(List<CoreComponent> components)
        {
            _componentGroups.Add(components.Cast<object>().ToList());
        }
    }
}