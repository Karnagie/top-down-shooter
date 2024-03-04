using CodeBase.Infrastructure.Assets;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Modules.WindowsModule
{
    public class WindowService : IWindowService
    {
        private IAssetProvider _assetProvider;
        private WindowConfig _windowConfig;

        public WindowService(IAssetProvider assetProvider, WindowConfig windowConfig)
        {
            _windowConfig = windowConfig;
            _assetProvider = assetProvider;
        }
        
        public async UniTask<IPanel> LoadMainUi(Transform parent)
        {
            return await _assetProvider.Instantiate(_windowConfig.Menu, parent);
        }

        public async UniTask<IPanel> LoadDevCoreUi(Transform parent)
        {
            return await _assetProvider.Instantiate(_windowConfig.DevCore, parent);
        }
    }
}