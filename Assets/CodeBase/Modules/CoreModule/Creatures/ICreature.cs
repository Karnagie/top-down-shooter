using System;

namespace CodeBase.Modules.CoreModule.Creatures
{
    public interface ICreature : IDisposable
    {
        void Enable();
    }
}