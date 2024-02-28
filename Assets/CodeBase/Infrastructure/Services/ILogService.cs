using UnityEngine;

namespace CodeBase.Infrastructure.Services
{
    public class LogService : ILogService
    {
        public void Log(string text)
        {
            Debug.Log(text);
            LastLog = text;
        }

        public void LogError(string text)
        {
            Debug.LogError($"{text}");
            LastLog = text;
        }

        public string LastLog { get; private set; }
    }

    public interface ILogService
    {
        string LastLog { get; }
        
        void Log(string text);
        void LogError(string text);
    }
}