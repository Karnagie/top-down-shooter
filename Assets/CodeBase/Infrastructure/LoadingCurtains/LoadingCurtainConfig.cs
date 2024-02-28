using UnityEngine;

namespace CodeBase.Infrastructure.LoadingCurtains
{
    [CreateAssetMenu(fileName = "New LoadingCurtain Config", menuName = "Configs/LoadingCurtainConfig", order = 0)]
    public class LoadingCurtainConfig : ScriptableObject
    {
        [SerializeField] private float _fadeDuration = 0.5f;
        [SerializeField] private LoadingCurtainBehaviour _behaviourPrefab;

        public float FadeDuration => _fadeDuration;
        public LoadingCurtainBehaviour BehaviourPrefab => _behaviourPrefab;
    }
}