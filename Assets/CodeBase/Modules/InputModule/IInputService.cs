using UnityEngine;

namespace CodeBase.Modules.InputModule
{
    public interface IInputService
    {
        void SetEnable(bool enable);
        
        Vector2 MoveDirection { get; }
    }
}