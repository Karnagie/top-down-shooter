using CodeBase.Modules.MenuModule;
using UnityEngine;

namespace CodeBase.Modules.WindowsModule
{
    [CreateAssetMenu(fileName = "WindowConfig", menuName = "ModuleConfigs/WindowConfig", order = 0)]
    public class WindowConfig : ScriptableObject
    {
        [SerializeField] private MenuHierarchy _menu;

        public MenuHierarchy Menu => _menu;
    }
}