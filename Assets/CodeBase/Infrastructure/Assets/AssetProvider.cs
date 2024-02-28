using CodeBase.Infrastructure.Services;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Assets
{
    //todo Addressable
    //todo separate asset provider and factory logics
    public class AssetProvider : IAssetProvider
    {
        private ILogService _log;
        private IInstantiator _instantiator;

        public AssetProvider(ILogService log, IInstantiator instantiator)
        {
            _instantiator = instantiator;
            _log = log;
        }
        
        public GameObject Instantiate(string path, Transform parent, bool inject = true)
        {
            var prefab = Resources.Load<GameObject>(path);
            var gameObject = inject ? 
                _instantiator.InstantiatePrefab(prefab, parent) :
                Object.Instantiate(prefab, parent);
            return gameObject;
        }
        
        public UniTask<T> Instantiate<T>(T prefab, Transform parent, bool inject = true) where T : Object
        {
            var gameObject = inject ? 
                _instantiator.InstantiatePrefabForComponent<T>(prefab, parent) :
                Object.Instantiate(prefab, parent);
            return new UniTask<T>(gameObject);
        }

        public UniTask<T> Instantiate<T>(string path, Transform parent, bool inject = true) where T : Object
        {
            var prefab = Resources.Load<T>(path);
            if(prefab == null)
                _log.LogError($"prefab {path} is null");
            var gameObject = inject ? 
                _instantiator.InstantiatePrefabForComponent<T>(prefab, parent) :
                Object.Instantiate(prefab, parent);
            return new UniTask<T>(gameObject);
        }
    }
}