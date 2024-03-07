using System.Collections.Generic;
using CodeBase.Modules.CoreModule.Creatures;
using CodeBase.Modules.CoreModule.Creatures.Components;
using CodeBase.Modules.CoreModule.Services.Creatures.Components.Base;
using UnityEngine;

namespace CodeBase.Modules.CoreModule.Services.Physic
{
    public class PhysicService
    {
        private List<IPhysicBody> _physicBodies = new ();
        private float _delta;
        
        public void Add(IPhysicBody tickHandler)
        {
            _physicBodies.Add(tickHandler);
        }

        public void Remove(IPhysicBody tickHandler)
        {
            _physicBodies.Remove(tickHandler);
        }

        public List<IPhysicBody> GetTriggeringCreatures(IPhysicBody physicBody)
        {
            List<IPhysicBody> bodies = new List<IPhysicBody>();
            
            foreach (var body in _physicBodies)
            {
                if (physicBody == body)
                    continue;
                
                if (physicBody.Collider.IsTouching(body.Collider))
                {
                    bodies.Add(body);
                }
            }

            return bodies;
        }
    }
}