using System.Collections.Generic;
using System.Threading;

namespace CodeBase.Infrastructure.Services.AsyncOperations
{
    public class AsyncOperationsService
    {
        public Dictionary<CancellationDefinition, List<Cancellation>> _tokens = new ();
        
        public Cancellation CreateCancellationToken(CancellationDefinition cancellationDefinition)
        {
            if (_tokens.ContainsKey(cancellationDefinition) == false)
            {
                _tokens.Add(cancellationDefinition, new List<Cancellation>());
            }   
            
            var tokenSource = new Cancellation(cancellationDefinition, new CancellationTokenSource());
            tokenSource.Disposing += RemoveCancellation;
            
            _tokens[cancellationDefinition].Add(tokenSource);
            
            return tokenSource;
        }

        public void CancelByDefinition(CancellationDefinition cancellationDefinition)
        {
            if (_tokens.TryGetValue(cancellationDefinition, out var cancellations))
            {
                foreach (var cancellation in cancellations)
                {
                    cancellation.Cancel();
                }
            }
        }

        public void CancelAllWorkingTokens()
        {
            foreach (var token in _tokens)
            {
                foreach (var cancellation in token.Value.ToArray())
                {
                    cancellation.Cancel();
                }
            }
        }

        private void RemoveCancellation(Cancellation cancellation, CancellationDefinition definition)
        {
            cancellation.Disposing -= RemoveCancellation;
            _tokens[definition].Remove(cancellation);
        }
    }
}