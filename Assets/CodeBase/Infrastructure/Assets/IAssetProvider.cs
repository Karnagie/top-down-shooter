using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Infrastructure.Assets
{
    public interface IAssetProvider
    {
        GameObject Instantiate(string path, Transform parent, bool inject = true);
        UniTask<T> Instantiate<T>(string path, Transform parent, bool inject = true) where T : Object;
        UniTask<T> Instantiate<T>(T prefab, Transform parent, bool inject = true) where T : Object;
    }
}