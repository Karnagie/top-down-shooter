using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Modules.WindowsModule
{
    public interface IWindowService
    {
        UniTask<IPanel> LoadMainUi(Transform parent);
        UniTask<IPanel> LoadDevCoreUi(Transform parent);
    }
}