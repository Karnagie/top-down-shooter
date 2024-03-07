using CodeBase.Modules.CoreModule.Services.Creatures.Components.Base;
using UnityEngine;

namespace CodeBase.Modules.CoreModule.Services.Creatures.Components
{
    public class CreatureBody : CoreComponent, ICreatureBody
    {
        [SerializeField] private float _speed = 1;
        [SerializeField] private Transform _body;
        
        public void Move(Vector2 direction)
        {
            _body.transform.position += (Vector3)(direction * _speed * Time.deltaTime);
        }
    }
}