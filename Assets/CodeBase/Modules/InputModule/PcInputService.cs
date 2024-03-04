using CodeBase.Modules.CoreModule;
using UnityEngine;

namespace CodeBase.Modules.InputModule
{
    public class PcInputService : IInputService
    {
        private bool _enable;

        public void SetEnable(bool enable)
        {
            _enable = enable;
        }

        public Vector2 MoveDirection => GetMoveDirection();

        private Vector2 GetMoveDirection()
        {
            if(_enable == false)
                return Vector2.zero;
            
            return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
    }
}