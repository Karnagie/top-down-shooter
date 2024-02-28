using UnityEngine;

namespace CodeBase.Modules.InputModule
{
    public class PcInputService : IInputService
    {
        public Vector2 MoveDirection => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}