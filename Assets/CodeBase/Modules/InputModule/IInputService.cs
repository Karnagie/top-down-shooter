using UnityEngine;

namespace CodeBase.Modules.InputModule
{
    public interface IInputService
    {
        Vector2 MoveDirection { get; }
    }
}