using UnityEngine;

namespace CodeBase.Modules.CoreModule.Services.Creatures.Components.Base
{
    public interface IPhysicBody : ICoreComponent
    {
        Collider2D Collider { get; }

        bool TryGetAround<T>(out T findingComponent) where T : ICoreComponent;
    }
}