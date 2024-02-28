using CodeBase.Modules.CoreModule.Creatures;
using CodeBase.Modules.CoreModule.World;
using UnityEngine;

namespace CodeBase.Modules.CoreModule
{
    [CreateAssetMenu(fileName = "CoreConfig ", menuName = "ModuleConfigs/CoreConfig ", order = 0)]
    public class CoreConfig : ScriptableObject
    {
        [SerializeField] private RoomHierarchy _roomHierarchy;

        [SerializeField] private Creature _player;

        public RoomHierarchy Room => _roomHierarchy;
        public Creature Player => _player;
    }
}