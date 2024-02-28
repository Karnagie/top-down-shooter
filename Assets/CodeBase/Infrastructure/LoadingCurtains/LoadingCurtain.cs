using CodeBase.Infrastructure.Assets;
using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.LoadingCurtains
{
    public class LoadingCurtain : ILoadingCurtain
    {
        private IAssetProvider _assetProvider;
        private LoadingCurtainBehaviour _behaviour;
        private LoadingCurtainConfig _config;

        public LoadingCurtain(
            IAssetProvider assetProvider, 
            LoadingCurtainConfig config)
        {
            _config = config;
            _assetProvider = assetProvider;
        }

        public async UniTask Initialize()
        {
            if(_behaviour == null)
                _behaviour = await _assetProvider.Instantiate(_config.BehaviourPrefab, null, inject: false);
        }
        
        public async UniTask Show()
        {
            await _behaviour.Show(_config.FadeDuration);
        }

        public async UniTask Hide()
        {
            await _behaviour.Hide(_config.FadeDuration);
        }
    }
}