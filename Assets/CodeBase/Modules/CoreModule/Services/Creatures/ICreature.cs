using System;
using UnityEngine;

namespace CodeBase.Modules.CoreModule.Creatures
{
    public interface ICreature
    {
        Transform Transform { get; }

        void Enable();
        void Dispose();
    }
}