using System.Threading.Tasks;
using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.LoadingCurtains
{
    public interface ILoadingCurtain
    {
        UniTask Initialize();
        UniTask Show();
        UniTask Hide();
    }
}