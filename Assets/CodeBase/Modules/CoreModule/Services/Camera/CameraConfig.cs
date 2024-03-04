using UnityEngine;

namespace CodeBase.Modules.CoreModule
{
    [CreateAssetMenu(fileName = nameof(CameraConfig), menuName = "ModuleConfigs/CameraConfig", order = 0)]
    public class CameraConfig : ScriptableObject
    {
        [SerializeField] private Vector2 _startOffset = Vector2.one * 10;
        [SerializeField] private float _startShowTime = 1;
        [SerializeField] private Camera _cameraPrefab;

        public Vector2 StartOffset => _startOffset;

        public float StartShowTime => _startShowTime;
        public Camera Camera => _cameraPrefab;
    }
}