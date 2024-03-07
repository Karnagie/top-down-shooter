using UnityEngine;

namespace CodeBase.Modules.CoreModule.Services.Creatures
{
    public interface ICreature
    {
        Transform Transform { get; }
        string Name { get; }

        void Enable();
        void Disable();
        
        void Dispose();
        void Reset();
    }
}