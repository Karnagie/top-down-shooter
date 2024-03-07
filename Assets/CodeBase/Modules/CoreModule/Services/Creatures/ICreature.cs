using System;
using CodeBase.Modules.CoreModule.Services.Creatures.Components.Base;
using UnityEngine;

namespace CodeBase.Modules.CoreModule.Creatures
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