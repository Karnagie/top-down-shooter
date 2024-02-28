using System;
using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Infrastructure.CommandCache.Commands
{
    public class DebugCommand : CacheCommand<DebugCommand.Args, InfrastructureServiceHolder>
    {
        private ILogService _logService;
        private Args _args;

        public string LogValue => $"<color=#11ff11>Log from command</color>: {_args.Text}";

        public override void InitServices(InfrastructureServiceHolder services)
        {
            _logService = services.LogService;
        }

        protected override void InitArgsInternal(Args args)
        {
            _args = args;
        }

        protected override void PerformInternal()
        {
            _logService.Log(LogValue);
        }

        [Serializable]
        public struct Args
        {
            public string Text;
        }
    }
}