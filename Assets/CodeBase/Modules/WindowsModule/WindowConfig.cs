using CodeBase.Modules.CoreModule.Ui;
using CodeBase.Modules.MenuModule;
using UnityEngine;

namespace CodeBase.Modules.WindowsModule
{
    [CreateAssetMenu(fileName = "WindowConfig", menuName = "ModuleConfigs/WindowConfig", order = 0)]
    public class WindowConfig : ScriptableObject
    {
        [SerializeField] private MenuHierarchy _menu;
        [SerializeField] private DevCoreHierarchy _devCoreHierarchy;

        public MenuHierarchy Menu => _menu;
        public DevCoreHierarchy DevCore => _devCoreHierarchy;
    }
}