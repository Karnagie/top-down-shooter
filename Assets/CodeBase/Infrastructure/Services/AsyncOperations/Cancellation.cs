using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;

namespace CodeBase.Infrastructure.Services.AsyncOperations
{
    public class Cancellation : IDisposable
    {
        private CancellationTokenSource _cancellationTokenSource;
        
        public CancellationDefinition CancellationDefinition { get; }
        public CancellationToken Token => _cancellationTokenSource.Token;
        public bool IsCancellationRequested => Token.IsCancellationRequested;

        public event Action<Cancellation, CancellationDefinition> Disposing;

        public Cancellation(CancellationDefinition cancellationDefinition,
            CancellationTokenSource cancellationTokenSource)
        {
            CancellationDefinition = cancellationDefinition;
            _cancellationTokenSource = cancellationTokenSource;
        }

        public void Dispose()
        {
            Disposing?.Invoke(this, CancellationDefinition);
            Cancel();
            Disposing = null;
        }

        public void Cancel() => _cancellationTokenSource.Cancel();
    }

    public static class UniTaskExtensions
    {
        public static UniTask CompleteWithCancellation(this Tween tween, CancellationToken cancellationToken)
        {
            return tween.AwaitForComplete(TweenCancelBehaviour.KillWithCompleteCallback, cancellationToken);
        }
    }
}