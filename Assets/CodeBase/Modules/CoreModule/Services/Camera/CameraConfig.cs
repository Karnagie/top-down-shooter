using UnityEngine;

namespace CodeBase.Modules.CoreModule.Services.Camera
{
    [CreateAssetMenu(fileName = nameof(CameraConfig), menuName = "ModuleConfigs/CameraConfig", order = 0)]
    public class CameraConfig : ScriptableObject
    {
        [SerializeField] private Vector2 _startOffset = Vector2.one * 10;
        [SerializeField] private float _startShowTime = 1;
        [SerializeField] private UnityEngine.Camera _cameraPrefab;

        public Vector2 StartOffset => _startOffset;

        public float StartShowTime => _startShowTime;
        public UnityEngine.Camera Camera => _cameraPrefab;
    }
}